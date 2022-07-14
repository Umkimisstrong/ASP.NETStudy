<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardInsert.aspx.cs" Inherits="WebApp.BoardInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

<script type="text/javascript">
    function checkContents() {
        //alert("123");
        var board_title = document.getElementById("board_title").value;
        var board_content = document.getElementById("board_content").value;

        //alert(board_title);
        //alert(board_content);
        
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
        document.forms[0].submit();
        // 여기부터 시작

    }
</script>
</head>


<body>
    <form id="boardInsertForm" action="BoardInsert_ok.aspx" runat="server" name="boardInsertForm" method="get">
        <div>
            <table>
                <tr>
                    <td colspan="2">
                        [제 목]
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="board_title" name="board_title" style="width:300px;" />
                    </td>
                    <td style="text-align:right;">
                         <input type="button" value="글쓰기" style="width:100px;" id="insertBtn" onclick="checkContents()"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        [내 용]
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <textarea style="width:500px; position:absolute;" rows="30" placeholder="내용을 입력하세요" id="board_content" name="board_content">

                        </textarea>
                    </td>
                </tr>
            </table>


        </div>
    </form>
</body>
</html>
