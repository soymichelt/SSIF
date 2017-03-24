@ModelType CapaDePresentacionAppWeb.LocalPasswordModel

<p>
    No dispone de contraseña local para este sitio. Agregue una contraseña
                local para iniciar sesión sin que sea necesario ningún inicio de sesión externo.
</p>

@Using Html.BeginForm("Manage", "Account")
    @Html.AntiForgeryToken()
    @Html.ValidationSummary()

    @<fieldset>
        <legend>Establecer formulario de contraseña</legend>
        <ol>
            <li>
                @Html.LabelFor(Function(m) m.NewPassword)
                @Html.PasswordFor(Function(m) m.NewPassword)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.ConfirmPassword)
                @Html.PasswordFor(Function(m) m.ConfirmPassword)
            </li>
        </ol>
        <input type="submit" value="Establecer contraseña" />
    </fieldset>
End Using
