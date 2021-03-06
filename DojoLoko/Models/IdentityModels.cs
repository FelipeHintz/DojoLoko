﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DojoLoko.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Faixa> Faixa { get; set; }
        public DbSet<TipoDeAssociacao> TipodeAssociacao { get; set; }
        public DbSet<Aula> Aula { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}