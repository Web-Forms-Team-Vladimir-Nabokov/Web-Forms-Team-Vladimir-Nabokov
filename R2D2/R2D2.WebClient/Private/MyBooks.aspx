<%@ Page Title="My Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyBooks.aspx.cs" Inherits="R2D2.WebClient.Private.MyBooks" %>

<asp:Content ID="ContentMyBooks" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h3>My books</h3>
            <div class="row">
                <%-- Paging! --%>
                <div class="col-md-12">
                    <asp:DataPager ID="DataPagerMyBooks" runat="server"
                        PagedControlID="ListViewBooks" PageSize="6"
                        QueryStringField="page">
                        <Fields>
                            <asp:NextPreviousPagerField
                                ButtonCssClass="btn btn-sm btn-info"
                                ShowFirstPageButton="true"
                                ShowNextPageButton="false"
                                ShowPreviousPageButton="false" />
                            <asp:NumericPagerField
                                CurrentPageLabelCssClass="btn btn-sm btn-primary"
                                NumericButtonCssClass="btn btn-sm btn-info" />
                            <asp:NextPreviousPagerField
                                ShowLastPageButton="true"
                                ShowNextPageButton="false"
                                ShowPreviousPageButton="false"
                                ButtonCssClass="btn btn-sm btn-info" />
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
                                                <img src="<%# Item.CoverUrl  %>" id="coverUrl" runat="server" alt="<%# Item.Title  %>" onerror="this.onload = null; this.src='../Imgs/knowledge.png';" />
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-md-6">
                                        <strong>Author:</strong>
                                        <p class="list-group-item-text">
                                            <%#: Item.Author %>
                                        </p>
                                        <strong>Date:</strong>
                                        <p class="list-group-item-text">
                                            <%#: Item.DatePublished.ToString("MMMM dd, yyyy") %>
                                        </p>
                                        <strong>Rating: </strong>
                                        <p class="list-group-item-text">
                                            <asp:Label runat="server"
                                                OnPreRender="Rating_PreRender"
                                                Text="<%# Item.Rating %>">
                                            </asp:Label>
                                        </p>
                                        <strong>Your rating: 
                                                <%# Item.Users
                                                .First(b => b.ApplicationUserId == this.User.Identity.GetUserId())
                                                .Rating %>
                                        </strong>
                                        <p class="list-group-item-text">
                                            <asp:Label runat="server">
                                                <asp:LinkButton runat="server"
                                                    OnCommand="btnRate_Command"
                                                    CommandArgument='<%# Item.Id + "," + 1 %>'>                                                 <span class="glyphicon glyphicon-star" />
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server"
                                                    OnCommand="btnRate_Command"
                                                    CommandArgument='<%# Item.Id + "," + 2 %>'>                                                 <span class="glyphicon glyphicon-star" />
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server"
                                                    OnCommand="btnRate_Command"
                                                    CommandArgument='<%# Item.Id + "," + 3 %>'>                                                 <span class="glyphicon glyphicon-star" />
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server"
                                                    OnCommand="btnRate_Command"
                                                    CommandArgument='<%# Item.Id + "," + 4 %>'>                                                 <span class="glyphicon glyphicon-star" />
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server"
                                                    OnCommand="btnRate_Command"
                                                    CommandArgument='<%# Item.Id + "," + 5 %>'>                                                 <span class="glyphicon glyphicon-star" />
                                                </asp:LinkButton>
                                            </asp:Label>
                                        </p>
                                        <br />
                                        <asp:LinkButton runat="server" 
                                            ID="LbReadCurrent"
                                            CommandName="ReadCurrent"
                                            CommandArgument="<%# Item.Id %>"
                                            OnCommand="LbReadCurrent_Command"
                                            CssClass="btn btn-sm btn-primary">Read</asp:LinkButton>
                                        <asp:Button ID="btnRemoveBook" runat="server"
                                            CssClass="btn btn-sm btn-danger"
                                            Text="Remove"
                                            OnCommand="btnRemoveBook_Command"
                                            CommandArgument="<%# Item.Id %>" />
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
