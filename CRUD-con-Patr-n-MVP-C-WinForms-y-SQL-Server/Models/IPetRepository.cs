using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Models
{
    public interface IPetRepository
    {
        void Add(PetModel petModel);
        void Edit(PetModel petModel);
        void Delete(int id);
        IEnumerable<PetModel> GetAll();
        IEnumerable<PetModel> GetByValue(string value);//Searchs
    }
}
