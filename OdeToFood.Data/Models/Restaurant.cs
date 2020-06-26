using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        //??? This is another way to dictate that new Restauratn being created is required
        // to have a value for Name property.
        [Required]
        public string Name { get; set; }


        //??? You can change the text that will be shown in the view
        [Display(Name = "Type of food")]
        public CusineType Cusine { get; set; }

        //??? If there were a password field, this can be used to hide 
        // the value being typed in.
        //[DataType(DataType.Password)]
    }
}
