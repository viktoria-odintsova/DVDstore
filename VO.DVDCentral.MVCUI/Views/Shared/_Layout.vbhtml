﻿<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="#">DVD Central</a>
        <button class="navbar-toggler"
                type="button"
                data-toggle="collapse"
                data-target="#navbarNav"
                aria-controls="navbarNav"
                aria-expanded="false"
                aria-label="Togger Navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="navbar-collapse collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" runat="server" href="~/">Home</a>

                </li>
                <li class="nav-item">
                    <a class="nav-link" runat="server" href="~/About">About</a>

                </li>
                <li class="nav-item">
                    <a class="nav-link" runat="server" href="~/Contact">Contact</a>

                </li>
                <li class="nav-item">
                    <a class="nav-link" runat="server" href="~/Movies">Movies</a>

                </li>
                <li class="nav-item">
                    <a class="nav-link" runat="server" href="~/Directors">Directors</a>

                </li>
                <li class="nav-item">
                    <a class="nav-link" runat="server" href="~/Ratings">Ratings</a>

                </li>
                <li class="nav-item">
                    <a class="nav-link" runat="server" href="~/Genres">Genres</a>

                </li>
                <li class="nav-item">
                    <a class="nav-link" runat="server" href="~/Orders">Orders</a>

                </li>
                <li class="nav-item">
                    <a class="nav-link" runat="server" href="~/Formats">Formats</a>

                </li>
            </ul>
        </div>
    </nav>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
