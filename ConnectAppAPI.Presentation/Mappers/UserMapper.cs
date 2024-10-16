using ConnectAppAPI.DataAccess.Models;
using ConnectAppAPI.Presentation.DTOs;

namespace ConnectAppAPI.Presentation.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToUserDTO(this AspNetUser userModel)
        {
            return new UserDTO
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Description = userModel.Description
            };
        }
    }
}
