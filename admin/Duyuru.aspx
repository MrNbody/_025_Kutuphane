<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Duyuru.aspx.cs" Inherits="_025_Kutuphane.admin.Duyuru" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="duyuru-wrap">
        <div class="duyuru">
            Duyuru: <br /><asp:TextBox ID="txtDuyuru" TextMode="multiline" Columns="50" Rows="5" CssClass="txtduyuru" runat="server"></asp:TextBox><br />
            <asp:Panel ID="pnlEkle" runat="server">
                <asp:Button ID="btnekle" CssClass="btnekle" Text="Ekle" runat="server" OnClick="btnekle_Click"/>
            </asp:Panel>
            <asp:Panel ID="pnlGuncelle" runat="server">
                <asp:Button ID="btnGuncelle" CssClass="btnekle" Text="Guncelle" runat="server" OnClick="btnGuncelle_Click"/>
            </asp:Panel>
            <asp:Label ID="lblSonuc" CssClass="lblsonuc" Text="" runat="server"></asp:Label>

        </div>
        <div class="alt">
            <asp:ListView ID="listDuyuru" runat="server">
                <ItemTemplate>
                    <div class="duyuru-wrap">
                        <a href="Duyuru.aspx?duyuruID=<%#Eval("duyuruID") %>">
                            <asp:Label Text='<%#Eval("duyuruAciklama") %>' runat="server"></asp:Label>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>
