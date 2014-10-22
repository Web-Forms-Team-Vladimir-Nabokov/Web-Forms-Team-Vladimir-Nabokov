<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="R2D2.WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="jumbotron">
                <div class="row">
                    <div class="col-md-6 text-center">
                        <h1>Boost your knowledge</h1>
                    </div>
                    <div class="col-md-6 text-center">
                        <img src="Imgs/knowledge.png" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Best readings</h3>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvBestReadings" runat="server"
                        ItemType="R2D2.Models.Book"
                        SelectMethod="gvBestReadings_GetData"
                        CssClass="table table-striped table-hover table-bordered table-condensed"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Title">
                                <ItemTemplate>
                                    <a runat="server" href='<%#: "~/Public/BookDetails.aspx?bookId=" + Item.Id %>'><%#: Item.Title %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Author">
                                <ItemTemplate><%#: Item.Author %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Language">
                                <ItemTemplate><%#: Item.Language %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Published on">
                                <ItemTemplate><%#: Item.DatePublished.ToShortDateString() %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rating">
                                <ItemTemplate>
                                    <asp:Label runat="server" OnPreRender="Rating_PreRender" Text="<%#: Item.Rating %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <EmptyDataTemplate>
                            <p class="text-center">List is empty.</p>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="info" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Latest books</h3>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvLatestBooks" runat="server"
                        ItemType="R2D2.Models.Book"
                        SelectMethod="gvLatestBooks_GetData"
                        CssClass="table table-striped table-hover table-bordered table-condensed"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Title">
                                <ItemTemplate>
                                    <a runat="server" href='<%#: "~/Public/BookDetails.aspx?bookId=" + Item.Id %>'><%#: Item.Title %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Author">
                                <ItemTemplate><%#: Item.Author %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Language">
                                <ItemTemplate><%#: Item.Language %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Published on">
                                <ItemTemplate><%#: Item.DatePublished.ToShortDateString() %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rating">
                                <ItemTemplate><%# Item.Rating %></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <EmptyDataTemplate>
                            <p class="text-center">List is empty.</p>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="info" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
