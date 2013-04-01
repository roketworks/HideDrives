<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HideDrivesSite.Default" MasterPageFile="~/Site.Master" %>
<%@ Register TagPrefix="uc" TagName="DriveOptionsControl" Src="~/DriveOptionsControl.ascx" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">

     <style type="text/css">

        .drive-list {
            float:left;
            margin:10px;
        }

        .drive-list input[type="checkbox"] {
            clear:right;
            margin-bottom:10px;
        }

        .control-container {
            clear:left;
        }

        .drivecontrols {
            margin-top:15px;
            margin-bottom:15px;
            clear:both;
        }
        
        #download {
            margin-top:50px;
            clear:left;
        }

    </style>

    <script type="text/javascript">

        $("#add_ascx").click(function () {

        });

    </script>

</asp:Content>

<asp:Content ContentPlaceHolderID="BodyContent" runat="server">

    <p>
    Create custom Administrative template template files for a Hide Drives policy. 
    </p>


    <!--<button id="add_asxc" type="button" title="Add Drive Option">Add Drive Option</button>-->
    <br />

    <asp:PlaceHolder ID="DrivePlaceHolder" runat="server">
        <uc:DriveOptionsControl runat="server" ID="dc1" />
    </asp:PlaceHolder>
    <br />
    <asp:PlaceHolder ID="DownloadPlaceHolder" runat="server">
        <div id="download">
            <asp:Button ID="DownloadButton" runat="server" OnClick="DownloadButton_Click" Text="Download ADM File" />
            <br />
        </div>
    </asp:PlaceHolder>


</asp:Content>

