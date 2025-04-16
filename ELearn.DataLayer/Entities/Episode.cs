using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.DataLayer.Entities
{
    public class Episode
    {
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        public string VideoName { get; set; }
        public string Time { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public bool IsFree { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        #region
        public CourseSeason CourseSeason { get; set; } 
        #endregion

    }
}
