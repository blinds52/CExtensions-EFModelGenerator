﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace nameFormatters
{

    [Table("Person")]
    public partial class Person
    {

        [Key]
        [Column("Pers_Id")]
        public long ID { get; set; }  // Person.Pers_Id (PrimaryKey)

        [Column("Person")]
        public string Person_Person { get; set; }   // Person.Person

        [Required]
        [Column("PERS_LAST_NAME")]
        public string LastName { get; set; }   // Person.PERS_LAST_NAME

    }

}
