<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardReplyInsert.aspx.cs" Inherits="WebApp.BoardReplyInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<style type="text/css">
    body {
        text-align:center;
        background-color:gray;
    }
    .container {
        max-width:600px;
        display:inline-block;
    }
    h1 {
        color:white;
    }
    #Reply_Content {
        color:darkolivegreen;
        font-weight:bold;
    }
        #Reply_Content:hover {
            background-color:beige;
        }
    #insertBtn {
        color:darkolivegreen;
        font-weight:bold;
    }
        #insertBtn:hover {
            color:darksalmon;
        }
</style>
<script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>

<script type="text/javascript">
    $(document).ready(function () {
        //alert("ㄴㅇㄹ");

    })
    //alert("내용을 입력하세요");
    /*function checkContents() {
        //alert("123");
        //var reply_content = document.getElementById("reply_content").value;
        
        //alert(reply_content);
                
        // 입력되었는지, 공백은 아닌지 검사
        //if (reply_content.trim() == "")
        //{
          //  alert("내용을 입력하세요"); 
           // document.getElementById("reply_content").focus();
           // return;
       // }

        alert("댓글을 추가합니다.");

        


    }*/
</script>
</head>

<body>
<div class="container">
    <h1>
        Reply on Board 
    </h1>
    <hr />

    <form id="Board_Reply" runat="server">
            <table>
                       
                <tr>
                    <td>
                        <%--<input type="text" id="reply_content" name="reply_content" style="width:300px;" />--%>
                        <asp:TextBox ID="Reply_Content" Width="300px" runat="server" ></asp:TextBox>
                    </td>
                    <td style="text-align:right;">
                         <%--<input type="button" value="댓글작성" style="width:100px;" onclick="checkContents()"/>--%>
                        <asp:button ID="insertBtn" Text="댓글작성" runat="server" OnClick="insertBtn_Click" />
                         

                    </td>
                </tr>
            </table>
    </form>
</div>
</body>
</html>
