using UserManagement.Application.DTOs.Posts;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task LikePostAsync(LikeDTO likecontent)
        {
            var like = new Like
            {
                PostId = likecontent.PostId,
                UserId = likecontent.UserId
            };

            await _likeRepository.AddLikeAsync(like);
        }

        public async Task UnLikePostAsync(LikeDTO likecontent)
        {
            await _likeRepository.RemoveLikeAsync(likecontent.PostId, likecontent.UserId);
        }
    }
}
