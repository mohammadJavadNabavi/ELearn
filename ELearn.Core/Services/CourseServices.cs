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
    public class CourseServices : ICourse
    {
        private readonly ELearnContext _context;
        public CourseServices(ELearnContext context)
        {
            _context = context;
        }
        public async Task<bool> UpdateCourse(Course course)
        {
            try
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses;
        }
        public async Task<bool> CreateCourse(Course course)
        {
            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteCourse(int id)
        {
            var course=await GetCourseById(id);
            if(course==null)
            {
                throw new Exception("This Course Not Found !");
            }
            try
            {
                course.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<Course> GetCourseById(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                throw new Exception("This Course Group Not Found...");
            }
            return course;
        }
    }
    
}
