using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_S2016_MidTerm.Models;
using System.Web.ModelBinding;

namespace COMP2007_S2016_MidTerm
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodoList.aspx");
        }



        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // EF to connect to server
            using (TodoConnection db = new TodoConnection())
            {

                // use the Todo model
                // save a new record
                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0) // our URL has a TodoID in it
                {
                    // get the id from the URL
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current Todos from EF DB
                    newTodo = (from todo in db.Todos
                               where todo.TodoID == TodoID
                               select todo).FirstOrDefault();
                }

                // add form data to the new student record
                newTodo.TodoName = TodoNameTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                newTodo.Completed = Completed.Checked;

                // use LINQ to ADO.NET 

                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/TodoList.aspx");

            }
        }

    }
}
