<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="R2D2.WebClient._Default" %>

<%@ Register Src="~/Controls/ListBooks.ascx" TagPrefix="uc" TagName="ListBooks" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="jumbotron">
                <div class="row">
                    <div class="col-md-6 text-center">
                        <h1 class="animated fadeInDown">Boost your knowledge</h1>
                    </div>
                    <div class="col-md-6 text-center">
                        <img class="animated fadeInDown" src="Imgs/knowledge.png" />
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
                <uc:ListBooks runat="server" id="ListBestReadings" />
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Latest books</h3>
                </div>
                <uc:ListBooks runat="server" id="ListBooks" />
            </div>
        </div>
    </div>
</asp:Content>
