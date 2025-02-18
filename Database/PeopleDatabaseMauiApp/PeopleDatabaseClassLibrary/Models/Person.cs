﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PeopleDatabaseClassLibrary.Models;

[Table("person")]
[Index("AdressId", Name = "fk_adress")]
public partial class Person
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [StringLength(20)]
    public string Name { get; set; } = null!;

    [StringLength(20)]
    public string Surname { get; set; } = null!;

    [Column(TypeName = "int(11)")]
    public int Age { get; set; }

    [Column("adresses_id", TypeName = "int(11)")]
    public int AdressesId { get; set; }

    [Column("adress_id", TypeName = "int(11)")]
    public int AdressId { get; set; }

    [ForeignKey("AdressId")]
    [InverseProperty("People")]
    public virtual Adress Adress { get; set; } = null!;
}
