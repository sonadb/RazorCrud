using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorCrud.Model;

namespace RazorCrud.Data
{
    public class RazorCrudContext : DbContext
    {
        public RazorCrudContext (DbContextOptions<RazorCrudContext> options)
            : base(options)
        {
        }

        public DbSet<RazorCrud.Model.Student> Student { get; set; } = default!;
    }
}
