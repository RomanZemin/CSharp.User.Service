using AutoMapper;
using UserManagement.Application.DTOs.Posts;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;
using UserManagement.Application.Exceptions;

namespace UserManagement.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;  // Репозиторий для работы с постами
        private readonly IUserRepository _userRepository;  // Репозиторий для работы с пользователями

        public PostService(
            IMapper mapper,
            IPostRepository postRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<PostDTO>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            if (posts == null || !posts.Any()) throw new PostNotFoundException("Посты не найдены");
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task<PostDTO> GetPostByIdAsync(Guid postId)
        {
            var post = await _postRepository.GetByIdAsync(postId);
            if (post == null) throw new PostNotFoundException($"Пост с ID {postId} не найден");
            return _mapper.Map<PostDTO>(post);
        }

        public async Task<IEnumerable<PostDTO>> GetAllPostsPaginatedAsync(int pageNumber, int pageSize)
        {
            var posts = await _postRepository.GetPaginatedAsync(pageNumber, pageSize);
            if (posts == null || !posts.Any()) throw new PostNotFoundException("Посты не найдены");
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task CreateNewPostAsync(PostDTO PostRequest)
        {
            var user = await _userRepository.GetUserByIdAsync(PostRequest.UserId);
            if (user == null) throw new InvalidOperationException("Пользователь не найден");

            var post = _mapper.Map<Post>(PostRequest);
            await _postRepository.CreateAsync(post);
        }

        public async Task ChangeContentPostAsync(Guid postId, string content)
        {
            var post = await _postRepository.GetByIdAsync(postId);
            if (post == null) throw new PostNotFoundException($"Пост с ID {postId} не найден");

            post.Content = content;
            post.UpdatedAt = DateTime.UtcNow;
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(Guid postId)
        {
            var post = await _postRepository.GetByIdAsync(postId);
            if (post == null) throw new PostNotFoundException($"Пост с ID {postId} не найден");

            await _postRepository.DeleteAsync(post);
        }
    }
}
