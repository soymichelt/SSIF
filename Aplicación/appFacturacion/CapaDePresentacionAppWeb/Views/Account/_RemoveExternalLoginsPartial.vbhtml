@ModelType ICollection(Of CapaDePresentacionAppWeb.ExternalLogin)

@If Model.Count > 0 Then
    @<h3>Inicios de sesión externos registrados</h3>
    @<table>
        <tbody>
        @For Each externalLogin As CapaDePresentacionAppWeb.ExternalLogin In Model
            @<tr>
                <td>@externalLogin.ProviderDisplayName</td>
                <td>
                    @If ViewData("ShowRemoveButton") Then
                            Using Html.BeginForm("Disassociate", "Account")
                            @Html.AntiForgeryToken()
                            @<fieldset>
                                @Html.Hidden("provider", externalLogin.Provider)
                                @Html.Hidden("providerUserId", externalLogin.ProviderUserId)
                                <input type="submit" value="Quitar" title="Quitar esta credencial de @externalLogin.ProviderDisplayName de su cuenta" />
                            </fieldset>
                        End Using
                    Else
                        @: &nbsp;
                    End If
                </td>
            </tr>
        Next
        </tbody>
    </table>
End If