<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardList.aspx.cs" Inherits="WebApp.BoardList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 78px;
        }
        .auto-style2 {
            width: 602px;
        }
        .auto-style4 {
            width: 113px;
        }
        .auto-style5 {
            width: 380px;
        }
        .auto-style6 {
            width: 124px;
        }
        .auto-style7 {
            margin-top: 0px;
        }
        .auto-style13 {
            width: 175px;
        }
        .auto-style14 {
            width: 80px;
        }
        .auto-style15 {
            width: 796px;
        }
        .auto-style16 {
            width: 1307px;
        }
        .auto-style18 {
            margin-top: 0px;
            width: 1318px;
        }
        .auto-style20 {
            width: 147px;
        }
        .auto-style21 {
            width: 139px;
        }

        .content {
           text-align: center;
        }

        .Board_Title {
            display:inline-block;
        }

        /*.Board_SubTitle {
            display:inline-block;
        }

*/  
        body
        {
            background-color: gray;
            text-align:center;
        }
    .header
    {
        color:white;
        display:inline-block;
        width: 500px;
    }

        a
        {
            color:darkolivegreen;
            font-weight:bold;
        }
        a:hover
        {
            color:darksalmon;
        }

        td {
            color:darkolivegreen;
            font-weight:bold;
        }
        #searchKey {
            color:darkolivegreen;
            font-weight:bold;
            height:22px;
        }
            #searchKey:hover {
                color:darksalmon;
            }
        #searchValue {
            height:17px;
            color:darkcyan;
            font-weight:bold;
        }
        #searchValue:hover {
            background-color:darksalmon;
        }
        #searchBtn {
            height:25px;
            color:darkolivegreen;
            font-weight:bold;

        }
        #searchBtn:hover {
            height:25px;
            color:darksalmon;
            
        }
        #AddBtn {
            font-weight:bold;
            color:darkolivegreen;
        }
        #AddBtn:hover {
            color:darksalmon;
        }
        #LogoutBtn {
            font-weight:bold;
            color:darkolivegreen;
        }
        }
        #LogoutBtn:hover {
            color:darksalmon;
        }
    </style>

<%-- 스크립트 단 --%>
<script type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.min.js ">
</script>

<script>
    function searchBoard()
    {
        var searchKey = document.getElementById("searchKey");
        //alert(searchKey.value);
        var searchValue = document.getElementById("searchValue");
        //alert(searchValue.value);

        var url = "BoardList.aspx?searchKey=" + searchKey.value + "&searchValue=" + searchValue.value;
        location.href = url;
    }
</script>
</head>

<body>

<div class="header">
    <h1>
        Member Board
    </h1>
    <hr />
</div>

<div class="content">
    
    <div class="Board_Title">


        <div class="Board_SubTitle">
            <asp:Table ID="SubTitle" runat="server" BorderStyle="Solid" BorderWidth="1px" CellSpacing="1" BackColor="Window" CellPadding="5" Width="490px">

            </asp:Table>
        </div>
        
        <div class="Board_SubTitle" style="text-align: right;">
            
            <form id="addForm" runat="server" >
                   <asp:Button Text="글쓰기" runat="server" ID="AddBtn" OnClick="AddBtn_Click"/> 
                   <asp:Button Text="로그아웃" runat="server" ID="LogoutBtn" OnClick="LogoutBtn_Click"/> 
            </form>
        </div>
        
        <asp:Table ID="Board_List" runat="server" BorderStyle="Solid" BorderWidth="1px" CellSpacing="1" BackColor="Window" CellPadding="5" Width="490px">

        </asp:Table>
        
    
        <%-- 검색 --%>
        <div>
            <select id="searchKey">
                <option name="searchKey" value="BOARD_TITLE" selected="selected">제목</option>
                <option name="searchKey" value="U_NAME">작성자</option>
                <option name="searchKey" value="BOARD_CONTENT">내용</option>
            </select>
            <input type="text" id="searchValue"/>
            <input type="button" value="검색" id="searchBtn" onclick="searchBoard()"/>
        </div>

        <%-- 페이징 --%>    
        <asp:Label ID="PageIndex" runat="server" Font-Size="16pt" ForeColor="White"></asp:Label>

        
    </div>
    

    

</div>


<div class="footer">
   
</div>



</body>
</html>
