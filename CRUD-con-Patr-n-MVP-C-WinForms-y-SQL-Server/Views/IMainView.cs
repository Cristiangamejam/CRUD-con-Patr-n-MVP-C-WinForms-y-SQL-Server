﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Views
{
    public interface IMainView
    {
        event EventHandler ShowPetView;
        event EventHandler ShowPantallaView;
    }
}
