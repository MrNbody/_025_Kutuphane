<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Kitap.aspx.cs" Inherits="_025_Kutuphane.Kitap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Kitap">
        <div class="row">
		    <div class="col-md-4">
                <div class="thumbnail">
                    <asp:Image ID="imgKitap" CssClass="imgKitap" runat="server"/>
                    <div class="caption">
                        <p><asp:Label ID="lblKitapAdi" runat="server"></asp:Label></p>
                        <p><asp:Label ID="lblkitapYazar" runat="server"></asp:Label></p>
                        <p><asp:DropDownList ID="listSure" runat="server">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                           </asp:DropDownList> Gün
                            <asp:Button ID="btnAl" CssClass="btn btn-primary" runat="server" OnClick="btnAl_Click" Text="Ödünç Al"/></p>
                    </div>
                </div>
		    </div>
        </div>
        <div class="row-sag">
            <div class="ust">
                <p><asp:Label ID="lblOzetSag" runat="server"></asp:Label></p>
            </div>
            <div class="alt">
                <p><asp:Label ID="lblisbn" runat="server"></asp:Label></p>
                <p><asp:Label ID="lblsayfa" runat="server"></asp:Label></p>
            </div>
        </div>
    </div>
    <div class="mesaj">
        
                <asp:Label ID="lblMesaj" runat="server"></asp:Label>
    </div>





</asp:Content>
