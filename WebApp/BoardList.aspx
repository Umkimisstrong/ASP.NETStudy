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
    </style>
</head>

<body>

<div class="header">
    <h1>
        회원 게시판
    </h1>
    <hr />
</div>

<div class="content" >
    
    <div class="Board_Title">

        <%--    
        <table border="1">
            <tr>
                <th class="auto-style16" style="background-color: aliceblue;">게 시 판</th>
            </tr>
        </table>
        --%>
        <form id="addForm" runat="server" >
               <asp:Button Text="글쓰기" runat="server" ID="AddBtn" OnClick="AddBtn_Click"/> 
        </form>
    </div>
    <%-- 번호 / 제목(댓글) / 작성자 / 작성일 / 조회수 --%>
    <div class="Board_SubTitle" >

        <%-- 테이블 --%>
        <%--<table border="1" class="auto-style18">
            <tr>
                <th style="background-color: aliceblue;" class="auto-style1">번호</th>
                <th style="background-color: aliceblue;" class="auto-style2">제목</th>
                <th style="background-color: aliceblue;" class="auto-style5">작성자</th>
                <th style="background-color: aliceblue;" class="auto-style21">작성일</th>
                <th style="background-color: aliceblue;" class="auto-style20">조회수</th>
            </tr>
        </table>--%>
       <%--
           <table border="1" class="auto-style7">
            <tr>
                <th class="auto-style14">1</th>
                <th class="auto-style15">안녕하세요 김효섭입니다.</th>
                <th class="auto-style13">김효섭</th>
                <th class="auto-style4">2022-07-13</th>
                <th class="auto-style6">0</th>
            </tr>
            <tr>
                <th class="auto-style14">2</th>
                <th class="auto-style15">안녕하세요 김상기입니다.</th>
                <th class="auto-style13">김상기</th>
                <th class="auto-style4">2022-07-13</th>
                <th class="auto-style6">0</th>
            </tr>
            <tr>
                <th class="auto-style14">3</th>
                <th class="auto-style15">안녕하세요 김화입니다.</th>
                <th class="auto-style13">김화</th>
                <th class="auto-style4">2022-07-13</th>
                <th class="auto-style6">0</th>
            </tr>
            
        </table>
           --%>
        <asp:Table ID="Board_List" runat="server" BorderStyle="Solid" BorderWidth="1px" CellSpacing="1" BackColor="Window" CellPadding="5">

        </asp:Table>
    </div>


    <%-- 1     안녕하세요 김효섭입니다. /      김상기    /   2022-07-13 12:00:33 / 0 --%>
    <%-- 2     안녕하세요 김상기입니다. /      김상기    /   2022-07-13 12:00:33 / 0 --%>
    <%-- 3     안녕하세요 김상기입니다. /      김상기    /   2022-07-13 12:00:33 / 0 --%>


    <%-- 페이징 --%>
    <%--<div>
        <a href="">이전</a> 1 2 3 4 5 6 7 8 9 10 다음
    </div>--%>

</div>


<div class="footer">
   
</div>



</body>
</html>
