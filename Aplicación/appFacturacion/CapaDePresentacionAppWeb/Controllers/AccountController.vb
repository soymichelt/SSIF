Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Transactions
Imports System.Web.Routing
Imports DotNetOpenAuth.AspNet
Imports Microsoft.Web.WebPages.OAuth
Imports WebMatrix.WebData

<Authorize()> _
<InitializeSimpleMembership()> _
Public Class AccountController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Account/Login

    <AllowAnonymous()> _
    Public Function Login(ByVal returnUrl As String) As ActionResult
        ViewData("ReturnUrl") = returnUrl
        Return View()
    End Function

    '
    ' POST: /Account/Login

    <HttpPost()> _
    <AllowAnonymous()> _
    <ValidateAntiForgeryToken()> _
    Public Function Login(ByVal model As LoginModel, ByVal returnUrl As String) As ActionResult
        If ModelState.IsValid AndAlso WebSecurity.Login(model.UserName, model.Password, persistCookie:=model.RememberMe) Then
            Return RedirectToLocal(returnUrl)
        End If

        ' Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
        ModelState.AddModelError("", "El nombre de usuario o la contraseña especificados son incorrectos.")
        Return View(model)
    End Function

    '
    ' POST: /Account/LogOff

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Public Function LogOff() As ActionResult
        WebSecurity.Logout()

        Return RedirectToAction("Index", "Home")
    End Function

    '
    ' GET: /Account/Register

    <AllowAnonymous()> _
    Public Function Register() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Account/Register

    <HttpPost()> _
    <AllowAnonymous()> _
    <ValidateAntiForgeryToken()> _
    Public Function Register(ByVal model As RegisterModel) As ActionResult
        If ModelState.IsValid Then
            ' Intento de registrar al usuario
            Try
                WebSecurity.CreateUserAndAccount(model.UserName, model.Password)
                WebSecurity.Login(model.UserName, model.Password)
                Return RedirectToAction("Index", "Home")
            Catch e As MembershipCreateUserException

                ModelState.AddModelError("", ErrorCodeToString(e.StatusCode))
            End Try
        End If

        ' Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
        Return View(model)
    End Function

    '
    ' POST: /Account/Disassociate

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Public Function Disassociate(ByVal provider As String, ByVal providerUserId As String) As ActionResult
        ' Integrar una transacción para evitar que el usuario desasocie por accidente sus cuentas.

        Dim ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId)
        Dim message As ManageMessageId? = Nothing

        ' Desasociar la cuenta solo si el usuario que ha iniciado sesión es el propietario
        If ownerAccount = User.Identity.Name Then
            ' Usar una transacción para evitar que el usuario elimine su última credencial de inicio de sesión
            Using scope As New TransactionScope(TransactionScopeOption.Required, New TransactionOptions With {.IsolationLevel = IsolationLevel.Serializable})
                Dim hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name))
                If hasLocalAccount OrElse OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1 Then
                    OAuthWebSecurity.DeleteAccount(provider, providerUserId)
                    scope.Complete()
                    message = ManageMessageId.RemoveLoginSuccess
                End If
            End Using
        End If

        Return RedirectToAction("Manage", New With {.Message = message})
    End Function

    '
    ' GET: /Account/Manage

    Public Function Manage(ByVal message As ManageMessageId?) As ActionResult
        ViewData("StatusMessage") =
            If(message = ManageMessageId.ChangePasswordSuccess, "La contraseña se ha cambiado.", _
                If(message = ManageMessageId.SetPasswordSuccess, "Su contraseña se ha establecido.", _
                    If(message = ManageMessageId.RemoveLoginSuccess, "El inicio de sesión externo se ha quitado.", _
                        "")))

        ViewData("HasLocalPassword") = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name))
        ViewData("ReturnUrl") = Url.Action("Manage")
        Return View()
    End Function

    '
    ' POST: /Account/Manage

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Public Function Manage(ByVal model As LocalPasswordModel) As ActionResult
        Dim hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name))
        ViewData("HasLocalPassword") = hasLocalAccount
        ViewData("ReturnUrl") = Url.Action("Manage")
        If hasLocalAccount Then
            If ModelState.IsValid Then
                ' ChangePassword iniciará una excepción en lugar de devolver false en determinados escenarios de error.
                Dim changePasswordSucceeded As Boolean

                Try
                    changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword)
                Catch e As Exception
                    changePasswordSucceeded = False
                End Try

                If changePasswordSucceeded Then
                    Return RedirectToAction("Manage", New With {.Message = ManageMessageId.ChangePasswordSuccess})
                Else
                    ModelState.AddModelError("", "La contraseña actual es incorrecta o la nueva contraseña no es válida.")
                End If
            End If
        Else
            ' El usuario no dispone de contraseña local, por lo que debe quitar todos los errores de validación generados por un
            ' campo OldPassword vacío
            Dim state = ModelState("OldPassword")
            If state IsNot Nothing Then
                state.Errors.Clear()
            End If

            If ModelState.IsValid Then
                Try
                    WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword)
                    Return RedirectToAction("Manage", New With {.Message = ManageMessageId.SetPasswordSuccess})
                Catch e As Exception
                    ModelState.AddModelError("", e)
                End Try
            End If
        End If

        ' Si llegamos a este punto, es porque hay un error y volvemos a mostrar el formulario 
        Return View(model)
    End Function

    '
    ' POST: /Account/ExternalLogin

    <HttpPost()> _
    <AllowAnonymous()> _
    <ValidateAntiForgeryToken()> _
    Public Function ExternalLogin(ByVal provider As String, ByVal returnUrl As String) As ActionResult
        Return New ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", New With {.ReturnUrl = returnUrl}))
    End Function

    '
    ' GET: /Account/ExternalLoginCallback

    <AllowAnonymous()> _
    Public Function ExternalLoginCallback(ByVal returnUrl As String) As ActionResult
        Dim result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", New With {.ReturnUrl = returnUrl}))
        If Not result.IsSuccessful Then
            Return RedirectToAction("ExternalLoginFailure")
        End If

        If OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie:=False) Then
            Return RedirectToLocal(returnUrl)
        End If

        If User.Identity.IsAuthenticated Then
            ' Si el usuario actual ha iniciado sesión, agregue la cuenta nueva
            OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name)
            Return RedirectToLocal(returnUrl)
        Else
            ' El usuario es nuevo, solicitar nombres de pertenencia deseados
            Dim loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId)
            ViewData("ProviderDisplayName") = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName
            ViewData("ReturnUrl") = returnUrl
            Return View("ExternalLoginConfirmation", New RegisterExternalLoginModel With {.UserName = result.UserName, .ExternalLoginData = loginData})
        End If
    End Function

    '
    ' POST: /Account/ExternalLoginConfirmation

    <HttpPost()> _
    <AllowAnonymous()> _
    <ValidateAntiForgeryToken()> _
    Public Function ExternalLoginConfirmation(ByVal model As RegisterExternalLoginModel, ByVal returnUrl As String) As ActionResult
        Dim provider As String = Nothing
        Dim providerUserId As String = Nothing

        If User.Identity.IsAuthenticated OrElse Not OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, provider, providerUserId) Then
            Return RedirectToAction("Administrar")
        End If

        If ModelState.IsValid Then
            ' Insertar un nuevo usuario en la base de datos
            Using db As New UsersContext()
                Dim user = db.UserProfiles.FirstOrDefault(Function(u) u.UserName.ToLower() = model.UserName.ToLower())
                ' Comprobar si el usuario ya existe
                If user Is Nothing Then
                    ' Insertar el nombre en la tabla de perfiles
                    db.UserProfiles.Add(New UserProfile With {.UserName = model.UserName})
                    db.SaveChanges()

                    OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName)
                    OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie:=False)

                    Return RedirectToLocal(returnUrl)
                Else
                    ModelState.AddModelError("UserName", "El nombre de usuario ya existe. Escriba un nombre de usuario diferente.")
                End If
            End Using
        End If

        ViewData("ProviderDisplayName") = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName
        ViewData("ReturnUrl") = returnUrl
        Return View(model)
    End Function

    '
    ' GET: /Account/ExternalLoginFailure

    <AllowAnonymous()> _
    Public Function ExternalLoginFailure() As ActionResult
        Return View()
    End Function

    <AllowAnonymous()> _
    <ChildActionOnly()> _
    Public Function ExternalLoginsList(ByVal returnUrl As String) As ActionResult
        ViewData("ReturnUrl") = returnUrl
        Return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData)
    End Function

    <ChildActionOnly()> _
    Public Function RemoveExternalLogins() As ActionResult
        Dim accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name)
        Dim externalLogins = New List(Of ExternalLogin)()
        For Each account As OAuthAccount In accounts
            Dim clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider)

            externalLogins.Add(New ExternalLogin With { _
                .Provider = account.Provider, _
                .ProviderDisplayName = clientData.DisplayName, _
                .ProviderUserId = account.ProviderUserId _
            })
        Next

        ViewData("ShowRemoveButton") = externalLogins.Count > 1 OrElse OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name))
        Return PartialView("_RemoveExternalLoginsPartial", externalLogins)
    End Function

