using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Models;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Presenters;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Views;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server._Repositories;
using System.Configuration;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string ConnectionString= ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            IPetView view = new PetView();
            IPetRepository repository = new PetRepository(ConnectionString);
            new PetPresenter(view, repository);

            Application.Run((Form)view);
        }
    }
}
