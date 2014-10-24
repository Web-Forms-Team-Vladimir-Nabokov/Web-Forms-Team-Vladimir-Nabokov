<%@ Page Title="Edit book" Language="C#" MasterPageFile="~/Administration/Admin.master" AutoEventWireup="true" CodeBehind="EditBook.aspx.cs" Inherits="R2D2.WebClient.Administration.EditBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="container">
        <h2>Edit book:</h2>
        <div class="container">
            <asp:FormView runat="server" ID="FvEdit" RenderOuterTable="false" ItemType="R2D2.Models.Book" DefaultMode="Edit" SelectMethod="FvEdit_GetItem" UpdateMethod="FvEdit_UpdateItem" DataKeyNames="Id">
                <EditItemTemplate>
                    <div class="row animated fadeIn">
                        <div class="form-group col-md-7">
                            Title:
                            <asp:TextBox CssClass="form-control col-md-7" runat="server" ID="Title" Text="<%#: BindItem.Title %>" />
                        </div>
                        <div class="form-group col-md-7">
                            Author:
                            <asp:TextBox CssClass="form-control col-md-7" runat="server" ID="Author" Text="<%#: BindItem.Author %>" />
                        </div>
                        <div class="form-group col-md-7">
                            Cover URL:
                            <asp:TextBox CssClass="form-control col-md-7" runat="server" ID="BookUrl" Text="<%#: BindItem.CoverUrl %>" />
                        </div>
                        <div class="form-group col-md-7">
                            DatePublished:
                            <asp:TextBox CssClass="form-control col-md-7" runat="server" ID="DatePublished" Text="<%#: BindItem.DatePublished %>" />
                        </div>
                        <div class="form-group col-md-7">
                            Description:
                            <asp:TextBox CssClass="form-control col-md-7" Rows="7" runat="server" ID="Description" TextMode="MultiLine" Text="<%#: BindItem.Description %>" />
                        </div>
                        <div class="form-group col-md-7">
                            Language:
                            <asp:TextBox CssClass="form-control col-md-7" runat="server" ID="Language" Text="<%#: BindItem.Language %>" />
                        </div>
                        <div class="form-group col-md-10">
                            <span>Choose book's category: </span>
                            <asp:CheckBoxList runat="server" ID="chlCategories"
                                DataTextField="Name" DataValueField="ID"
                                ItemType="R2D2.Models.Category"
                                SelectMethod="DdlCategories_GetData"
                                OnPreRender="chlCategories_PreRender"
                                CssClass="chl-box"
                                RepeatColumns="5" RepeatDirection="Vertical">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                    <div class="form-group row animated fadeInUp">
                        <asp:Button CssClass="btn btn-primary" Text="Save" CommandName="Update" runat="server" />
                        <asp:Button CssClass="btn btn-danger" Text="Cancel" OnClick="Cancel_Click" runat="server" />
                    </div>
                </EditItemTemplate>
            </asp:FormView>
        </div>
    </div>
</asp:Content>
