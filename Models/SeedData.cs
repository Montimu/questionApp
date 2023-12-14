using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Question.Data;
namespace QuestionFC.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new QuestionContext(serviceProvider.GetRequiredService<DbContextOptions<QuestionContext>>()))
        {
            // Vérifie si la base de données a déjà été créée
            context.Database.EnsureCreated();

            // Si des questions existent déjà, ne faites rien
            if (context.Question.Any())
            {
                return;
            }

            SeedDatabase(context);
        }
    }

    private static void SeedDatabase(QuestionContext context)
    {
        var questions = new Question[]
        {
            new Question
            {
                QuestionText = "Quel est votre club de football préféré ?",
                Options = new List<Option>
                {
                    new Option { OptionText = "Real Madrid" },
                    new Option { OptionText = "Barcelona" },
                    new Option { OptionText = "Manchester United" },
                    new Option { OptionText = "Bayern Munich" }
                }
            },
            new Question
            {
                QuestionText = "Quel est votre joueur préféré ?",
                Options = new List<Option>
                {
                    new Option { OptionText = "Lionel Messi" },
                    new Option { OptionText = "Cristiano Ronaldo" },
                    new Option { OptionText = "Neymar" },
                    new Option { OptionText = "Mohamed Salah" }
                }
            },
            // Ajoutez d'autres questions ici...
        };

        context.Question.AddRange(questions);
        context.SaveChanges();

        foreach (var question in questions)
        {
            var respondents = new Reponse[]
            {
            new Reponse { RepondentName = "John Doe", OptionId = question.Options.First().OptionId },
            new Reponse { RepondentName = "Jane Smith", OptionId = question.Options.Last().OptionId },
                // Ajoutez d'autres réponses au besoin
            };

            context.Reponse.AddRange(respondents);
            context.SaveChanges();
        }
    }
    }