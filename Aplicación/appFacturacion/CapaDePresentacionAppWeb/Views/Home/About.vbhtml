@Code
    ViewData("Title") = "Acerca de"
End Code

<hgroup class="title">
    <h1>@ViewData("Title").</h1>
    <h2>@ViewData("Message")</h2>
</hgroup>

<article>
    <p>
        Use esta área para proporcionar información adicional.
    </p>

    <p>
        Use esta área para proporcionar información adicional.
    </p>

    <p>
        Use esta área para proporcionar información adicional.
    </p>
</article>

<aside>
    <h3>Al lado del título</h3>
    <p>
        Use esta área para proporcionar información adicional.
    </p>
    <ul>
        <li>@Html.ActionLink("Inicio", "Index", "Home")</li>
        <li>@Html.ActionLink("Acerca de", "About", "Home")</li>
        <li>@Html.ActionLink("Contacto", "Contact", "Home")</li>
    </ul>
</aside>