using System.ComponentModel.DataAnnotations;
namespace QuestionFC.Models;


public class Option
{
    [Key]
    public int OptionId { get; set; }

    [Required(ErrorMessage = "Le texte de l'option est requis.")]
    public string OptionText { get; set; } = ""; // Ajoutez une valeur par défaut

    public int QuestionId { get; set; }
    public List<Reponse> Reponses { get; set; } = new List<Reponse>(); // Ajoutez une valeur par défaut
}
