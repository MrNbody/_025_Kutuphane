<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="_025_Kutuphane.admin.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="admin">
                    <div class="kullanici">
                        <span>Kulanıcı Adı</span>
                        <asp:TextBox ID="txtKullaniciAdi" CssClass="textbox" runat="server"></asp:TextBox>
                    </div>

                    <div class="sifre">
                        <span>Şifre</span>
                        <asp:TextBox ID="txtSifre" TextMode="Password" CssClass="textbox" runat="server"></asp:TextBox>
                    </div>

                    <div class="giris">
                        <asp:Button ID="btngiris" CssClass="btngiris" Text="Giriş" runat="server" OnClick="btngiris_Click"/>
                        <asp:Label ID="lblSonuc" CssClass="lblsonuc" Text="" runat="server"></asp:Label>
                    </div>
                </div>
    </form>
</body>
</html>
