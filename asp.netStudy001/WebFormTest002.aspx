<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormTest002.aspx.cs" Inherits="asp.netStudy001.WebFormTest002" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:AdRotator ID="AdRotator1" runat="server" />
        <asp:BulletedList ID="BulletedList1" runat="server"></asp:BulletedList>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <asp:CheckBox ID="CheckBox1" runat="server" />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        <asp:FileUpload ID="FileUpload1" runat="server" Height="111px" Width="111px" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        <asp:Image ID="Image1" runat="server" />
        <asp:ImageButton ID="ImageButton1" runat="server" />
        <asp:ImageMap ID="ImageMap1" runat="server"></asp:ImageMap>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <asp:Localize ID="Localize1" runat="server"></asp:Localize>
        <asp:MultiView ID="MultiView1" runat="server"></asp:MultiView>
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <asp:RadioButton ID="RadioButton1" runat="server" />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
        <asp:Substitution ID="Substitution1" runat="server" />
        <asp:Table ID="Table1" runat="server"></asp:Table>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:View ID="View1" runat="server"></asp:View>
        <asp:Wizard ID="Wizard1" runat="server">
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1"></asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2"></asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
        <asp:Xml ID="Xml1" runat="server"></asp:Xml>


    </form>
</body>
</html>
