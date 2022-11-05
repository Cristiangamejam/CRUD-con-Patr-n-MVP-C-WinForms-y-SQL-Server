using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server._Repositories
{
    public class PetRepository : BaseRepository, IPetRepository
    {
        //Constructor
        public PetRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Methods
        public void Add(PetModel petModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Pet (Pet_name,Pet_type,Pet_colour) values (@name,@type,@colour)";
                //command.Parameters.Add("@id", SqlDbType.Int).Value = petModel.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petModel.Name;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = petModel.Type;
                command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = petModel.Colours;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Pet where Pet_Id=@id)";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(PetModel petModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Pet 
                                        set Pet_Name=@name,Pet_Type=@type,Pet_Colour=@colour 
                                        where Pet_Id=@id";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petModel.Name;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = petModel.Type;
                command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = petModel.Colours;
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = petModel.Id;
                command.ExecuteNonQuery();
            }
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

        public IEnumerable<PetModel> GetByValue(string value)
        {
            var petList = new List<PetModel>();
            int petId = int.TryParse(value, out _ ) ? Convert.ToInt32(value) : 0;
            string petName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from Pet 
                                        where Pet_Id=@Id or Pet_Name Like @Name + '%'
                                        order by Pet_Id desc";

                command.Parameters.Add("@Id", SqlDbType.Int).Value = petId;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = petName;
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
