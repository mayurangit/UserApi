using System.ComponentModel.DataAnnotations;

namespace UserApiApp.Model
{
	public class LoginDTO
	{
		[Required] public string Email { get; set; }

		[Required] public string Password { get; set; }
	}
}
