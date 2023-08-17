using System.ComponentModel.DataAnnotations;

namespace ShowRoom_Management_System.Models
{
    public class Bikes
    {
         [Key]
            public int ChasisNo { get; set; }

            public string? BikeName { get; set; }
            public String? Brand { get; set; }

            public int ManufactureYear { get; set; }
            public string? Colour { get; set; }
            public Boolean? isElectric { get; set; }


        }
    }

