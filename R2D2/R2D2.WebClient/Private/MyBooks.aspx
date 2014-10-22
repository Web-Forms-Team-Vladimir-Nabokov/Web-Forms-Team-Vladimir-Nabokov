<%@ Page Title="My Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyBooks.aspx.cs" Inherits="R2D2.WebClient.Private.MyBooks" %>

<asp:Content ID="ContentMyBooks" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1>My books</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="RepeaterMyBooks" runat="server"
                ItemType="R2D2.Models.Book"
                SelectMethod="RepeaterMyBooks_GetData">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li class="pull-right">
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                <h3 class="panel-title"><a href="#"><%#: Item.Title %></a></h3>
                            </div>
                            <div class="panel-body">
                                <img class="book-thumbnail" src="<%# Item.CoverUrl %>" alt="<%#: Item.Title %>" />
                                <hr />
                                <p><strong>Author:</strong> <%#: Item.Author %></p>
                                <p><strong>Date:</strong> <%#: Item.DatePublished.ToString("MMMM dd, yyyy") %></p>
                                <p>
                                    <strong>Rating:</strong>
                                    <img src="../Imgs/rating-star-full.png" alt="" />
                                </p>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>

                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
