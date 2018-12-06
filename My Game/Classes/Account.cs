using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    class Account
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(200)]
        public string Login { get; set; }
        public string Password { get; set; }

        [Required]
        public Personal_Data_Acc Personal { get; set; }

    }
}