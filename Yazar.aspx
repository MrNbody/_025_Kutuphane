<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Yazar.aspx.cs" Inherits="_025_Kutuphane.Yazar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Kitap">
        <div class="row">
		    <div class="col-md-4">
                <div class="thumbnail">
                    <asp:Image ID="imgKitap" CssClass="imgKitap" runat="server"/>
                    <div class="caption">
                        <h3><asp:Label ID="lblYazarAdi" runat="server"></asp:Label></h3>
                        <p><asp:Label ID="lblYazarDogum" runat="server"></asp:Label></p>
                    </div>
                </div>
		    </div>
        </div>
        <div class="row-sag">
                <asp:Label ID="lblBaslik" runat="server"></asp:Label>
                <p><asp:Label ID="lblOzet" runat="server" CssClass="lblozet"></asp:Label></p>
        </div>
    </div>


</asp:Content>
