using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using DS.Infrastructure.ClientControll.Mapping;

namespace DS.Infrastructure.ClientControll.Repository.Config
{
    public class ApplicationDBContext : DbContext
    {
        public IDbContextTransaction Transaction { get; private set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { }

        public IDbContextTransaction InitTransaction()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }

        public void SendChanges()
        {
            Save();
            Commit();
        }

        private void Save()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientePessoaFisicaMap());
        }
    }
}
