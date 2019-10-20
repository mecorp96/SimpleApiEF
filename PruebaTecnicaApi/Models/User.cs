using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaApi.Models
{
    public class User
    {
        public Decimal Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string ToString()
        {
            return "id=" + Id + ";name=" + Name + ";lastname=" + LastName + ";address=" + Address + ";createdate=" + CreateDate + ";updatedate=" + UpdateDate;
        }
    }
}
