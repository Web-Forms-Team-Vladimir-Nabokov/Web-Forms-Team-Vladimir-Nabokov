<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Admin.master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="R2D2.WebClient.Administration.Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="jumbotron">
        <h3>Upload your epub files here:</h3>
        <asp:FileUpload ID="FileUploadControl" runat="server" />
        <br />
        <div>
            <span>Choose book's category: </span>
            <asp:CheckBoxList CssClass="chl-box" runat="server" ID="chlCategories" DataTextField="Name" DataValueField="ID" ItemType="R2D2.Models.Category" SelectMethod="DdlCategories_GetData" RepeatColumns="5" RepeatDirection="Vertical"></asp:CheckBoxList>
        </div>
        <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" CssClass="btn btn-md btn-primary" />
        <br />
        <br />
        <asp:Label runat="server" ID="StatusLabel" Text="" />
    </div>
</asp:Content>
