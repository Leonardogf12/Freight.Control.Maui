using System;
namespace freight.control.maui.Services
{
	public interface IAuthenticationService
	{
		Task LoginAsync(string email, string password);

		Task ResetPassword(string email);

		Task RegisterNewUser(string email, string password);
    }
}

