<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardUpdate.aspx.cs" Inherits="WebApp.BoardUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Board Update</title>
<style type="text/css">
    body{
        background-color:gray;
        text-align:center;
    }
    .container {
        max-width:600px;
        display:inline-block;
        
        max-height:1700px;
    }
    h1 {
        color:white;
    }
    #PageNum {
        width:98%;
        text-align:center;
        font-weight:bold;
        color:darkolivegreen;
        font-size:10pt;
    }
        #PageNum:hover {
            background-color:darksalmon;
        }
    #Board_Id {
        color:darkolivegreen;
        width:98%;
        text-align:center;
        font-weight:bold;
        font-size:10pt;

    }
        #Board_Id:hover {
            background-color:darksalmon;
        }
    #Board_Title {
        color:darkolivegreen;
        width:98%;
        text-align:center;
        font-weight:bold;
        font-size:10pt;
    }
        #Board_Title:hover {
            background-color:darksalmon;
        }
    .updateBoardTable {

    }
    .updateBoardTable td{
        background-color:antiquewhite;
        color:darkolivegreen;
        font-weight:bold;
        font-size:10pt;
    }
    #InsertBtn {
        font-weight:bold;
        color:darkolivegreen;

    }
        #InsertBtn:hover {
            color:darksalmon;
        }
    #Board_Content {
        color:darkolivegreen;
        font-weight:bold;
        font-size:10pt;
    }
        #Board_Content:hover {
            background-color:darksalmon;
        }
</style>

<script type="text/javascript">
</script>
</head>


<body>
<div class="container">
    <h1>
        Update Board
    </h1>
    <hr />
    <form id="boardUpdateForm" runat="server" action="BoardUpdate_ok.aspx" method="post" >
            <table class="updateBoardTable">
                <tr>
                    <td>
                        페 이 지
                    </td>
                    <td>
                        <asp:TextBox ID="PageNum" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        번 호
                    </td>
                    <td>
                        <asp:TextBox ID="Board_Id" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        제 목
                    </td>
                    <td>
                        <asp:TextBox ID="Board_Title" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        내 용
                    </td>
                    <td>
                        <asp:TextBox ID="Board_Content" TextMode="MultiLine" Rows="30" Columns="55" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>

                    </td>
                    <td>
                        <asp:Button Width="100px" ID="InsertBtn" OnClick="InsertBtn_Click" runat="server" Text="수정하기" />
                    </td>
                </tr>
            </table>
            <%--<asp:Button runat="server" Text="돌아가기" ID="Back_Detail" OnClick="Back_Detail_Click" UseSubmitBehavior="false"/>--%>
    </form>
</div>

</body>
</html>
