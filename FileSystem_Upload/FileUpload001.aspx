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
            <%-- 파일을 업로드 하는 영역 --%>
            <div>
                <asp:FileUpload ID="Upload" runat="server" enctype="multipart/form"/>
            
            
            
                <asp:Button runat="server" ID="UpdateBtn" Text="업로드"/>
                <asp:Label ID="UploadResult" runat="server" ForeColor="red"></asp:Label>
            </div>


            <br />

            
            <%-- 파일을 다운로드 하는 영역 --%>
            <asp:Table ID="FileDownLoadList" runat="server">

            </asp:Table>

        </div>
    </form>
</body>
</html>
