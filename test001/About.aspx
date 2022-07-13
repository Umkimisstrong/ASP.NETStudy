<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="test001.About" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p>Your app description page.</p>
    <p>Use this area to provide additional information.</p>
    <div>
        <table>
            <tr>
                 <th>
                    회사명
                 </th>
                 <th>
                    부서명
                 </th>
            </tr>
            <tr>
                <td>
                    모스티소프트
                </td>
                <td>
                    IT서비스사업부
                </td>
            </tr>
        </table>


    </div>


</asp:Content>
