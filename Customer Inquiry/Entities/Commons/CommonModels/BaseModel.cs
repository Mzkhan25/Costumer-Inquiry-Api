﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Commons
{
    public class BaseModel
    {
        // Base Model contains the basic properties, which are common in all classes

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)] public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}