#Region "Aplicaciones auxiliares"
    Private Function RedirectToLocal(ByVal returnUrl As String) As ActionResult
        If Url.IsLocalUrl(returnUrl) Then
            Return Redirect(returnUrl)
        Else
            Return RedirectToAction("Index", "Home")
        End If
    End Function

    Public Enum ManageMessageId
        ChangePasswordSuccess
        SetPasswordSuccess
        RemoveLoginSuccess
    End Enum

    Friend Class ExternalLoginResult
        Inherits System.Web.Mvc.ActionResult

        Private ReadOnly _provider As String
        Private ReadOnly _returnUrl As String

        Public Sub New(ByVal provider As String, ByVal returnUrl As String)
            _provider = provider
            _returnUrl = returnUrl
        End Sub

        Public ReadOnly Property Provider() As String
            Get
                Return _provider
            End Get
        End Property

        Public ReadOnly Property ReturnUrl() As String
            Get
                Return _returnUrl
            End Get
        End Property

        Public Overrides Sub ExecuteResult(ByVal context As ControllerContext)
            OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl)
        End Sub
    End Class

    Public Function ErrorCodeToString(ByVal createStatus As MembershipCreateStatus) As String
        ' Vaya a http://go.microsoft.com/fwlink/?LinkID=177550 para
        ' obtener una lista completa de códigos de estado.
        Select Case createStatus
            Case MembershipCreateStatus.DuplicateUserName
                Return "El nombre de usuario ya existe. Escriba un nombre de usuario diferente."

            Case MembershipCreateStatus.DuplicateEmail
                Return "Ya existe un nombre de usuario para esa dirección de correo electrónico. Escriba una dirección de correo electrónico diferente."

            Case MembershipCreateStatus.InvalidPassword
                Return "La contraseña especificada no es válida. Escriba un valor de contraseña válido."

            Case MembershipCreateStatus.InvalidEmail
                Return "La dirección de correo electrónico especificada no es válida. Compruebe el valor e inténtelo de nuevo."

            Case MembershipCreateStatus.InvalidAnswer
                Return "La respuesta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo."

            Case MembershipCreateStatus.InvalidQuestion
                Return "La pregunta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo."

            Case MembershipCreateStatus.InvalidUserName
                Return "El nombre de usuario especificado no es válido. Compruebe el valor e inténtelo de nuevo."

            Case MembershipCreateStatus.ProviderError
                Return "El proveedor de autenticación devolvió un error. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema."

            Case MembershipCreateStatus.UserRejected
                Return "La solicitud de creación de usuario se ha cancelado. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema."

            Case Else
                Return "Error desconocido. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema."
        End Select
    End Function
#End Region

End Class
