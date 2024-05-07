using System.ComponentModel.DataAnnotations;

namespace UserApiApp.Model
{
	public class UpdateUserDTO
	{
		public int UserId { get; set; }
		[Required] public string FirstName { get; set; }

		[Required] public string LastName { get; set; }

		[Required] public string Password { get; set; }
	}
}
