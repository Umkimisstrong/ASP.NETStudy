<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardUpdate.aspx.cs" Inherits="WebApp.BoardUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

<script type="text/javascript">
  /*  function checkContents() {
        //alert("123");
        var board_title = document.getElementById("board_title").value;
        var board_content = document.getElementById("board_content").value;

        alert(board_title);
        alert(board_content);
        
        // 입력되었는지, 공백은 아닌지 검사
        if (board_title.trim() == "")
        {
            alert("제목을 입력하세요"); 
            document.getElementById("board_title").focus();
            return;
        }

        if (board_content.trim() == "")
        {
            alert("내용을 입력하세요");
            document.getElementById("board_content").focus();
            return;
        }

        alert("게시물을 추가합니다.");
        document.getElementById("boardInsertForm").submit();
        // 여기부터 시작

    }*/
</script>
</head>


<body>
    <form id="boardUpdateForm" runat="server" action="BoardUpdate_ok.aspx" method="post" >
        <div>
            <table>
                <tr>
                    <td colspan="2">
                        [페 이 지]
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="PageNum" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        [번 호]
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="Board_Id" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        [제 목]
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<input type="text" id="board_title" name="board_title" style="width:300px;" />--%>
                        <asp:TextBox ID="Board_Title" runat="server" Width="300px" ></asp:TextBox>
                    </td>
                    <td style="text-align:right;">
                         <%--<input type="button" value="수정하기" style="width:100px;" id="insertBtn" onclick="checkContents()"/>--%>
                        <asp:Button Width="100px" ID="InsertBtn" OnClick="InsertBtn_Click" runat="server" Text="수정하기" />
                    </td>
                </tr>
                <tr>
                    <td>
                        [내 용]
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%--<textarea style="width:500px; position:absolute;" rows="30" placeholder="내용을 입력하세요" id="board_content" name="board_content">
                            
                        </textarea>--%>
                        <asp:TextBox ID="Board_Content" TextMode="MultiLine" Rows="30" Columns="55" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <%--<asp:Button runat="server" Text="돌아가기" ID="Back_Detail" OnClick="Back_Detail_Click" UseSubmitBehavior="false"/>--%>

        </div>
        

    </form>

</body>
</html>
