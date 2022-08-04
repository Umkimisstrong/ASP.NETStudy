<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoList.aspx.cs" Inherits="MyToDoList.ToDoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>My To Do List</title>

    
<%-- 스타일 --%>
<link rel="stylesheet" type="text/css" href="Content/bootstrap.css"/>
<style>
    body {
        text-align:center;
        background-color:gray;
    }

    .content {
        display:inline-block;
        text-align:center;
        width:700px;
        height:100%;
        
        
    }
    

    .content-header {
        display:inline-block;
        width:70%;
            
    }

    .content-body {
        display:inline-block;
        width:70%;
        text-align:center;
        height:100%;
    }
    .content-body-list{
        display:inline-block;
        text-align:center;
        width:85%;
        
        
    }
  
    .content-footer
    {
        display:inline-block;
        width:70%;

    }

    #U_TODO {
        width:400px;
        display:inline-block;
        height:38px;
    }

    todoList_Table {
        text-align:center;
        display:inline-block;
        width:100%;

        
    }

    todoList_Table tbody{
        width:100%;
        text-align:center;

    }
        todoList_Table tbody tr {
            width:100%;
        }
    td {
        padding-top:1.5px;
        padding-bottom:1.5px;
        
    }

    td.todo {
        width:90%;
    }
    td.check_box {
        width:5%;
    }
    td.deleteBtn{
        width:5%;
    }

    .HiddenText label {
        display:none;
    }
</style>

</head>
<body>
    <%-- Server 에서 Event 를 처리하기 위한 form --%>
    <form id="form1" runat="server">

        <%-- div.content  : 전체 div --%>
        <div class="content">

            <%-- div.content-header  : 상단 제목 div --%>
            <div class="content-header">
                <h1>
                    My To Do List
                </h1>
                <hr />
            </div>


            <%-- div.content-body  : 중단 내용 div --%>
            <div class="content-body">

                <%-- 사용자 ToDo 입력 TextBox --%>
                <asp:TextBox ID="U_TODO" placeholder="input new ToDo.." runat="server" CssClass="form-control"></asp:TextBox>

                <%-- 사용자 ToDo 입력 Button --%>
                <asp:Button ID="Create" Text="+" runat="server" CssClass="btn btn-primary" OnClick="Create_Click"/>

                <br /><br /><br />

                <%-- ToDo List 가 출력되는 div.content-body-list --%>
                <div class="content-body-list">

                        <table class="todoList_Table">
                        <%-- Repeater  --%>
                            <asp:Repeater ID="List" runat="server" OnItemCommand="List_ItemCommand" OnItemDataBound="List_ItemDataBound">
                                
                                <%-- 홀수 행 --%>
                                <ItemTemplate>
                                        <tr>
                                            <td class="check_box" style="background-color:wheat;">
                                                <asp:CheckBox ID="Update" runat="server" CommandName="update" CssClass="HiddenText"
                                                     OnCheckedChanged="Update_CheckedChanged" AutoPostBack="true"  />
                                            </td>
                                            <td class="todo" style="background-color:wheat;">
                                                <asp:Literal ID="ltrToDo" runat="server"></asp:Literal>
                                                <asp:Literal ID="ltrToDo_ID" runat="server" Visible="false"></asp:Literal>
                                            </td>
                                            <td class="deleteBtn" style="background-color:wheat;">
                                                <asp:Button ID="Delete" runat="server" Text="X" BackColor="Transparent" BorderColor="Transparent"
                                                     CommandName="delete"/>
                                            </td>
                                        </tr>
                                </ItemTemplate>

                                <%-- 짝수 행 --%>
                                <AlternatingItemTemplate>
                                        <tr>
                                            <td class="check_box" style="background-color:aquamarine;">
                                                <asp:CheckBox ID="Update" runat="server" CommandName="update" CssClass="HiddenText"
                                                    OnCheckedChanged="Update_CheckedChanged"  AutoPostBack="true"    />
                                            </td>
                                            <td class="todo" style="background-color:aquamarine;">
                                                <asp:Literal ID="ltrToDo" runat="server"></asp:Literal>
                                                <asp:Literal ID="ltrToDo_ID" runat="server" Visible="false"></asp:Literal>
                                            </td>
                                            <td class="deleteBtn" style="background-color:aquamarine;">
                                                <asp:Button ID="Delete" runat="server" Text="X"  BackColor="Transparent" BorderColor="Transparent"
                                                    CommandName="delete"/>
                                                <%-- 왜 Value 로 Eval() 을 지정할 때 더블 쿼테이션 "" 은 안돼고 싱글 쿼테이션 '' 만 되는 것인가? --%>
                                            </td>
                                        </tr>
                                </AlternatingItemTemplate>

                            </asp:Repeater>
                        </table>
                 </div>

            </div>

            <div class="content-footer">
                <hr />
                <h5>
                    Mostisoft IT Service 
                </h5>
            </div>
        </div>
    </form>
</body>
</html>
