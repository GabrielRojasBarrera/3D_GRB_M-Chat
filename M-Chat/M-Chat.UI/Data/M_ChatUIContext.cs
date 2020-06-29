using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using M_Chat.Models;

namespace M_Chat.UI.Data
{
    public class M_ChatUIContext : DbContext
    {
        public M_ChatUIContext (DbContextOptions<M_ChatUIContext> options)
            : base(options)
        {
        }

        public DbSet<M_Chat.Models.Tutor> Tutor { get; set; }
    }
}
