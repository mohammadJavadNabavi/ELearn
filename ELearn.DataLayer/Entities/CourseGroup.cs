using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.DataLayer.Entities
{
    public class CourseGroup
    {
        [Key]
        public int CourseGroupId { get; set; }
        public string CourseGroupName { get; set; }
        public bool IsDeleted { get; set; } = false;
        #region Relation
        public ICollection<Course> Courses { get; set; }
        

        #endregion
    }
}
