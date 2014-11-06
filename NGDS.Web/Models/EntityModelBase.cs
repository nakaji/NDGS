using System;
using System.ComponentModel;

namespace NGDS.Web.Models
{
    public class EntityModelBase
    {
        [DisplayName("登録日")]
        public DateTime CreateDateTime { get; set; }

        [DisplayName("更新日")]
        public DateTime UpdateDateTime { get; set; }
    }
}