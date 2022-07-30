<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardInsert.aspx.cs" Inherits="WebApp.BoardInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Board Insert</title>

<style type="text/css">

    body {
        text-align:center;
        background-color:gray;
    }
    .container {
        display:inline-block;
        max-width:600px;
        max-height:1700px;
        text-align:center;
    }
    .header {
        width:500px;
        color:white;
        display:inline-block;
    }
    .content {
        display:inline-block;
    }

    .boardInsertTable {
        border:none;
    }
    .boardInsertTable td{
        background-color:antiquewhite;
        color:darkolivegreen;
    }
    #board_title {
        width:97%;
        height:97%;
        font-weight:bold;
        color:darkolivegreen;
    }
        #board_title:hover {
            color:darksalmon;
            background-color:beige;
            border:0.5px solid gray;
        }
    #board_content {
        font-weight:bold;
        color:darkolivegreen;
    }
        #board_content:hover {
            color:darksalmon;
            background-color:beige;
            border:0.5px solid gray;

        }

    #insertBtn {
        font-weight:bold;
        color:darkolivegreen;
    }
        #insertBtn:hover {
            color:darksalmon;
        }
</style>

<script type="text/javascript">
    function checkContents() {
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

    }
</script>
</head>


<body>
<div class="container">

    
    <div class="header">
        <h1>
            Create Board 
        </h1>
    </div>
    <div class="content">

    
            <form id="boardInsertForm" action="BoardInsert_ok.aspx" runat="server" name="boardInsertForm" method="post">
                
                    <table class="boardInsertTable">
                        <tr>
                            <td>
                                제 목 
                            </td>
                            <td>
                                <input type="text" id="board_title" name="board_title" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                내 용 
                            </td>
                            <td>
                                <textarea cols="39" rows="25" placeholder="내용을 입력하세요" id="board_content" name="board_content">

                                </textarea>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="text-align:right;">
                            </td>
                            <td>
                                 <input type="button" value="글쓰기" style="width:100px;" id="insertBtn" onclick="checkContents()"/>
                            </td>
                        </tr>
                    </table>
                
            </form>
        </div>
</div>
</body>
</html>
