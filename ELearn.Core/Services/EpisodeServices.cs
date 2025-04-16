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
    public class EpisodeServices : IEpisode
    {
        private readonly ELearnContext _context;
        public EpisodeServices(ELearnContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateEpisode(Episode episode)
        {
            try
            {
                await _context.Episodes.AddAsync(episode);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

         public async Task<bool> DeleteEpisode(int id)
        {
            var episode = await GetEpisodeById(id);
            if (episode == null)
            {
                throw new Exception("This Course Not Found !");
            }
            try
            {
                episode.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public IEnumerable<Episode> GetEpisodes()
        {
            return _context.Episodes;
        }

         public async Task<Episode> GetEpisode(int id)
        {
            var episode = _context.Episodes.Find(id);
            if (episode == null)
            {
                throw new Exception("This Course Group Not Found...");
            }
            return episode;
        }
         public async Task<bool> UpdateEpisode(Episode episode)
        {
            try
            {
                _context.Episodes.Update(episode);
                await _context.SaveChangesAsync();
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
