using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Models
{
    public interface IPantallaRepository
    {
        IEnumerable<PetModel> GetAll();
    }
}
