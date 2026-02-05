using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreateUser.Models
{
    public class User
    {
       

        [MaxLength(50, ErrorMessage = "The Name Should be Less than 10 Characters")]
        public string Name { get; set; }
        public string Email { get; set; }
       
        public int PhoneNumber { get; set; }

        public DateTime BOD { get; set; }



        [ForeignKey(nameof(CreateUser))]
        public int Id { get; set; }

        public CreateUser CreateUser { get; set; }

        

    }
}
