<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kaydol.aspx.cs" Inherits="_025_Kutuphane.Kaydol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kaydol</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:285px; margin:0 auto; margin-top:50px;">
            <div class="sol-taraf">
                <asp:Panel ID="pnlKayit" runat="server">
                     <div class="hizli-kayit">
                        <div class="ust">
                            Kayıt Ol
                        </div>
                        <div class="alt">
                            <div class="kullanici">
                                <span>Kulanıcı Adı</span>
                                <asp:TextBox ID="txtKullaniciAdi" CssClass="textbox" runat="server"></asp:TextBox><br />
                                <asp:Label ID="lblSonuc" Text="" runat="server" CssClass="lblsonuc"></asp:Label>
                            </div>

                            <div class="sifre">
                                <span>Şifre</span>
                                <asp:TextBox ID="txtSifre" TextMode="Password" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>

                            <div class="sifre">
                                <span>E-mail</span>
                                <asp:TextBox ID="txtEmail" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>

                            <div class="sifre">
                                <span>Ad</span>
                                <asp:TextBox ID="txtAd" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>

                            <div class="sifre">
                                <span>Soyad</span>
                                <asp:TextBox ID="txtSoyad" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>

                            <div class="sifre">
                                <span>Adres</span>
                                <asp:TextBox ID="txtAdres" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>

                            <div>
                                <a href="Anasayfa.aspx" class="btngiris">İptal</a>
                                <asp:Button ID="btnkayit" CssClass="btnkayit" Text="Kaydet" runat="server" OnClick="btnkayit_Click"/>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDurum" runat="server" Style="background-color:#fff; padding:10px;">
                    <asp:Label ID="lblDurum" Text="" runat="server"></asp:Label>
                    <br />
                    <a href="Anasayfa.aspx">Ana Sayfaya git</a>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
