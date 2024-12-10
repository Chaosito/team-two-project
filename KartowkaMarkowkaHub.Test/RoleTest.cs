using Moq;
using KartowkaMarkowkaHub.Services.Roles;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Core.Abstractions.Repositories;

namespace KartowkaMarkowkaHub.Test
{
    public class RoleServiceTests
    {
        private readonly Mock<IRepository<Role>> _mockRoleRepository;
        private readonly RoleService _roleService;

        public RoleServiceTests()
        {
            _mockRoleRepository = new Mock<IRepository<Role>>();
            _roleService = new RoleService(_mockRoleRepository.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsMappedRoleDTOs()
        {
            // Arrange
            var roles = new List<Role>
            {
                new Role { Id = Guid.NewGuid(), Name = "Admin", Description = "Administrator role" },
                new Role { Id = Guid.NewGuid(), Name = "User", Description = "User role" }
            };

            // Мокаем метод GetAllAsync репозитория, чтобы он возвращал список ролей
            _mockRoleRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(roles);

            // Act
            var result = await _roleService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count()); // Проверяем, что вернулось 2 роли
            Assert.All(result, roleDto => Assert.IsType<GetRoleDTO>(roleDto)); // Проверяем, что все элементы являются GetRoleDTO
            Assert.Contains(result, roleDto => roleDto.Name == "Admin"); // Проверяем наличие роли "Admin"
            Assert.Contains(result, roleDto => roleDto.Description == "User role"); // Проверяем описание роли "User"
        }

        [Fact]
        public async Task GetAll_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            _mockRoleRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Role>());

            // Act
            var result = await _roleService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result); // Проверяем, что вернулся пустой список
        }
    }
}
