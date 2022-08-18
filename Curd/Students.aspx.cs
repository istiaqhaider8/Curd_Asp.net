using System;
using System.Collections.Generic;

using System.Data.SqlClient;

namespace Curd
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["regNo"] != null)
                {
                    string regNo = Request.QueryString["regNo"];
                    Student student = GetStudentByRegNo(regNo);

                    if (student != null)
                    {
                        NameTextBox.Text = student.Name;
                        EmailTextBox.Text = student.Email;
                        AddressTextBox.Text = student.Address;
                        RegNoTextBox.Text = student.RegNo;
                        StudentIdHiddenField.Value = student.Id.ToString();
                        Save.Text = "Update";
                    }
                }
            }
            
        }

        string connectionString = @"Server = DESKTOP-1ACAIOK; database = UniversityBD_28; Integrated Security = true";
        
        public Student student;
        protected void Save_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string address = AddressTextBox.Text;
            string regNo = RegNoTextBox.Text;
            student = new Student(name, email, regNo, address);



            if (Save.Text == "Update")
            {
                int studentId = Convert.ToInt32(StudentIdHiddenField.Value);
                student.Id = studentId;
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "UPDATE  Students SET Name='" + student.Name + "',RegNo='" + student.RegNo + "',Email='" + student.Email + "',Address='" + student.Address + "' WHERE Id=" +student.Id+ "";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int isrow = command.ExecuteNonQuery();
                connection.Close();

                if (isrow != null)
                {
                    Response.Write("Data Updated");
                }
            }
            else
            {
                if (isRegNoExist(student.RegNo))
                {
                    Response.Write("RegNo Already Exist");
                }
                else
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    string query = "Insert into Students(Name,RegNo,Email,Address) VALUES('" + student.Name + "','" + student.RegNo + "','" + student.Email + "','" + student.Address + "');";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    int isrow = command.ExecuteNonQuery();
                    connection.Close();

                    if (isrow != null)
                    {
                        Response.Write("Data Save");
                        NameTextBox.Text = "";
                        EmailTextBox.Text = "";
                        AddressTextBox.Text = "";
                        RegNoTextBox.Text = "";
                    }
                }
            }
        }

        protected void Show_Click(object sender, EventArgs e)
        {

            List<Student> studentList = new List<Student>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Students;";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                string regNo = reader["RegNo"].ToString();
                string address = reader["Address"].ToString();
                Student student = new Student(id,name, email, regNo, address);
                studentList.Add(student);
            }

            reader.Close();
            connection.Close();
            studentGridView.DataSource = studentList;
            studentGridView.DataBind();
        }


        private Student GetStudentByRegNo(string regNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Students WHERE RegNo = '"+ regNo +"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Student student = null;
            if (reader.HasRows)
            {
                reader.Read();
                int id = Convert.ToInt32(reader["Id"]);
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                string regNumber = reader["RegNo"].ToString();
                string address = reader["Address"].ToString();
                reader.Close();
                student = new Student(id, name, email, regNumber, address);
            }
            connection.Close();
            return student;
        }

        private bool isRegNoExist(string regNo)
        {
            bool isRegNoExist = false;
            Student student = GetStudentByRegNo(regNo);
            if (student!= null)
            {
                isRegNoExist = true;
            }

            return isRegNoExist;
        }





    }
}