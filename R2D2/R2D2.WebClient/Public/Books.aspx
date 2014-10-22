<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="R2D2.WebClient.Public.Books" %>

<asp:Content ID="ContentPublicBooks" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
<div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Select Category: </h3>
                </div>
                <div class="panel-body">
                    <ul class="list-group">
                    <asp:Repeater ID="RepeaterCategories" runat="server" ItemType="R2D2.Models.Category" SelectMethod="gvListAllCategories_GetData">
                        <ItemTemplate>
                            <li class="list-group-item">
                            <%--<span class="badge">11</span>--%>
                                <a runat="server" class="btn btn-info" style="margin: 0px; width: 100%; height: 100%;" href='<%#: "Books.aspx?category="+ Item.Name %>'><%#: Item.Name %></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <div class="panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Category: Fantasy</h3>
                </div>
                <div class="panel-body">
                    <asp:Repeater ID="BooksRepeater" runat="server" ItemType="R2D2.Models.Book" SelectMethod="gvListAllBooks_GetData">
                        <ItemTemplate>
                            <div class="col-md-4">
                                <div class="panel panel-warning">
                                  <div class="panel-heading">
                                    <h3 class="panel-title">
                                        <a runat="server" href='<%#: "~/Public/BookDetails.aspx?bookId=" + Item.Id %>'>
                                            <%#: Item.Title %>
                                        </a>
                                    </h3>
                                  </div>
                                  <div class="panel-body">
                                      <img class="book-thumbnail" src="<%# Item.CoverUrl %>" id="coverUrl" runat="server" alt="<%#: Item.Title %>" />
                                    <hr />
                                    <strong>Author:</strong> <%#: Item.Author %><br />
                                    <strong>Date:</strong> <%#: Item.DatePublished.ToString("MMMM dd, yyyy") %><br />
                                      <%-- For the rating just write simple for loop for the rating count --%>
                                    <strong>Rating: </strong><asp:Label runat="server" OnPreRender="Rating_PreRender" Text="<%# Item.Rating %>"></asp:Label>
                                  </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
