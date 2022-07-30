<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="asp.netStudy001.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

<script>
    $(document).ready(function () {
        alert("재미있는 ASP.NET");

        $("input:submit").click(function () {
            alert("ㅎㅇ");
        });
        
        $("#ContentPlaceHolder1_Submit").click(function () {
            alert("이것도되지");
        });
    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="mainform" runat="server">

        <h1>
            안녕하세요
        </h1>

        <asp:Button ID="Submit" Text="어쩌고" runat="server" OnClick="Submit_Click"/>




    </form>
        

</asp:Content>
