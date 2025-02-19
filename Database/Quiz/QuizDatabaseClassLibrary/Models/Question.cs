using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizDatabaseClassLibrary.Models;

[Table("questions")]
public partial class Question
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("content", TypeName = "text")]
    public string Content { get; set; } = null!;

    [InverseProperty("Question")]
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
}
