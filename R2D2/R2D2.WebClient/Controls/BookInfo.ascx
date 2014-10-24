<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookInfo.ascx.cs" Inherits="R2D2.WebClient.Controls.BookInfo" %>
<div class="panel panel-warning">
    <div class="panel-heading">
        <h3 runat="server" id="bookTitle" cssclass="panel-title">
            <%#: this.Title %>
        </h3>
    </div>
    <div class="panel-body">
        <asp:ImageButton ImageUrl="<%#: this.CoverUrl %>" alt="<%# this.Title %>" onerror="this.onload = null; this.src='../Imgs/knowledge.png';" ID="image" runat="server" ViewStateMode="Enabled" OnClick="image_Click" CssClass="book-thumbnail" />
        <div class="book-details">
            <hr />
            <strong>Author:</strong> <%#: this.Author %>
            <br />
            <strong>Rating: </strong>
            <asp:Label runat="server" OnPreRender="Rating_PreRender" Text="<%# this.Rating %>"></asp:Label>
        </div>
    </div>
</div>
