<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardLogin2.aspx.cs" Inherits="WebApp.BoardLogin2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>BOARD_LOGIN</title>
<style type="text/css">

    body
        {
            background-color: white;
            text-align:center;
        }
    .header
    {
        margin-top:10%;
        display:inline-block;
        width: 320px;
    }
    .content
    {
        text-align:center;
        
        
    }
        .content .loginContent
        {
            display:inline-block;
            font-size: 20pt;
            
            background-color:white;
            border:inset;
        }

    .loginConent .loginTable
    {
        
        border: none;
    }

    .textBox
    {
        width: 250px;
        height: 40px;
        font-size: 14pt;
    }
    .textBox:hover
    {
        background-color: cornflowerblue;

    }
    .loginTable td
    {
        text-align: center;
    }

    .loginBtn
    {
        width:70%;
        height:40px;
        border:none;
        background-color: dodgerblue;
        
    }
        .loginBtn:hover
        {
            background-color:blue;
            color:whitesmoke;
        }
        .loginBtn:active
        {
            background-color:yellow;
            color:black;
        }
</style>

</head>

<%-- 스크립트 단 : 검사(id, pwd가 제대로 입력 되었는지 --%>
<script type="text/javascript">
    function loginBtns()
    {
        // 테스트
        //alert("로그인호출");

        // id, pwd 값 추출
        var id = document.getElementById("Id").value;
        var pwd = document.getElementById("Pwd").value;

        // 테스트
        //alert(id);
        //alert(pwd);

        // 조건확인 
        // 1. id 가 없다면
        if (id.trim() == "")
        {
            alert("id 를 입력하세요");
            var idForm = document.getElementById("Id");
            idForm.focus();
            return;
        }

        // 2. pwd 가 없다면
        if (pwd.trim() == "" )
        {
            alert("pwd 를 입력하세요");
            var pwdForm = document.getElementById("Pwd");
            pwdForm.focus();
            return;
        }

        <%= Page.GetPostBackEventReference(loginBtn)%>
    }

</script>    

<body>
<div class="header">
    <h1>
        회원 로그인
    </h1>
    <hr />
</div>

<div class="content">

    <form id="form1" name="loginForm" runat="server">
        <div class="loginContent">
             <table class="loginTable">
                 <tr>
                     <td>
                          <input class="textBox" type="text" runat="server" placeholder="yyyyy@aaaaaa.com" id="Id"/>
                     </td>
                 </tr>
                 <tr>
                     
                     <td>
                          <input class="textBox" type="password" runat="server" placeholder="xxxxxx-xxxxxxx" id="Pwd"/>
                     </td>
                 </tr>
                 <tr>
                     <td>
                        <input type="button" class="loginBtn" value="LOGIN" onclick="loginBtns()"/>
                        <asp:Button Text="LOGIN" runat="server" hidden="hidden" ID="loginBtn" onclick="LoginBtn_Click"/>
                     </td>
                 </tr>
             </table>
        </div>
    </form>

</div>

<div class="footer">
    <h2 id="result">

    </h2>
</div>


</body>
</html>