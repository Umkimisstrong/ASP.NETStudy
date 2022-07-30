<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeaterTest.aspx.cs" Inherits="ASP.NETStudy002.RepeaterTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">





        <asp:Repeater ID="Repeater" runat="server" DataSourceID="sqlDataSource">
            <HeaderTemplate>
                <table>
                    <tr><td>BOARD_TITLE</td><td>BOARD_CONTENT</td></tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("BOARD_TITLE") %></td>
                    <td><%# Eval("BOARD_CONTENT") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td style="background-color:antiquewhite"><%# Eval("BOARD_TITLE") %></td>
                    <td style="background-color:antiquewhite"><%# Eval("BOARD_CONTENT") %></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="sqlDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:testData %>"
            SelectCommand="SELECT BOARD_TITLE, BOARD_CONTENT FROM dbo.TB_BOARD">
        </asp:SqlDataSource>

    </form>
</body>
</html>
