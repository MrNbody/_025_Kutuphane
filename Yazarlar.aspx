<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Yazarlar.aspx.cs" Inherits="_025_Kutuphane.Yazarlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="yazarlar">
        <div class="yazar">
                <asp:ListView ID="listYazar" runat="server" GroupItemCount="3">
                    <LayoutTemplate>
                        <table>
                            <asp:PlaceHolder ID="GroupPlaceHolder" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                       <tr>
                           <asp:PlaceHolder ID="ItemPlaceHolder" runat="server">
                           </asp:PlaceHolder>
                       </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td style="padding-left:40px; padding-top:15px; text-align:center">
                            <a href="Yazar.aspx?yazarID=<%#Eval("yazarID") %>"><%#Eval("yazarAdi") %></a>
                        </td>
                    </ItemTemplate>
                </asp:ListView>
        </div>
    </div>
</asp:Content>
