<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formats.aspx.cs" Inherits="VO.DVDCentral.WFUI.Formats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="header rounded-top">
        <h3>Maintain Formats </h3>
    </div>
    <p></p>

    <div class="form-row m1-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label1" runat="server" Text="Rating:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlFormats" runat="server"
                CssClass="form-control"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlFormats_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>



    <div class="form-row m1-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label3"
                runat="server" Text="Description:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:TextBox ID="txtDescription" runat="server"
                CssClass="form-control">
            </asp:TextBox>
        </div>
    </div>



    <div class="form-group ml-5 mt-2">
        <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="btn btn-primary btn-md ml-3" OnClick="btnInsert_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary btn-md ml-3" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary btn-md ml-3" OnClick="btnDelete_Click" />
    </div>
</asp:Content>
