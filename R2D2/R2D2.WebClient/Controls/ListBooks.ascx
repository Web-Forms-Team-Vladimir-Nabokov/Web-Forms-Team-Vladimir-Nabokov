<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListBooks.ascx.cs" Inherits="R2D2.WebClient.Controls.ListBooks" %>
<div class="panel-body">
    <asp:GridView ID="GvBestReadings" runat="server"
        ItemType="R2D2.Models.Book"
        CssClass="table table-striped table-hover table-bordered table-condensed"
        AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Language">
                <ItemTemplate><div class="img-wrapper"><a runat="server" href='<%#: "~/Public/BookDetails.aspx?bookId=" + Item.Id %>'><img class="img-dims" src="<%# Item.CoverUrl %>" alt="<%# Item.Title %>" runat="server" onerror="this.onload = null; this.src='../Imgs/knowledge.png';" /></a></div></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <a runat="server" href='<%#: "~/Public/BookDetails.aspx?bookId=" + Item.Id %>'><%#: Item.Title %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author">
                <ItemTemplate><a runat="server" style="text-decoration:none;" href='<%#: "~/Public/BookDetails.aspx?bookId=" + Item.Id %>'><%#: Item.Author %></a></ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Published on">
                <ItemTemplate><%#: Item.DatePublished.ToShortDateString() %></ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Rating">
                <ItemTemplate>
                    <asp:Label runat="server" OnPreRender="Rating_PreRender" Text="<%# Item.Rating %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <EmptyDataTemplate>
            <p class="text-center">List is empty.</p>
        </EmptyDataTemplate>
        <HeaderStyle CssClass="info" />
    </asp:GridView>
</div>
