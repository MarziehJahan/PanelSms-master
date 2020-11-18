﻿using Microsoft.EntityFrameworkCore;
using System;

namespace Panel.DAL
{
    public class PanelSimorghContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Initial Catalog=PanelSms;integrated security=True;");
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<Acquaintance> Acquaintances { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<PanelSimorgh> Panels { get; set; }
        public DbSet<TermsAcceptance> Terms { get; set; }
        public DbSet<UserPanel> users { get; set; }
    }
}
