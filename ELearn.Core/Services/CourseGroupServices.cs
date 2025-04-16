using ELearn.Core.Interfaces;
using ELearn.DataLayer.Comtext;
using ELearn.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.Core.Services
{
    public class CourseGroupServices : ICourseGroup
    {
        private readonly ELearnContext _context;
        public CourseGroupServices(ELearnContext context)
            {
             _context = context;    
            }
        public async Task<bool> CreateCourseGroup(CourseGroup courseGroup)
        {
            try
            {
                await _context.CourseGroups.AddAsync(courseGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteCourseGroup(int id)
        {
            var course = await GetCourseGroupById(id);
            if (course == null)
            {
                throw new Exception("This Course Not Found !");
            }
            try
            {
                course.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<CourseGroup> GetCourseGroupById(int id)
        {
            var CourseGroup = _context.CourseGroups.Find(id);
            if(CourseGroup==null)
            {
                throw new Exception("This Course Group Not Found...");
            }
            return CourseGroup;
        }

        public IEnumerable<CourseGroup> GetCourseGroups()
        {
            return _context.CourseGroups;
        }

        public async Task<bool> UpdateCourseGroup(CourseGroup courseGroup)
        {
            try
            {
                _context.CourseGroups.Update(courseGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
