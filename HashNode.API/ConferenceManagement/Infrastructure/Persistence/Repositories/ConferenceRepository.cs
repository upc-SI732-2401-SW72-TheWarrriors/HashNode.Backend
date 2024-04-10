using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using HashNode.API.ConferenceManagement.Domain.Repositories;
using HashNode.API.Shared.Infrastructure.Persistence.Data;
using HashNode.API.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HashNode.API.ConferenceManagement.Infrastructure.Persistence.Repositories
{
    public class ConferenceRepository : BaseRepository, IConferenceRepository
    {
        public ConferenceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Conference> FindConferenceByIdAsync(string id)
        {
            return await _context.Conferences.FindAsync(id);
        }

        public async Task<Conference> FindConferenceByTitleAsync(string title)
        {
            return await _context.Conferences.SingleOrDefaultAsync(e => e.Title == title);
        }


        public async Task<IEnumerable<Conference>> ListAllConferencesAsync()
        {
            return await _context.Conferences.ToListAsync();
        }

        public async Task CreateConferenceAsync(Conference newConference)
        {
            await _context.Conferences.AddAsync(newConference);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Conference updateConference)
        {
           _context.Conferences.Update(updateConference);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Conference deleteConference)
        {
            _context.Conferences.Remove(deleteConference);
            await _context.SaveChangesAsync();
        }

        public bool ConferenceExists(string conferenceId)
        {
            return _context.Conferences.Any(e => e.Id == conferenceId);
        }
    }
}
