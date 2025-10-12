using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olaru_Irina_Lab2.Models;

namespace Olaru_Irina_Lab2.Data
{
    public class Olaru_Irina_Lab2Context : DbContext
    {
        public Olaru_Irina_Lab2Context (DbContextOptions<Olaru_Irina_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Olaru_Irina_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Olaru_Irina_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Olaru_Irina_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
