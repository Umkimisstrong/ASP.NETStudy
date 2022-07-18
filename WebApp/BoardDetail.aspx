<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardDetail.aspx.cs" Inherits="WebApp.BoardDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>
<style type="text/css">
    body
        {
            background-color: white;
            text-align:center;
        }
    .header
    {
        display:inline-block;
        width: 650px;
    }

    .content
    {
        display:inline-block;
        text-align:center;
    }
    .Board_SubTitle
    {
        display:inline-block;
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
        
    </div>
    <%-- 번호 / 제목(댓글) / 작성자 / 작성일 / 조회수 --%>
    <form id="backForm" runat="server">
    <div class="Board_SubTitle" >
        
        <asp:Table ID="Board_Detail" runat="server" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" BackColor="Window" CellPadding="6" Width="600px">

        </asp:Table>
        <asp:Textbox ID="textarea" Width="591px" mode="multiline" runat="server" ReadOnly="true" Font-Bold="true" Font-Size="Large">

        </asp:Textbox> <br />
        
        
        

    </div class="Board_Title">
        <br />
        <br />
        
    <div>
        <h2>댓 글</h2>
        
        <asp:Table ID="Board_Reply" runat="server" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" BackColor="Window" CellPadding="6" Width="600px">

        </asp:Table>

    </div>

    
        <div>
            <asp:Button ID="Back" Text="돌아가기" OnClick="Back_Click" runat="server"/>
            <asp:Button ID="Reply" Text="댓글작성" OnClick="Reply_Click" runat="server"/>
            <asp:Button ID="Delete" Text="게시물삭제" runat="server" Visible="false" OnClick="Delete_Click"></asp:Button>
            <asp:Button ID="Update" Text="게시물수정" runat="server" Visible="false" OnClick="Update_Click"/>

            <%-- 숨겨진항목 --%>
            <asp:TextBox ID="Board_Id" Visible="false" runat="server"></asp:TextBox>
        </div>
        
    </form>

</div>


<div class="footer">
   
</div>

</body>
</html>
