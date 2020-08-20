using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Chơi dại dữ rứa con !!!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Tau nói mi nghiêm túc chưa ???")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="Tau nói mi mi mi !!!")]
        public string Email { get; set; }
        public Department Department { get; set; }
        public string AvatarPath{ get; set; }

        internal class Get
        {
        }
    }
}
