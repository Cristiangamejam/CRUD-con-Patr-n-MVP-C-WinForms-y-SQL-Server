using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Views
{
    public interface IPetView
    {
        //Properties - Fields
        string PetId { get; set; }
        string PetName { get; set; }
        string PetType { get; set; }
        string PetColour { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        event EventHandler ShowVetsView;
        event EventHandler ShowPantallaView;

        //Methods
        void SetPetListBindingSource(BindingSource petList);
        void Show();
        //Form Form { get;  }

    }
}
