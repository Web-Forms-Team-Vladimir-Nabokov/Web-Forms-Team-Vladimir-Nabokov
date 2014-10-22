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
                    <div class="col-md-12" style="margin-bottom: 20px;">
                        <asp:DataPager ID="DataPager2" runat="server"
                            PagedControlID="ListViewBooks" PageSize="3"
                            QueryStringField="page">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonCssClass="btn btn-info" ShowFirstPageButton="true"
                                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-primary" NumericButtonCssClass="btn btn-info" />
                                <asp:NextPreviousPagerField ShowLastPageButton="true"
                                    ShowNextPageButton="false" ShowPreviousPageButton="false" ButtonCssClass="btn btn-info" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                    <asp:ListView ID="ListViewBooks" runat="server"
                        ItemType="R2D2.Models.Book" SelectMethod="gvListAllBooks_GetData">
                        <LayoutTemplate>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </LayoutTemplate>

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
                                    <strong>Rating: </strong><asp:Label runat="server" OnPreRender="Rating_PreRender" Text="<%# Item.Rating %>"></asp:Label>
                                  </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>

                    <%-- Paging! --%>
                    <div class="col-md-12">
                        <asp:DataPager ID="DataPager1" runat="server"
                            PagedControlID="ListViewBooks" PageSize="3"
                            QueryStringField="page">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonCssClass="btn btn-info" ShowFirstPageButton="true"
                                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-primary" NumericButtonCssClass="btn btn-info" />
                                <asp:NextPreviousPagerField ShowLastPageButton="true"
                                    ShowNextPageButton="false" ShowPreviousPageButton="false" ButtonCssClass="btn btn-info" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                    <%-- Paging END --%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
