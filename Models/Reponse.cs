using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuestionFC.Models;


public class Reponse
{
    [Key]
    public int ResponseId { get; set; }

    [Required(ErrorMessage = "Le nom du répondant est requis.")]
    public string? RepondentName { get; set; }

    [ForeignKey("Option")]
    public int OptionId { get; set; }

    public Option? Option { get; set; }
}
