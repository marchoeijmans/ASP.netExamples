<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OdsViewStateExample.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Hello World</h1>
        <asp:FormView ID="EmployeeView" runat="server" CellPadding="4" DataSourceID="OdsEmployeeViewModel"
            ForeColor="#333333" OnItemInserted="EmployeeView_ItemInserted" OnItemDeleted="EmployeeView_ItemDeleted"
            OnItemInserting="EmployeeView_ItemInserting" OnItemUpdating="EmployeeView_ItemUpdating">
            <EditItemTemplate>
                ID:
                <asp:TextBox ID="IDEdit" runat="server" Text='<%# Bind("ID") %>' />
                <br />
                FirstName:
                <asp:TextBox ID="FirstNameEdit" runat="server" Text='<%# Eval("Name.FirstName") %>' />
                <br />
                LastName:
                <asp:TextBox ID="LastNameEdit" runat="server" Text='<%# Eval("Name.LastName") %>' />
                <br />
                Street:
                <asp:TextBox ID="StreetEdit" runat="server" Text='<%# Eval("Address.Street") %>' />
                <br />
                Housenumber:
                <asp:TextBox ID="HouseNumberEdit" runat="server" Text='<%# Eval("Address.HouseNumber") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                    CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <InsertItemTemplate>
                ID:
                <asp:TextBox ID="IDInsert" runat="server" Text='<%# Bind("ID") %>' />
                <br />
                FirstName:
                <asp:TextBox ID="FirstNameInsert" runat="server" Text='<%# Eval("Name.FirstName") %>' />
                <br />
                LastName:
                <asp:TextBox ID="LastNameInsert" runat="server" Text='<%# Eval("Name.LastName") %>' />
                <br />
                Street:
                <asp:TextBox ID="StreetInsert" runat="server" Text='<%# Eval("Address.Street") %>' />
                <br />
                Housenumber:
                <asp:TextBox ID="HouseNumberInsert" runat="server" Text='<%# Eval("Address.HouseNumber") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                    CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                ID:
                <asp:Label ID="IDRead" runat="server" Text='<%# Bind("ID") %>' />
                <br />
                Name:
                <asp:Label ID="FullNameRead" runat="server" Text='<%# Eval("Name") %>' />
                <br />
                Address:
                <asp:Label ID="FullAddressRead" runat="server" Text='<%# Eval("Address") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete" />
            </ItemTemplate>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:FormView>
        <asp:ObjectDataSource ID="OdsEmployeeViewModel" runat="server" SelectMethod="Select"
            InsertMethod="Add" UpdateMethod="Update" DeleteMethod="Remove" TypeName="OdsViewStateExample.EmployeeViewModel"
            OnObjectCreating="OdsEmployeeViewModel_ObjectCreating" DataObjectTypeName="OdsViewStateExample.EmployeeViewModel">
        </asp:ObjectDataSource>
    </div>
    <div>
        In ViewState:
        <asp:Label ID="lblViewState" runat="server"></asp:Label>
        <asp:Button ID="btrnShowViewState" runat="server" Text="ShowViewState" OnClick="btrnShowViewState_Click" />
    </div>
    </form>
</body>
</html>