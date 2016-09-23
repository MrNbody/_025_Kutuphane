<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Yazar.aspx.cs" Inherits="_025_Kutuphane.admin.Yazar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
            <div class="duyuru-wrap">
                <div class="duyuru">
                    Adı: <br /><asp:TextBox ID="txtYazarAdi" CssClass="txtduyuru" runat="server"></asp:TextBox><br />
                    Doğum: <br /><asp:TextBox ID="txtYazarDogum" CssClass="txtduyuru" runat="server"></asp:TextBox><br />
                    Hayat Özeti: <br />
                    <asp:TextBox ID="txtYazarOzet" TextMode="multiline" Columns="50" Rows="5" CssClass="txtduyuru" runat="server">
                                       </asp:TextBox><br />
                    Yazar Resim url: <br /><asp:TextBox ID="txtYazarResim" CssClass="txtduyuru" runat="server"></asp:TextBox><br />
                    <asp:Panel ID="pnlEkle" runat="server">
                        <asp:Button ID="btnekle" CssClass="btnekle" Text="Ekle" runat="server" OnClick="btnekle_Click"/>
                    </asp:Panel>
                    <asp:Panel ID="pnlGuncelle" runat="server">
                        <asp:Button ID="btnGuncelle" CssClass="btnekle" Text="Guncelle" runat="server" OnClick="btnGuncelle_Click" />
                    </asp:Panel>
                    <asp:Label ID="lblSonuc" CssClass="lblsonuc" Text="" runat="server"></asp:Label>
                </div>
            </div>
</asp:Content>
