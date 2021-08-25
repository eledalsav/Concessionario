using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado
{
    class DbMangerConnectedMode
    {

        public void Fetch()
        {
            string ConnectionString = @"Dara Source=(localdb)\MSSQLLocalD;" +
                                    "Initial Catalog=Ado;" +
                                    "Integrated Security=true;";

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command connection = connection;

            command.CommandText = "select *from dbo.Book";
            sqlDataReader reader= command.ExecuteReader();
        
        }

    }
}
