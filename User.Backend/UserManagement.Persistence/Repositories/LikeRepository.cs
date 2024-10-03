using Microsoft.EntityFrameworkCore;

using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;
using UserManagement.Persistence.Data;

namespace UserManagement.Persistence.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly LikeDbContext _context;

        public LikeRepository(LikeDbContext context)
        {
            _context = context;
        }

        public async Task AddLikeAsync(Like like)
        {
            var existingLike = await _context.Likes
                .FirstOrDefaultAsync(l => l.PostId == like.PostId && l.UserId == like.UserId);

            if (existingLike == null)
            {
                await _context.Likes.AddAsync(like);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveLikeAsync(Guid postId, Guid userId)
        {
            var like = await _context.Likes
                .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);

            if (like != null)
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }
    }
}
