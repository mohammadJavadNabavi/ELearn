using ELearn.Core.Interfaces;
using ELearn.DataLayer.Comtext;
using ELearn.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.Core.Services
{
    public class CourseSeasonServices : ICourseSeason
    {
        private readonly ELearnContext _context;
        public CourseSeasonServices(ELearnContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateCourceSeason(CourseSeason courseSeason)
        {
            try
            {
                await _context.CourseSeasons.AddAsync(courseSeason);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteCourseSeason(int id)
        {
            var courseSeason = await GetCourseSeasonById(id);
            if (courseSeason  == null)
            {
                throw new Exception("This Course Not Found !");
            }
            try
            {
                courseSeason.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public IEnumerable<CourseSeason> GetCourceSeasons()
        {
            return _context.CourseSeasons;
        }

        public async Task<CourseSeason> GetCourseSeasonById(int id)
        {
            var courseSeason = _context.Courses.Find(id);
            if (courseSeason == null)
            {
                throw new Exception("This Course Group Not Found...");
            }
            return courseSeason;
        }

        public async Task<bool> UpdateCourceSeason(CourseSeason courseSeason)
        {
            try
            {
                _context.CourseSeasons.Update(courseSeason);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
