﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WodApp.Data.Domain;

namespace WodApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<WodMovements> Movement { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}