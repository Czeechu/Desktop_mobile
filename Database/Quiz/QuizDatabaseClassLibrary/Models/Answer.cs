using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizDatabaseClassLibrary.Models;

[Table("answers")]
[Index("QuestionId", Name = "fk_question")]
public partial class Answer
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("question_id", TypeName = "int(11)")]
    public int? QuestionId { get; set; }

    [Column("content", TypeName = "text")]
    public string Content { get; set; } = null!;

    [Column("isCorrect")]
    public bool IsCorrect { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("Answers")]
    public virtual Question? Question { get; set; }
}
