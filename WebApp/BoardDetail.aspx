<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardDetail.aspx.cs" Inherits="WebApp.BoardDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
        
    </div>
    <%-- 번호 / 제목(댓글) / 작성자 / 작성일 / 조회수 --%>
    <form id="backForm" runat="server">
    <div class="Board_SubTitle" >
        
        <asp:Table ID="Board_Detail" runat="server" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" BackColor="Window" CellPadding="6" Width="700px">

        </asp:Table>
        <asp:textbox ID="textarea" Width="691px" mode="multiline" runat="server" ReadOnly="true" Font-Bold="true" Font-Size="Large"></asp:textbox> <br />
        
        
        

    </div>
        <br />
        <br />
    <div>
        <h2>댓 글</h2>
        <asp:Table ID="Board_Reply" runat="server" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" BackColor="Window" CellPadding="6" Width="700px">

        </asp:Table>

    </div>

    
        <div>
            <asp:Button ID="Back" Text="돌아가기" OnClick="Back_Click" runat="server"/>
            
        </div>
        
    </form>

</div>


<div class="footer">
   
</div>

</body>
</html>
