using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdamTaskApplication.Data.Models;

namespace AdamTaskApplication.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }
        protected MainContext()
        {

        }

        public DbSet<Projects> projects { get; set; }
        public DbSet<Board> boards { get; set; }
        public DbSet<Files> files { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
