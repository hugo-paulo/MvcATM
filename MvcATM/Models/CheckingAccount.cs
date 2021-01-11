using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcATM.Models
{
    public class CheckingAccount
    {
        public int CheckingAccountID { get; set; } //this should be read-only

        [Required]
        //[StringLength(10,ErrorMessage = "Account Number must be between than 6 and 10 characters", MinimumLength = 6)] //this would be good for basic string range, there also Range attribute
        //digits between 6 to 10 numbers
        [RegularExpression(@"\d{6,10}", ErrorMessage = "Account Number must be between than 6 and 10 characters")]
        [Display(Name = "Account No. ")]
        public string AccountNumber { get; set; } //this should be read-only

        [Required]
        [Display(Name = "First Name: ")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [RegularExpression("^[ a-zA-Z ]*$", ErrorMessage = "First name can not contain number or symbols")] //can only handle common alphabet the regex \L or \w would work 
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        //this is readonly property
        //[Editable(false)] alternate to just using get
        [Display(Name = "Full Name: ")]
        public string Name
        {
            get
            {
                //return string.Format("{0} {1}: ", this.FirstName, this.LastName);
                return $@"{this.FirstName} {this.LastName}";
            }
        }

        //this will be determine by default depending on the OS
        //we can specify it in the Web.config file
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        /*
         * properties shortcut that can assign and concat values
         * This get is usefull to display a concat value (note! need to use not mapped attribute)
         * caution the set in this context will not work with out calling a function that will break the fullname string
         */
        //public string FullName
        //{
        //    get { return FirstName + LastName; }
        //    set
        //    {
        //        this.FirstName = splitForFirstName(FullName);
        //        this.LastName = splitForLastName(FullName);
        //    }

        //}

        //string splitForFirstName(string fullName)
        //{
        //    string[] fn = fullName.Split(' ');
        //    return fn[0];
        //}

        //string splitForLastName(string fullName)
        //{
        //    string[] fn = fullName.Split(' ');
        //    return fn[1];
        //}
    }
}