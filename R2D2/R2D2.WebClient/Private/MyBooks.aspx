<%@ Page Title="My Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyBooks.aspx.cs" Inherits="R2D2.WebClient.Private.MyBooks" %>

<asp:Content ID="ContentMyBooks" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h3 class="panel-title">My books</h3>
            <div class="row">
                <%-- Paging! --%>
                <div class="col-md-12">
                    <asp:DataPager ID="DataPagerMyBooks" runat="server"
                        PagedControlID="ListViewBooks" PageSize="12"
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
            </div>
            <%-- Paging END --%>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:ListView ID="ListViewBooks" runat="server"
                        ItemType="R2D2.Models.Book"
                        SelectMethod="ListViewBooks_GetData">
                        <LayoutTemplate>
                            <div class="list-group">
                                <div runat="server" id="itemPlaceholder"></div>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div runat="server" class="list-group-item col-md-4">
                                <div class="row">
                                    <div class="col-md-6">
                                        <a runat="server"
                                            href='<%#: "~/Public/BookDetails.aspx?bookId=" + Item.Id %>'
                                            class="list-group-item-heading">
                                            <p class="list-group-item-header"><%#: Item.Title %></p>
                                            <div class="thumbnail">
                                                <img src="<%# Item.CoverUrl %>" runat="server" 
                                                    alt="<%#: Item.Title %>" />
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-md-6">
                                        <p class="list-group-item-text">
                                            <strong>Author:</strong> <%#: Item.Author %>
                                        </p>
                                        <p class="list-group-item-text">
                                            <strong>Date:</strong> <%#: Item.DatePublished.ToString("MMMM dd, yyyy") %>
                                        </p>
                                        <p class="list-group-item-text">
                                            <strong>Rating: </strong>
                                            <asp:Label runat="server" 
                                                OnPreRender="Rating_PreRender" 
                                                Text="<%# Item.Rating %>">
                                            </asp:Label>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
