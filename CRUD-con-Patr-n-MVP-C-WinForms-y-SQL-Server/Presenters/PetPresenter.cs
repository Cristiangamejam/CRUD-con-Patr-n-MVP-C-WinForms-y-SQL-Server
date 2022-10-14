using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server._Repositories;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Models;
using CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Views;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Presenters
{
    public class PetPresenter
    {
        //Fields
        private IPetView view;
        private IPetRepository repository;
        private BindingSource petsBindingSource;
        private IEnumerable<PetModel> petList;
        

        //Constructor
        public PetPresenter(IPetView view, IPetRepository repository)
        {
            this.petsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchPet;
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectedPetToEdit;
            this.view.DeleteEvent += DeleteSelectedPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;
            this.view.Pet+= Pet;
           // this.view.ShowVetsView += ShowVetsView;
            //Set pets bindind source
            this.view.SetPetListBindingSource(petsBindingSource);
            //Load pet list view
            LoadAllPetList();
            //Show view
            this.view.Show();
        }

        private void Pet(object sender, EventArgs e)
        {
            // IPantalla view = FrmPantalla.GetInstance((PetView)this.view.Form);// new PetView();
            IPantalla view = FrmPantalla.GetInstance((PetView)this.view);// new PetView();
          //  IPantallaRepository pantalla = new PantallaModel(sqlConnectionString);
            new PantallaPresenter(view);
        }

        
    


        //Methods
        private void LoadAllPetList()
        {
            petList = repository.GetAll();
            petsBindingSource.DataSource = petList;//Set data source.
        }

        private void SearchPet(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                petList = repository.GetByValue(this.view.SearchValue);
            else petList = repository.GetAll();
            petsBindingSource.DataSource = petList;
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanViewFields();
        }
        private void SavePet(object sender, EventArgs e)
        {
            var model = new PetModel();
            model.Id = Convert.ToInt32(view.PetId);
            model.Name = view.PetName;
            model.Type = view.PetType;
            model.Colours = view.PetColour;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit == true)
                {
                    repository.Edit(model);
                    view.Message = "Mascota editada correctamente";
                }
                else
                {
                    repository.Add(model);
                    view.Message = "Mascota agregada correctamente";
                }
                view.IsSuccessful = true;
                LoadAllPetList();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanViewFields()
        {
            view.PetId = "0";
            view.PetName = "";
            view.PetType = "";
            view.PetColour = "";
        }

        private void DeleteSelectedPet(object sender, EventArgs e)
        {
            try
            {
                var pet = (PetModel)petsBindingSource.Current;
                repository.Delete(pet.Id);
                view.IsSuccessful = true;
                view.Message = "Mascota eliminada correctamente";
                LoadAllPetList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "Un error ocurrio, la mascota no pudo elimnar la mascota \n" + ex.Message;
            }
        }

        private void LoadSelectedPetToEdit(object sender, EventArgs e)
        {
            var pet = (PetModel)petsBindingSource.Current;
            view.PetId = pet.Id.ToString();
            view.PetName = pet.Name;
            view.PetType = pet.Type;
            view.PetColour = pet.Colours;
            view.IsEdit = true;
        }
        private void AddNewPet(object sender, EventArgs e)
        {
            view.IsEdit = false;

        }
    }
}
