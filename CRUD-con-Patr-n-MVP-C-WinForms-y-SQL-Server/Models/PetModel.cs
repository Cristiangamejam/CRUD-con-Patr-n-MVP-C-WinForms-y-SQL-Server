using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_con_Patr_n_MVP_C_WinForms_y_SQL_Server.Models
{
    public class PetModel
    {
        //Fields
        private int id;
        private string name;
        private string type;
        private string colours;

        //Properties
        [DisplayName("Id Mascota")]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [DisplayName("Nombre de mascosta")]
        [Required(ErrorMessage = "El nombre de mascota es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de la mascota debe tener entre 3 y 50 caracteres")]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [DisplayName("Tipo de mascosta")]
        [Required(ErrorMessage = "El tipo de mascota es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El tipo de la mascota debe tener entre 3 y 50 caracteres")]

        public string Type
        {
            get => type;
            set => type = value;
        }

        [DisplayName("Color de mascosta")]
        [Required(ErrorMessage = "El color de mascota es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El color de la mascota debe tener entre 3 y 50 caracteres")]

        public string Colours
        {
            get => colours;
            set => colours = value;
        }
    }
}
