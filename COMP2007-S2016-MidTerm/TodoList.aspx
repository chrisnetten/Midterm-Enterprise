<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                <a href="TodoDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Todo</a>
     <div>
                    <label>Records Per Page: </label>
                    <asp:DropDownList ID="TodoDropDownList" runat="server"
                        AutoPostBack="true" CssClass="btn btn-default btn-sm dropdown-toggle"
                        OnSelectedIndexChanged="TodoDropDownList_SelectedIndexChanged">
                        <asp:ListItem Text="5" Value="5"/>
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="All" Value="10000" />
                    </asp:DropDownList>
                </div>
       <asp:GridView runat="server" ID="TodoGridView" CssClass="table table-bordered table-striped table-hover"
           AutoGenerateColumns="false" OnRowDeleting="TodoGridView_RowDeleting"
                    DataKeyNames="TodoID" AllowPaging="true" PageSize="5" OnPageIndexChanging="TodoGridView_PageIndexChanging"
                    AllowSorting="true" OnSorting="TodoGridView_Sorting" OnRowDataBound="TodoGridView_RowDataBound" ondatabound="TodoGridView_DataBound" ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="TodoID" HeaderText="Todo ID" Visible="true" SortExpression="TodoID" />
                        <asp:BoundField DataField="TodoName" HeaderText="Todo Name" Visible="true" SortExpression="TodoName" />
                        <asp:BoundField DataField="TodoNotes" HeaderText="TodoNotes" Visible="true" SortExpression="TodoNotes" />
                                    <asp:BoundField DataField="Completed" HeaderText="Completed?" Visible="true" SortExpression="Completed" />


            <asp:HyperLinkField HeaderText="Edit"  Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" NavigateUrl="~/TodoDetails.aspx"
                            ItemStyle-CssClass="btn btn-primary btn-sm" DataNavigateUrlFields="TodoID"
                            DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" ControlStyle-ForeColor="White" ItemStyle-VerticalAlign="Middle" />

                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" ShowDeleteButton="true"
                            ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />


        </Columns>

    </asp:GridView>
</asp:Content>
