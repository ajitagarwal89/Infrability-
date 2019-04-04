<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign in to your account</title>
    <link href="infra_ui/css/main.css" rel="stylesheet" />
    <link href="infra_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="infra_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="infra_components/bootstrap/dist/css/animations.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet" />
</head>
<body style="margin: 0;">

    <form id="LoginForm" runat="server">
        <div class="leftdiv">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-4">
                        <h1 class="form-signin-heading appname slideUp">
                            <asp:Literal runat="server" ID="ltrHamla" Text="<%$ Resources:GlobalResource, ltrHamla%>"></asp:Literal>
                        </h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-sm-12">
                        <h4 class="form-signin-heading loginfield slideRight">
                            <asp:Label runat="server" ID="lblDayTime"></asp:Label>,
                            <br />
                            <br />
                            <asp:Literal runat="server" ID="ltrSignInContinue" Text="<%$ Resources:GlobalResource, ltrSignInContinue%>"></asp:Literal>
                        </h4>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-sm-8 col-xs-8">
                        <div class="icon-addon ">
                            <asp:TextBox runat="server" ID="txtUserName" type="text" CssClass="form-control" Style="margin-bottom: 10px;" placeholder="<%$ Resources:GlobalResource, lblUserName%>" required autofocus></asp:TextBox>
                            <label for="username" class="fa fa-user" rel="tooltip" title="username"></label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-sm-8 col-xs-8">
                        <div class="icon-addon addon-md">
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="password" CssClass="form-control" placeholder="<%$ Resources:GlobalResource, lblPassword%>" required></asp:TextBox>
                            <label for="password" class="fa fa-ellipsis-h" rel="tooltip" title="password"></label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="loginfield col-md-4 col-sm-12">
                        <label class="switch" style="margin-top: 20px;">
                            <asp:CheckBox ID="chkSignedIn" runat="server" />
                            <div class="slider round"><span class="yesno"><i class="fa fa-close"></i>&nbsp;&nbsp;&nbsp;<i class="fa fa-check"></i></span></div>

                        </label>
                        <span class="signintext">
                            <asp:Literal runat="server" ID="ltrRememberMe" Text="<%$ Resources:GlobalResource, ltrRememberMe%>"></asp:Literal></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-sm-12">
                        <asp:Button runat="server" ID="btnLogin" class="btn btn-md btn-primary" Text="<%$ Resources:GlobalResource, btnLogin%>" OnClick="btnLogin_Click"></asp:Button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-sm-12 loginfield">
                        <a href="#">
                            <h5>
                                <asp:Literal runat="server" ID="ltrForgotPassword" Text="<%$ Resources:GlobalResource, ltrForgotPassword%>"></asp:Literal>
                            </h5>
                        </a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-sm-12">
                        <asp:CustomValidator ID="cvSignIn" runat="server" ErrorMessage="<%$ Resources:GlobalResource, cvSignIn %>" Display="Dynamic" CssClass="validator"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvLockOut" runat="server" CssClass="validator" Display="Dynamic" ErrorMessage="<%$ Resources:GlobalResource, cvLockOut%> "></asp:CustomValidator>
                        <asp:CustomValidator ID="cvTrialExpired" runat="server" CssClass="validator" Display="Dynamic" ErrorMessage="<%$ Resources:GlobalResource, cvTrialExpired%>"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvError" runat="server" CssClass="validator" Display="Dynamic" ErrorMessage="<%$ Resources:GlobalResource, cvErrorLogin %>"></asp:CustomValidator>
                    </div>
                </div>
            </div>

        </div>

        <div class="rightdiv" runat="server" id="loginrightdiv">
        </div>
    </form>
</body>
</html>
