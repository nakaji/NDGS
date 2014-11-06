using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NGDS.Web.Models
{
    public class Drink : EntityModelBase
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("銘柄")]
        public String Name { get; set; }

        [Required]
        [DisplayName("容量")]
        public int Volume { get; set; }
    }
}