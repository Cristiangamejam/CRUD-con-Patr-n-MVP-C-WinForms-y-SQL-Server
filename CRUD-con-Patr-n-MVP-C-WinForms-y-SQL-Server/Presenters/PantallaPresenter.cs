using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server._Repositories;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Models;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Presenters
{
    public class PantallaPresenter
    {
        private IPantalla pantalla;
        private IPantallaRepository pantallaModel;
        public PantallaPresenter(IPantalla _pantalla,IPantallaRepository pantallaModel)
        {
            pantalla=_pantalla;
            this.pantallaModel = pantallaModel;
            pantalla.Show();
            
        }
    }
}
