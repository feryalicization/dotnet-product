using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Role>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Role?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<Role> AddAsync(Role role) => _repository.AddAsync(role);

        public Task<Role> UpdateAsync(Role role) => _repository.UpdateAsync(role);

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
