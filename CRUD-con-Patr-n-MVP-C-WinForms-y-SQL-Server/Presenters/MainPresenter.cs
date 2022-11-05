using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Views;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Models;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server._Repositories;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            
            this.mainView.ShowPetView += ShowPetView;
            this.mainView.ShowPantallaView+=ShowPantallaView;
    }

        private void ShowPantallaView(object sender, EventArgs e)
        {
            IPantalla pantalla = FrmPantalla.GetInstance((MainView)mainView);
            IPantallaRepository pantallaRepository = new PantallaRepository(sqlConnectionString);
            new PantallaPresenter(pantalla, pantallaRepository);
            
        }

        private void ShowPetView(object sender, EventArgs e)
        {
            IPetView view = PetView.GetInstance((MainView)mainView);// new PetView();
            IPetRepository repository = new PetRepository(sqlConnectionString);
            new PetPresenter(view, repository);

            //PetView petView = new PetView();
            //petView.geti
            //petView.MdiParent = (MainView)mainView;
            //petView.Show();
        }
    }
}
