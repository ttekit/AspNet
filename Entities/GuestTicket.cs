using System.ComponentModel.DataAnnotations;

namespace mvc.Entities
{
    public class GuestTicket
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fill name, we should know this info abbout you")]
        public string Name { get; set; }
   
        [Required(ErrorMessage = "Fill phone pls, we will call, maybe...")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Fill email pls, we irl need this")]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Fill count, or what are you doing there")]
        public string ticketA { get; set; } 

        [Required(ErrorMessage = "Fill count, or what are you doing there")]
        public string ticketB { get; set; } 
        
        [Required(ErrorMessage = "Fill count, or what are you doing there")]
        public string ticketC { get; set; }

    }
}
