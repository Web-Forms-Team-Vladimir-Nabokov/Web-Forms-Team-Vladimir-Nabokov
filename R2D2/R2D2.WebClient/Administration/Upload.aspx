<%@ Page Title="Upload books" Language="C#" MasterPageFile="~/Administration/Admin.master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="R2D2.WebClient.Administration.Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="jumbotron">
        <h3>Upload your epub files here:</h3>
        <asp:FileUpload ID="FileUploadControl" runat="server" />
        <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />
        <br />
        <br />
        <asp:Label runat="server" ID="StatusLabel" Text="" />
    </div>
</asp:Content>
