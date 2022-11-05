using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server._Repositories
{
    public class PantallaRepository:BaseRepository,IPantallaRepository
    {
        public PantallaRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<PetModel> GetAll()
        {
            var petList = new List<PetModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from Pet order by Pet_Id desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Id = (int)reader[0];
                        petModel.Name = reader[1].ToString();
                        petModel.Type = reader[2].ToString();
                        petModel.Colours = reader[3].ToString();
                        petList.Add(petModel);
                    }
                }

                return petList;
            }
        }
    }
}
