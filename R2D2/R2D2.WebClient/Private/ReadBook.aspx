<%@ Page Title="Read Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReadBook.aspx.cs" Inherits="R2D2.WebClient.Private.ReadBook" %>

<asp:Content ID="ContentReadBook" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="jumbotron text-center">
        <asp:Label ID="curBookTitle" CssClass="animated fadeIn" runat="server" />
    </h1>
    <div class="row">
        <div class="col-md-3">
            <asp:Repeater ID="RepeaterChapters" runat="server"
                OnLoad="RepeaterChapters_Load">
                <HeaderTemplate>
                    <h3 class="animated fadeInLeft">Chapters</h3>
                    <div class="list-group">
                </HeaderTemplate>

                <ItemTemplate>
                    <asp:LinkButton runat="server"
                        CssClass='<%# (Container.DataItem as Tuple<string, string, int>).Item3.ToString() + " list-group-item animated fadeInLeft" %>'
                        OnCommand="ShowChapter_Command"
                        CommandArgument='<%#: (Container.DataItem as Tuple<string, string, int>).Item1 + "," + (Container.DataItem as Tuple<string, string, int>).Item3 %>'>
                        <%#: (Container.DataItem as Tuple<string, string, int>).Item2 %>
                    </asp:LinkButton>
                </ItemTemplate>

                <FooterTemplate>
                    </div>
               
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-9 page-read animated fadeIn">
            <h1 style="visibility: hidden;" class="hide-me" runat="server" id="hiddenField"></h1>
            <asp:Label ID="lblChapterContent" runat="server"></asp:Label>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            var hiddenArguments = $('div > h1.hide-me').text().split(',');

            var text = hiddenArguments[0];
            $('a.list-group-item.' + text).addClass('active');

            window.location.hash = hiddenArguments[1];
        });
    </script>
</asp:Content>
