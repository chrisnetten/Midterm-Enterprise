<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP2007_S2016_MidTerm.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
     <div id="TodoDetails"class="container">
           <div id="detailsRow" class="row">
                   <h1>Todo Details</h1>
                   <div class="form-group">
                       <label class="control-label" for="TeamOneTextBox">Todo Name</label>
                       <asp:TextBox runat="server" CssClass="form-control" ID="TodoNameTextBox" placeholder="Todo Name" required="true"></asp:TextBox>
                   </div>
                    <div class="form-group">
                       <label class="control-label" for="TeamTwoTextBox">Todo Notes</label>
                       <asp:TextBox  runat="server" CssClass="form-control" ID="TodoNotesTextBox" placeholder="Todo Notes" required="true"></asp:TextBox>
                   </div>
                   <div class="form-group">
                       <label class="control-label" for="completed">Completed?</label>
                       <asp:CheckBox ID="Completed" runat="server" />
                       </div>
           

                        <div class="text-right">
                            <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click"/>
                           <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click"/>

                        </div>
</div>
               


       </div>       






</asp:Content>
