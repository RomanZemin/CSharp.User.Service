using AutoMapper;

using UserManagement.Application.DTOs.Posts;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsForPostAsync(Guid postId)
        {
            var comments = await _commentRepository.GetCommentsForPostAsync(postId);
            return _mapper.Map<IEnumerable<CommentDTO>>(comments);
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsForPostPaginatedAsync(int pageNumber, int pageSize)
        {
            var comments = await _commentRepository.GetCommentsForPostPaginatedAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<CommentDTO>>(comments);
        }

        public async Task<CommentDTO> GetCommentByIdAsync(Guid commentId)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(commentId);
            return _mapper.Map<CommentDTO>(comment);
        }

        public async Task AddCommentToPostAsync(CreateCommentDTO comment)
        {
            var comment_mapped = _mapper.Map<Comment>(comment);
            await _commentRepository.AddCommentToPostAsync(comment_mapped);
        }

        public async Task DeleteCommentAsync(Guid commentId)
        {
            await _commentRepository.DeleteCommentAsync(commentId);
        }
    }
}
