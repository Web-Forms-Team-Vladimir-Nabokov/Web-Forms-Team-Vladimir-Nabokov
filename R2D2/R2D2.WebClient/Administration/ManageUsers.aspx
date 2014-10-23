<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Admin.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="R2D2.WebClient.Administration.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="container">
        <div class="form-group col-lg-6">
            <asp:TextBox CssClass="form-control" runat="server" ID="TbSearch" OnTextChanged="TbSearch_TextChanged" TextMode="Search" AutoPostBack="true"></asp:TextBox>
        </div>
        <div class="form-group col-lg-12">
            <asp:ListView runat="server" ID="LvUsers" ItemType="R2D2.Models.ApplicationUser" SelectMethod="LvUsers_GetData">
                <LayoutTemplate>
                    <table class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>Username</th>
                                <th>Role</th>
                                <th>Change Role</th>
                            </tr>
                        </thead>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>

                <ItemSeparatorTemplate>
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Item.UserName %></td>
                        <td><%# Item.Roles.Count() == 1 ? "Admin" : "User" %></td>
                        <td>
                            <asp:Button runat="server" ID="Btn" CssClass="btn btn-info" Text='<%# Item.Roles.Count() == 0 ? "Promote to Admin" : "Demote to User" %>' CommandName="ChangeUserRole" OnCommand="Btn_Command" CommandArgument="<%# Item.Id %>" />

                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

            <asp:DataPager ID="DataPager" runat="server"
                PagedControlID="LvUsers" PageSize="15"
                QueryStringField="page">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
