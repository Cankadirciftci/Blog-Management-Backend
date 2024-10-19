using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Dtos;
using BlogManagement.Models;

namespace BlogManagement.Mappers
{
    public static class LoginDtoMappers
    {
        public static LoginDto ToLoginDto(this User userModel){
            return new LoginDto
            {
                Username = userModel.Username,
                PasswordHash = userModel.PasswordHash
            };
        }
        
    }
}