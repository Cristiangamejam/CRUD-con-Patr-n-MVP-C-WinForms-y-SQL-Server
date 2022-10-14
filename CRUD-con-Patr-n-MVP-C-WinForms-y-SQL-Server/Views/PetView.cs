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
            btnClose.Click += delegate { this.Close(); };
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Search
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Add new
            btnAddNew.Click += delegate {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePetList);
                tabControl1.TabPages.Add(tabPagePetDetail);
                tabPagePetDetail.Text = "Agregar nueva mascota";
            };
            //Edit 
            btnEdit.Click += delegate 
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePetList);
                tabControl1.TabPages.Add(tabPagePetDetail);
                tabPagePetDetail.Text = "Editar mascota";
            };
            //Save
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPagePetDetail);
                    tabControl1.TabPages.Add(tabPagePetList);
                }

                MessageBox.Show(Message);
            };
            //Cancel
            btnCancel.Click += delegate 
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePetDetail );
                tabControl1.TabPages.Add(tabPagePetList);
            };
            //Delete
            btnDelete.Click += delegate 
            {
                
                var result= MessageBox.Show("Esta seguro que quiere eliminar la mascota seleccioda?", "Advertencia",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(message);
                }
            };

            BtnShowVetsView.Click += delegate {
                Pet?.Invoke(this, EventArgs.Empty);
            };
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
            set => isSuccessful=value;
        }

        public string Message
        {
            get => message;
            set => message=value;
        }

        //public Form Form {
        //    get => instance;
        //    //set => instance=value;
        //}

        //Events
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ShowPetView2;
        public event EventHandler Pet;

        // public event EventHandler ShowPetView;
        //public event EventHandler ShowOwnerView;
        //public event EventHandler ShowVetsView;

        //Methols
        public void SetPetListBindingSource(BindingSource petList)
        {
            dataGridView.DataSource = petList;
        }

        private void PetView_Load(object sender, EventArgs e)
        {

        }

        //Singleton Pattern(open a single form instance)
        private static PetView instance;
        public static PetView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PetView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            
            return instance;
        }

        
    }
}
