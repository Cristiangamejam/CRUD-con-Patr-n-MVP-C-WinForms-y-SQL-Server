using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Views
{
    public partial class PetView : Form,IPetView
    {
        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        //Contructor
        public PetView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPagePetDetail);
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Others
        }

        //Properties
        public string PetId
        {
            get => txtPetId.Text;
            set => txtPetId.Text=value;
        }

        public string PetName
        {
            get => txtPetName.Text;
            set => txtPetName.Text=value;
        }

        public string PetType
        {
            get => txtPetType.Text;
            set => txtPetType.Text=value;
        }

        public string PetColour
        {
            get => txtPetColour.Text;
            set => txtPetColour.Text=value;
        }

        public string SearchValue
        {
            get =>txtSearch.Text;
            set => txtSearch.Text=value;
        }

        public bool IsEdit
        {
            get => isEdit;
            set => isEdit = value;
        }

        public bool IsSuccessful
        {
            get => isSuccessful;
            //set => isSuccessful=value;
            set { if (value == false)
                {
                    isSuccessful = true;
                }
                else
                {
                    isSuccessful = false;
                }
            }
        }

        public string Message
        {
            get => message;
            set => message=value;
        }

        //Events
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        //Methols
        public void SetPetListBindingSource(BindingSource petList)
        {
            dataGridView.DataSource = petList;
        }

        private void PetView_Load(object sender, EventArgs e)
        {

        }
    }
}
