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
        public PantallaPresenter(IPantalla _pantalla)
        {
                pantalla=_pantalla;
            ///this.pantalla.Pet += Pet;
            pantalla.Show();
            
        }
        //private void Pet(object sender, EventArgs e)
        //{
        //    IPantalla view = FrmPantalla.GetInstance((FrmPantalla)pantalla);// new PetView();
        //    //IPetRepository repository = new PetRepository(sqlConnectionString);
        //    new PantallaPresenter(view);
        //}
    }
}
