using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    class Personal_Data_Acc
    {
        [Key]
        [ForeignKey("AccountOf")]
        public int AccountId { get; set; }
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        [Index(IsUnique = true)]
        [StringLength(200)]
        public string Email{ get; set; }
        public byte[] Photo { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public Account AccountOf { get; set; }
    }
}