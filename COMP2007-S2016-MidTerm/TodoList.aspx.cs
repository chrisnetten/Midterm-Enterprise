/* 
Author: Christopher Netten
Student #: 200230280
Date: June 23 2016
Description: This file will run the backend of TodoList It will query the Todo objects and return them

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_S2016_MidTerm.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace COMP2007_S2016_MidTerm
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // If first time loading page, populate the Todo grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "StudentID"; // default sort column
                Session["SortDirection"] = "ASC";
                //Get the Basketball Data
                this.GetTodo();
            }
        }

        protected void GetTodo()
        {
            // connect to ef
            using (TodoConnection db = new TodoConnection())
            {
                // Query todo table using ef and linq
                var Todo = (from allTodo in db.Todos
                            select allTodo);

                //bind the results to the GridView
                TodoGridView.DataSource = Todo.ToList();
                TodoGridView.DataBind();
            }
        }


        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was selected for deletion
            int selectedRow = e.RowIndex;

            // get the selected TodoID using the grid's Datakey collection
            int TodoID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF to find the selected todo from DB and Remove it
            using (TodoConnection db = new TodoConnection())
            {
                Todo deletedTodo = (from TodoRecords in db.Todos
                                    where TodoRecords.TodoID == TodoID
                                    select TodoRecords).FirstOrDefault();

                // remove the todo record from the database
                db.Todos.Remove(deletedTodo);

                // save changes to the db
                db.SaveChanges();

                // refresh the grid
                this.GetTodo();
            }
        }

        protected void TodoGridView_DataBound(object sender, EventArgs e)
        {
            // Rows in the GridView
            TodoGridView.FooterRow.Cells[0].Text = String.Format("Total: {0}",
                TodoGridView.Rows.Count.ToString());


            // Make first cell in footer row span the entire row and hide the other cells
            TodoGridView.FooterRow.Cells[0].ColumnSpan = TodoGridView.FooterRow.Cells.Count;
            for (int i = 1; i < TodoGridView.FooterRow.Cells.Count; i++)
            {
                TodoGridView.FooterRow.Cells[i].Visible = false;
            }
        }

        protected void TodoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            TodoGridView.PageIndex = e.NewPageIndex;

            // refresh the grid
            this.GetTodo();
        }

        protected void TodoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set new Page size
            TodoGridView.PageSize = Convert.ToInt32(TodoDropDownList.SelectedValue);

            // refresh the grid
            this.GetTodo();
        }

        protected void TodoGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            // refresh the grid
            this.GetTodo();

            //toggle the sort direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void TodoGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) // if the row clicked is the header row
                {
                    LinkButton linkButton = new LinkButton();

                    for (int index = 0; index < TodoGridView.Columns.Count; index++) // check each column for a click
                    {
                        if (TodoGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkButton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkButton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkButton); // add the new linkbutton to header cell
                        }
                    }
                }
            }
        }




    }
}