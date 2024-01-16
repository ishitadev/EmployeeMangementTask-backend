﻿using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
