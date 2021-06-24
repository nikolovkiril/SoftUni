namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IUsersService
    {
        string GetUserId  (string username , string password);

        void Create(string username, string password, string email);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email); 
    }
}
