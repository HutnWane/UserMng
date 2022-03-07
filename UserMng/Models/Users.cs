using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserMng.Models
{
    public class Users
    {
        public int id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string name { get; set; }

        [Required]
        [DisplayName("Description")]
        public string description { get; set; }

        [Required]
        [DisplayName("Email")]
        public string email { get; set; }

        [Required]
        [DisplayName("Password")]
        public string password { get; set; }

        [Required]
        [DisplayName("Confirm Password")]
        public string confirm_password { get; set; }

        public string groupID { get; set; }
        public string isActive { get; set; }


        public Users()
        {
            id = 1;
            name = "Agness Moeketsi";
            description = "Human Capital";
            email = "agnesmoeketsi@agility.com";
            password = "12356";
            confirm_password = "123456";
            groupID = "1";
            isActive = "N";
        }

        public Users(int id, string name, string description, string email, string password, string confirm_password)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.email = email;
            this.password = password;
            this.confirm_password = confirm_password;
            this.groupID = groupID;
            this.isActive = isActive;
        }
    }
}