using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestionFC.Models;

namespace Question.Data
{
    public class QuestionContext : DbContext
    {
        public QuestionContext (DbContextOptions<QuestionContext> options)
            : base(options)
        {
        }

        public DbSet<QuestionFC.Models.Question> Question { get; set; } = default!;
        public DbSet<QuestionFC.Models.Option> Option { get; set; } = default!;
        public DbSet<QuestionFC.Models.Reponse> Reponse { get; set; } = default!;
    }
    
    
    

}
