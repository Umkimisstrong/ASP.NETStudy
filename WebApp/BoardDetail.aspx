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
            background-color: gray;
            text-align:center;
        }
    .header
    {
        display:inline-block;
        width: 1000px;
        color:white;
    }

    .content
    {
        display:inline-block;
        width: 1000px;
        text-align:center;
    }
    .Board_SubTitle
    {
        display:inline-block;
        width: 1000px;
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
            color:darkgoldenrod;
            font-weight:bold;
        }

    .container {

        display:inline-block;
        width: 1000px;
    }

    #Back {
        color:darkolivegreen;
        font-weight:bold;
    }
        #Back:hover {
            color:darksalmon;
        }
    #Reply {
        color:darkolivegreen;
        font-weight:bold;
    }
        #Reply:hover {
            color:darksalmon;
        }
    #Delete {
        color:darkolivegreen;
        font-weight:bold;
    }
        #Delete:hover {
            color:darksalmon;
        }
    #Update {
        color:darkolivegreen;
        font-weight:bold;
    }
        #Update:hover {
            color:darksalmon;
        }
</style>

    <%-- 댓글아이디 들고간다. --%>

<script>
    function answer(reply_id)
    {
        //alert("답변");
        var replyId = reply_id;
        //alert(reply_id);
        var board_id = document.getElementById("Board_Id").value;
        //alert(board_id);
        var pageNum = document.getElementById("PageNum").value;
        //alert(pageNum);

        if (reply_id != null || replyId.trim() != "")
        {
            location.href = "BoardAnswerInsert.aspx?reply_id=" + replyId + "&pageNum=" + pageNum + "&board_id=" + board_id;
        }
        else
        {
            alert("댓글아이디가없음");
            return;
        }
    }

    function deleteAnswer(answer_id) {

        var result = confirm("선택하신 답변을 정말 삭제하시겠습니까??");
        if (!result)
        {
            alert("취소되었습니다.");
            return;
        }

        //alert("답변");
        var answerId = answer_id;
        //alert(reply_id);
        var board_id = document.getElementById("Board_Id").value;
        //alert(board_id);
        var pageNum = document.getElementById("PageNum").value;
        //alert(pageNum);

        
        location.href = "BoardAnswerDelete.aspx?answer_id=" + answerId + "&pageNum=" + pageNum + "&board_id=" + board_id;
        
    }
</script>

</head>
<body>

<div class="container">
    
<div class="header">
    <h1>
        Member Board
    </h1>
    <hr />
</div>

<div class="content" >
    
    
    <%-- 번호 / 제목(댓글) / 작성자 / 작성일 / 조회수 --%>
    <form id="backForm" runat="server">
    <div class="Board_SubTitle" >
        
        <asp:Table ID="Board_Detail" runat="server" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" BackColor="Window" CellPadding="6" Width="1000px">

        </asp:Table>
        <asp:Textbox ID="textarea" Width="991px" mode="multiline" runat="server" ReadOnly="true" Font-Bold="true" Font-Size="Large">

        </asp:Textbox> <br />

    </div>

        <br />
        <br />
        
    
        <h2>Replies</h2>
        <asp:Table ID="Board_Reply" runat="server" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" BackColor="Window" CellPadding="6" Width="1000px">
        </asp:Table>
        <asp:Button ID="Back" Text="돌아가기" OnClick="Back_Click" runat="server"/>
        <asp:Button ID="Reply" Text="댓글작성" OnClick="Reply_Click" runat="server"/>
        <asp:Button ID="Delete" Text="게시물삭제" runat="server" Visible="false" OnClick="Delete_Click"></asp:Button>
        <asp:Button ID="Update" Text="게시물수정" runat="server" Visible="false" OnClick="Update_Click"/>

        <%-- 숨겨진항목 --%>
        <%--<asp:TextBox ID="Board_Id" Visible="false" runat="server"></asp:TextBox>
        <asp:TextBox ID="PageNum" Visible="false" runat="server"></asp:TextBox>--%>
        <asp:HiddenField ID="Board_Id" runat="server" ClientIDMode="AutoID"/>
        <asp:HiddenField ID="PageNum" runat="server" ClientIDMode="AutoID"/>
    </form>

</div>


<div class="footer">
   
</div>
</div>
</body>
</html>
