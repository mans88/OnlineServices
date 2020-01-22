using EvaluationServices.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationServices.DataLayer
{
    public class EvaluationContext : DbContext
    {
        public EvaluationContext()
        {
        }

        public EvaluationContext(DbContextOptions<EvaluationContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
                throw new System.ArgumentNullException(nameof(optionsBuilder));

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EvaluationDB;Trusted_Connection=True;");
            }
        }
        
        public DbSet<FormQuestionEF> FormQuestion { get; set; }
        public DbSet<QuestionEF> Questions { get; set; }
        public DbSet<QuestionPropositionEF> QuestionProposition { get; set; }

        public DbSet<FormResponseEF> FormResponse { get; set; }
        public DbSet<ResponseEF> Responses { get; set; }
        public DbSet<ResponsePropositionEF> ResponseProposition { get; set; }


    }
}
