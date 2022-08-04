<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload001.aspx.cs" Inherits="FileSystem_Upload.FileUpload001" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <asp:FileUpload ID="Upload" runat="server" enctype="multipart/form"/>
            </div>
            <button type="submit">업로드</button>
            <asp:Label ID="UploadResult" runat="server" ForeColor="red"></asp:Label>
            
        </div>
    </form>
</body>
</html>
