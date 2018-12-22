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
    public class Account
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(200)]
        public string Login { get; set; }
        public string Password { get; set; }
        //public int? Personal_Data_AccId { get; set; }

        [Required]
        public virtual Personal_Data_Acc Personal { get; set; }
        public virtual Score Score { get; set; }
    }
}