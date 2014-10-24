<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="R2D2.WebClient.Public.Books" %>

<%@ Register Src="~/Controls/BookInfo.ascx" TagPrefix="uc" TagName="BookInfo" %>

<asp:Content ID="ContentPublicBooks" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Select Category: </h3>
                </div>
                <div class="panel-body active">
                    <asp:Repeater ID="RepeaterCategories" runat="server" ItemType="R2D2.Models.Category" SelectMethod="gvListAllCategories_GetData">
                        <ItemTemplate>
                            <%--<span class="badge">11</span>--%>
                            <a runat="server" class="btn btn-default animated fadeInLeft" style="margin: 0px; width: 100%; height: 100%;" href='<%#: "Books.aspx?category="+ Item.Name %>'><%#: Item.Name %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <div class="panel-info">
                <div class="panel-heading">
                    <h3 runat="server" id="catTitle" class="panel-title"></h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4" style="margin-bottom: 20px;">
                            <%--<asp:DataPager ID="DataPager2" runat="server"
                                PagedControlID="ListViewBooks" PageSize="3"
                                QueryStringField="page">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-info" ShowFirstPageButton="true"
                                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                    <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-primary" NumericButtonCssClass="btn btn-info" />
                                    <asp:NextPreviousPagerField ShowLastPageButton="true"
                                        ShowNextPageButton="false" ShowPreviousPageButton="false" ButtonCssClass="btn btn-info" />
                                </Fields>
                            </asp:DataPager>--%>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddSortCriteria" CssClass="form-control">
                                <asp:ListItem Value="Rating">Rating</asp:ListItem>
                                <asp:ListItem Value="DatePublished">Date Published</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-2">
                            <asp:DropDownList runat="server" ID="ddSortDirection" CssClass="form-control">
                                <asp:ListItem Selected="True" Value="ASC">ASC</asp:ListItem>
                                <asp:ListItem Value="DESC">DESC</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="SortButton" Text="Sort" CssClass="btn btn-primary" OnClick="SortButton_Click" runat="server" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <asp:ListView ID="ListViewBooks" runat="server"
                            ItemType="R2D2.Models.Book" SelectMethod="gvListAllBooks_GetData">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                            </LayoutTemplate>

                            <ItemTemplate>
                                <div class="col-md-4">
                                    <uc:BookInfo runat="server" ID="BookInfo"
                                        Title='<%# ""+Item.Title %>'
                                        Author='<%# ""+Item.Author %>'
                                        CoverUrl='<%#: Item.CoverUrl %>'
                                        Rating='<%#: Item.Rating %>'
                                        Target='<%# "~/Public/BookDetails.aspx?bookId=" + Item.Id %>' />
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <div class="row">
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
    </div>
</asp:Content>
