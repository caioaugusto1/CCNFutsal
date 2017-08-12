using ColaComNois.Context.DB;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace ColaComNois.Context
{
    public class ColaComNoisContext : DbContext
    {
        public ColaComNoisContext()
            : base("ColaComNoisEdmx")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CCN_Rateios>().HasRequired(m => m.CCN_Despesas);
            modelBuilder.Entity<CCN_Rateios>().HasRequired(m => m.CCN_Jogadores);

            modelBuilder.Entity<CCN_Jogos>().HasRequired(m => m.CCN_Adversarios);

            //base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<CCN_Jogadores> Jogadores { get; set; }
        public virtual DbSet<CCN_Despesas> Despesas { get; set; }
        public virtual DbSet<CCN_Rateios> Rateios { get; set; }
        public virtual DbSet<CCN_Adversarios> Adversarios { get; set; }
        public virtual DbSet<CCN_Logins> Logins { get; set; }
        public virtual DbSet<CCN_Jogos> Jogos { get; set; }


        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}