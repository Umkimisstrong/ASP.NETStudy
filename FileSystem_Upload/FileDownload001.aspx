<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileDownload001.aspx.cs" Inherits="FileSystem_Upload.FileDownload001" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="DownLoad" runat="server" OnClick="DownLoad_Click">다운로드</asp:LinkButton>
        </div>
    </form>
</body>
</html>
