using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_week6
{
    class ImpegnoAdoRepository : IImpegnoRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                        "Initial Catalog = Impegni;" +
                                        "Integrated Security = true;";
        public void Delete(Impegno impegno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Impegno where Id = @id";
                command.Parameters.AddWithValue("@id", impegno.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Impegno> Fetch()
        {
            List<Impegno> impegni = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var duedate = (DateTime)reader["DueDate"];
                    var importance = (EnumImportance)reader["Importance"];
                    var iscompleted = (bool)reader["IsCompleted"];
                    var id = (int)reader["Id"];

                    Impegno impegno = new Impegno(title, description, duedate, importance, iscompleted, id);

                    impegni.Add(impegno);
                }
            }
            return impegni;
        }


        public void Insert(Impegno impegno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Impegno values (@title, @description, @duedate, @importance, @iscompleted)";
                command.Parameters.AddWithValue("@title", impegno.Title);
                command.Parameters.AddWithValue("@description", impegno.Description);
                command.Parameters.AddWithValue("@duedate", impegno.DueDate);
                command.Parameters.AddWithValue("@importance", (int)impegno.Importance);
                command.Parameters.AddWithValue("@iscompleted", impegno.IsCompleted);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Impegno impegno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Impegno set Title=@title, Description=@description, DueDate=@duedate, Importance=@importance, IsCompleted=@iscompleted where Id = @id";
                command.Parameters.AddWithValue("@title", impegno.Title);
                command.Parameters.AddWithValue("@description", impegno.Description);
                command.Parameters.AddWithValue("@duedate", impegno.DueDate);
                command.Parameters.AddWithValue("@importance", (int)impegno.Importance);
                command.Parameters.AddWithValue("@iscompleted", impegno.IsCompleted);
                command.Parameters.AddWithValue("@id", impegno.Id);

                command.ExecuteNonQuery();
            }
        }
        public List<Impegno> GetByIsCompleted(bool iscompleted)
        {
            List<Impegno> impegni = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno where IsCompleted=@iscompleted";
                command.Parameters.AddWithValue("@iscompleted", iscompleted);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var duedate = (DateTime)reader["DueDate"];
                    var importance = (EnumImportance)reader["Importance"];
                    var id = (int)reader["Id"];

                    Impegno impegno = new Impegno(title, description, duedate, importance,iscompleted,id);

                    impegni.Add(impegno);
                }
            }
            return impegni;
        }
        public List<Impegno> GetByImportance(EnumImportance importance)
        {
            List<Impegno> impegni = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno where Importance=@importance";
                command.Parameters.AddWithValue("@importance", (int)importance);
               
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var duedate = (DateTime)reader["DueDate"];
                    var iscompleted = (bool)reader["IsCompleted"];
                    var id = (int)reader["Id"];

                    Impegno impegno = new Impegno(title, description, duedate, importance, iscompleted, id);

                    impegni.Add(impegno);
                }
            }
            return impegni;
        }

        public List<Impegno> GetByDueDate(DateTime duedate)
        {

            List<Impegno> impegni = new List<Impegno>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Impegno where DueDate=@duedate";
                command.Parameters.AddWithValue("@duedate", duedate);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var importance = (EnumImportance)reader["Importance"];
                    var iscompleted = (bool)reader["IsCompleted"];
                    var id = (int)reader["Id"];

                    Impegno impegno = new Impegno(title, description, duedate, importance, iscompleted, id);

                    impegni.Add(impegno);
                }
            }
            return impegni;
        }
    }
}
