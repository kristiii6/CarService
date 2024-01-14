//using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace CarService.Models
{
    public class Client
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
        "Prenumele trebuie sa inceapa cu majuscula (ex. Vasile sau Ana")]

        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }
        [EmailAddress(ErrorMessage = "Email nevalid")]
        public string Email { get; set; }
        [RegularExpression(@"^[0][0-9]{9}$", ErrorMessage = "Numarul de telefon trebuie sa inceapa cu '0' si sa aiba 10 cifre.")]
        public string? Phone { get; set; }
        [Display(Name = "Numele intreg")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string Password { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
