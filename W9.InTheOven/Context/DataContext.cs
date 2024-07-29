﻿using Microsoft.EntityFrameworkCore;
using W9.InTheOven.Models.Entities;

namespace W9.InTheOven.Context
{
    /// <summary>
    /// Contesto dati.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Prodotti.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }
        /// <summary>
        /// Ingredienti.
        /// </summary>
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        /// <summary>
        /// Utenti.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }
        /// <summary>
        /// Ruoli.
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }
        /// <summary>
        /// Ordini.
        /// </summary>
        public virtual DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }
    }
}
