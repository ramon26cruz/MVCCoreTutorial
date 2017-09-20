using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Web.ViewModels
{
    public class CreateAirplaneViewModel
    {
        public CreateAirplaneViewModel()
        {
            
        }
        public CreateAirplaneViewModel(Guid id, string name, string serialNumber, string model, string createdBy, DateTime createdDate)
        {
            Id = id;
            Name = name;
            SerialNumber = serialNumber;
            Model = model;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
        }
        public Guid Id { get; set; }
        [Description("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get;  set; }
        [Required(ErrorMessage = "Serial number is required")]
        public string SerialNumber { get; set; }
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    
}
