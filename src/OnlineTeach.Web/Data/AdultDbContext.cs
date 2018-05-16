using Microsoft.EntityFrameworkCore;
using OnlineTeach.Web.Data.Adult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineTeach.Web.Models.ManageViewModels;
using OnlineTeach.Web.Models.AdultViewModels;
using OnlineTeach.Web.Data.Cource;

namespace OnlineTeach.Web.Data
{
    public class AdultDbContext : DbContext
    {
        public AdultDbContext(DbContextOptions<AdultDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<TeacherApply> TeacherApplies { get; set; }
        public DbSet<CourceItem> CourceItems { get; set; }
        public DbSet<CourceOutLine> courceOutLines { get; set; }
        public DbSet<OnlineTeach.Web.Models.AdultViewModels.CourceItemViewModel> CourceItemViewModel { get; set; }
    }
}
