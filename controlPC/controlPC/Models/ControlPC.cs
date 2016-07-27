using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace controlPC.Models
{
    [Table("t_PC_Infomations")]
    public class ControlPC
    {
        [Key]
        [Display(Name ="PC管理番号")]
        public int id { get; set; }
        [Display(Name = "IPアドレス")]
        public string ipAdress { get; set; }
        [Display(Name = "使用区分")]
        public int classification { get; set; }
        [Display(Name = "機種")]
        public string type { get; set; }
        [Display(Name = "型番")]
        public string typeNumber { get; set; }
        [Display(Name = "使用者")]
        public string userName { get; set; }
        [Display(Name = "PC名")]
        public string pcName { get; set; }
        [Display(Name = "備考")]
        public string memo { get; set; }
    }

    public class ControlPCDBContext:DbContext
    {
        public DbSet<ControlPC> ControlPCs { get; set; }
    }
}