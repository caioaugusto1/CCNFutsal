using ColaComNois.Context.DB;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace ColaComNois.Context
{
    public class ColaComNoisContext : DbContext
    {
        public ColaComNoisContext()
            : base("MySql_ColaComNois_")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ccn_rateios>().HasRequired(m => m.ccn_despesas);
            modelBuilder.Entity<ccn_rateios>().HasRequired(m => m.ccn_jogadores);
            modelBuilder.Entity<ccn_jogos>().HasRequired(m => m.ccn_adversarios);

            //base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<ccn_jogadores> Jogadores { get; set; }
        public virtual DbSet<ccn_despesas> Despesas { get; set; }
        public virtual DbSet<ccn_rateios> Rateios { get; set; }
        public virtual DbSet<ccn_adversarios> Adversarios { get; set; }
        public virtual DbSet<ccn_logins> Logins { get; set; }
        public virtual DbSet<ccn_jogos> Jogos { get; set; }


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