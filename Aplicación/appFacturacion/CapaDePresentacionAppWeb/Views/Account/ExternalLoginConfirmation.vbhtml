@ModelType CapaDePresentacionAppWeb.RegisterExternalLoginModel
@Code
    ViewData("Title") = "Registrarse"
End Code

<hgroup class="title">
    <h1>@ViewData("Title").</h1>
    <h2>Asociar su cuenta de @ViewData("ProviderDisplayName").</h2>
</hgroup>

@Using Html.BeginForm("ExternalLoginConfirmation", "Account", New With {.ReturnUrl = ViewData("ReturnUrl")})
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(true)

    @<fieldset>
        <legend>Formulario de asociación</legend>
        <p>
            Se ha autenticado correctamente con <strong>@ViewData("ProviderDisplayName")</strong>.
            Escriba un nombre de usuario para este sitio y haga clic en el botón Confirmar para finalizar
            el inicio de sesión.
        </p>
        <ol>
            <li class="name">
                @Html.LabelFor(Function(m) m.UserName)
                @Html.TextBoxFor(Function(m) m.UserName)
                @Html.ValidationMessageFor(Function(m) m.UserName)
            </li>
        </ol>
        @Html.HiddenFor(Function(m) m.ExternalLoginData)
        <input type="submit" value="Registrarse" />
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
