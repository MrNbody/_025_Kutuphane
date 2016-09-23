<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Kitaplar.aspx.cs" Inherits="_025_Kutuphane.Kitaplar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="kitaplar">
        <asp:Repeater ID="repKitaplar" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="row">
		            <div class="col-md-4">
                        <div class="thumbnail">
                            <a href="Kitap.aspx?kitapID=<%# Eval("kitapID") %>">
                                <img src="<%# Eval("kitapResim") %>" class="imgKitap"/>
                            </a>
                            <div class="caption">
                                <p><a href="Kitap.aspx?kitapID=<%# Eval("kitapID") %>">
                                    <%# Eval("kitapAdi") %></a></p>
                                <a href="Yazar.aspx?yazarID=<%# Eval("yazarID") %>">
                                    <p><%# Eval("yazarAdi") %></p>
                                </a>
                            </div>
                        </div>
		            </div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="row">
		            <div class="col-md-4">
                        <div class="thumbnail">
                            <a href="Kitap.aspx?kitapID=<%# Eval("kitapID") %>">
                                <img src="<%# Eval("kitapResim") %>" class="imgKitap"/>
                            </a>
                            <div class="caption">
                                <p><a href="Kitap.aspx?kitapID=<%# Eval("kitapID") %>">
                                    <%# Eval("kitapAdi") %></a></p>
                                <a href="Yazar.aspx?yazarID=<%# Eval("yazarID") %>">
                                    <p><%# Eval("yazarAdi") %></p>
                                </a>
                            </div>
                        </div>
		            </div>
                </div>
            </AlternatingItemTemplate>
            <FooterTemplate>

            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
