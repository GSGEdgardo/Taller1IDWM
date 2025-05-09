using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller1.Src.DTOs;
using Taller1.Src.Repositories.Interfaces;
using Taller1.Src.Services.Interfaces;

namespace Taller1.Src.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapperService _mapperService;

        public UserService(IUserRepository userRepository, IMapperService mapperService)
        {
            _userRepository = userRepository;
            _mapperService = mapperService;
        }

        public async Task<bool> EditUser(int id, EditUserDto editUser)
        {
            var result = await _userRepository.EditUser(id, editUser);
            return result;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            var mappedUsers = _mapperService.UserToUserDto(users);
            return mappedUsers;
        }

        public async Task<bool> UpdateUserStatus(int id, bool status)
        {
            var existingUser = await _userRepository.GetUserById(id);
            if (existingUser == null)
            {
                return false;
            }

            if (existingUser.RoleId != 2)
            {
                return false;
            }

            existingUser.Status = status;
            return await _userRepository.SaveChanges();
        }

        public async Task<IEnumerable<UserDto>> GetAdmin()
        {
            var users = await _userRepository.GetAdmin();
            var mappedUsers = _mapperService.UserToUserDto(users);
            return mappedUsers;
        }

        public async Task<(bool success, string ErrorMessage)> ChangePassword(int id, PasswordDto changePasswordDto)
        {
            var existingUser = await _userRepository.GetUserById(id);

            if(existingUser == null){
                return (false, "El usuario no existe.");
            }
            var result = BCrypt.Net.BCrypt.Verify(changePasswordDto.OldPassword, existingUser.Password);
            
            if(!result){
                return (false, "La contraseña antigua es incorrecta.");
            }

            if(changePasswordDto.NewPassword != changePasswordDto.ConfirmNewPassword){
                return (false, "Las contraseñas no coinciden.");
            }

            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword, salt);
            existingUser.Password = passwordHash;

            var saveResult = await _userRepository.SaveChanges();
            if(!saveResult)
            {
                return (false, "Ocurrió un error inesperado.");
            }
            return (true, string.Empty);
        }
    }
}