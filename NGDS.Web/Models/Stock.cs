﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NGDS.Web.Models
{
    public class Stock : EntityModelBase
    {
        public int Id { get; set; }

        public Drink Drink { get; set; }

        [Required]
        public int DrinkId { get; set; }

        [Required]
        [DisplayName("数量")]
        public int Amount { get; set; }

        [Required]
        [DisplayName("消費量")]
        public int Consumption { get; set; }

        [NotMapped]
        public int Remaining { get { return Amount - Consumption; } }
    }
}