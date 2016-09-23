<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Kitap.aspx.cs" Inherits="_025_Kutuphane.admin.Kitap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="duyuru-wrap">
        <div class="duyuru">
            ISBN:
            <br />
            <asp:TextBox ID="txtISBN" CssClass="txtduyuru" runat="server"></asp:TextBox><br />
            Kitap Adı:
            <br />
            <asp:TextBox ID="txtKitapAdi" CssClass="txtduyuru" runat="server"></asp:TextBox><br />
            Kitap Adedi:
            <br />
            <asp:TextBox ID="txtKitapSayisi" CssClass="txtduyuru" runat="server"></asp:TextBox><br />
            Sayfa Sayısı:
            <br />
            <asp:TextBox ID="txtSayfa" CssClass="txtduyuru" runat="server"></asp:TextBox><br />
            Kitap Özeti:
            <br />
            <asp:TextBox ID="txtOzet" TextMode="multiline" Columns="50" Rows="5" CssClass="txtduyuru" runat="server"></asp:TextBox><br />
            Kitap Türü:
            <br />
            <asp:ListBox ID="listboxTur" CssClass="lstbxduyuru" runat="server" OnSelectedIndexChanged="listboxTur_SelectedIndexChanged"></asp:ListBox><br />
            Kitap Resim url:
            <br />
            <asp:TextBox ID="txtResim" CssClass="txtduyuru" runat="server"></asp:TextBox><br />
            Yazar:
            <br />
            <asp:ListBox ID="listboxYazar" CssClass="lstbxduyuru" runat="server" OnSelectedIndexChanged="listboxYazar_SelectedIndexChanged"></asp:ListBox><br />
            <asp:Panel ID="pnlEkle" runat="server">
                <asp:Button ID="btnekle" CssClass="btnekle" Text="Ekle" runat="server" OnClick="btnekle_Click" />
            </asp:Panel>
            <asp:Panel ID="pnlGunceller" runat="server">
                <asp:Button ID="btnGuncelle" CssClass="btnekle" Text="Guncelle" runat="server" OnClick="btnGuncelle_Click" />
            </asp:Panel>
            <asp:Label ID="lblSonuc" CssClass="lblsonuc" Text="" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
