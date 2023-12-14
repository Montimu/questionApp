using System.ComponentModel.DataAnnotations;
namespace QuestionFC.Models;


public class Question
{
    public int QuestionId { get; set; }

    [Required(ErrorMessage = "Le champ Texte de la question est requis.")]
    public string QuestionText { get; set; } = ""; // Ajoutez une valeur par défaut

    
    public List<Option> Options { get; set; } = new List<Option>(); // Ajoutez une valeur par défaut
}
