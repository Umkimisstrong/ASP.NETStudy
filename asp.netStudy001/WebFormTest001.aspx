<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormTest001.aspx.cs" Inherits="asp.netStudy001.WebFormTest001" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
</head>
<body>


    <form id="form1" runat="server">
        <%string name = "123"; %>
        <%-- 전체를 감싸는 div .container --%>
        <div class="container">

            <%-- 윗부분을 담당하는 div .header --%>
            <div class="header">
                <h1>
                    asp.net 학습
                </h1>
                <hr />
                 jsp 스크립 릿과 유사한 태그는 runat="server"속성이 있는 form 내부에 존재해야 변수를 읽을 수 있다 name :  <%=name %>
            </div>

            <%-- 중간 부분을 담당하는 div .content --%>
            <div class="content">
                <h2>
                    asp server control
                </h2>
                <p>
                    asp button <asp:Button Text="asp버튼" ID="Button" runat="server" OnClick="Button_Click"/>
                    <br />
                    type 은 submit 이다.
                    Text는 asp 버튼이지만<br />
                    render 되면서 pageLoad 시 <br />
                    ss 로 바뀌게 설정되었다.
                </p>
                <p>
                    html button <input type="button" value="html버튼" id="Button2" runat="server"/>
                    <br />
                    type 은 button 이다.
                    <br />
                    runat = server 속성을 부여해도
                    <br />
                    pageLoad 시 값을 부여할 수없다.
                </p>
            </div>

            <%-- 밑부분을 담당하는 div .footer --%>
            <div class="footer"></div>

        </div>
        <%-- 전체를 감싸는 div .container --%>
    </form>
</body>
</html>
