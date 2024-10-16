using ConnectAppAPI.DataAccess.Models;

namespace ConnectAppAPI.Presentation.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }
       
        public string? Description { get; set; }

    }
}
