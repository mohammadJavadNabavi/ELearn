using ELearn.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.Core.Interfaces
{
    public interface ICourseSeason
    {
        Task<bool> CreateCourceSeason(CourseSeason courseSeason);
        IEnumerable<CourseSeason> GetCourceSeasons();
        Task<CourseSeason> GetCourseSeasonById(int id);
        Task<bool> UpdateCourceSeason(CourseSeason courseSeason);
        Task<bool> DeleteCourseSeason(int id);

    }
}
