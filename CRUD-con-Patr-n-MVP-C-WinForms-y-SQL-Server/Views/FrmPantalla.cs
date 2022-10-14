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
    public partial class FrmPantalla : Form,IPantalla
    {
        //public Form Form
        //{
        //    get => instance;
        //    //set => instance=value;
        //}

        public FrmPantalla()
        {
            InitializeComponent();
            //BtnPet.Click += delegate {
            //    ShowPetView?.Invoke(this, EventArgs.Empty);
        }

        //Singleton Pattern(open a single form instance)
        private static FrmPantalla instance;
        public static FrmPantalla GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmPantalla();
                //instance.MdiParent =  parentContainer.MdiParent;
                if (parentContainer.MdiParent == null)
                {
                    instance.MdiParent = parentContainer;
                }
                else
                {
                    instance.MdiParent = parentContainer.MdiParent;
                }
                
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
    };
}

