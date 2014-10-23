<%@ Page Title="Sitemap" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sitemap.aspx.cs" Inherits="R2D2.WebClient.Public.Sitemap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>ReadToday2.0 Sitemap</h1>
    <hr />
    <asp:TreeView ShowLines="true" ExpandDepth="1" ID="TreeViewSitePages" runat="server" 
        DataSourceID="SiteMapDataSource" SkipLinkText=""></asp:TreeView>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" />
</asp:Content>
