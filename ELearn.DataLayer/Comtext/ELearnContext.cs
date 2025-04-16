using ELearn.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.DataLayer.Comtext
{
    public class ELearnContext : DbContext
    {
        public ELearnContext(DbContextOptions<ELearnContext> options):base(options)
        {

        }        
        public DbSet<CourseGroup> CourseGroups { get; set;}
        public DbSet<CourseSeason> CourseSeasons { get; set;}
        public DbSet<Course> Courses { get; set; }
        public DbSet<Episode> Episodes { get; set;}
    }
}
