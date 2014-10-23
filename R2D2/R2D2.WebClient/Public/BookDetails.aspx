<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="R2D2.WebClient.Public.BookDetails" %>

<asp:Content ID="ContentBookDetails" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="well">
                <asp:FormView ID="fvBook" runat="server"
                    ItemType="R2D2.Models.Book"
                    SelectMethod="fvBook_GetItem">
                    <ItemTemplate>
                        <h1><%#: Item.Title %></h1>
                        <p>by <strong><%#: Item.Author %></strong></p>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="thumbnail">
                                    <img src="<%# Item.CoverUrl  %>" id="coverUrl" runat="server" alt="<%# Item.Title  %>"  onerror="this.onload = null; this.src='../Imgs/knowledge.png';"/>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <p>Published on: <%#: Item.DatePublished.ToShortDateString() %></p>
                                <p>Language: <%#: Item.Language %></p>
                                <p>Rating: <asp:Label runat="server" OnPreRender="Rating_PreRender" Text="<%# Item.Rating %>"></asp:Label>
                                </p>
                                <p>
                                    <strong><%#: string.IsNullOrWhiteSpace(Item.Description) ? "No description" : Item.Description %></strong>
                                </p>
                                <asp:LinkButton ID="btnRead" runat="server"
                                    PostBackUrl='<%#: "~/Private/ReadBook.aspx?bookId=" + Item.Id %>'
                                    CssClass="btn btn-primary">Read</asp:LinkButton>
                                <% if(this.User.Identity.IsAuthenticated) { %>
                                    <asp:Button ID="btnAddToBookshelf" runat="server"
                                        CssClass="btn btn-info"
                                        OnClick="btnAddToBookshelf_Click"
                                        Text="Add to my shelf" />
                                <% } %>
                            </div>
                        </div>
                    </ItemTemplate>

                    <EmptyDataTemplate>
                        <p class="text-warning">Book was not found.</p>
                    </EmptyDataTemplate>
                </asp:FormView>
            </div>
        </div>
    </div>
</asp:Content>
