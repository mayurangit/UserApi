using System.ComponentModel.DataAnnotations;

namespace UserApiApp.Model
{
	public class User
	{
		[Key]
        public int UserId { get; set; }
		[Required]public string FirstName { get; set; }

		[Required]public string LastName { get; set; }

		[Required]public string Email { get; set; }

		[Required]public string Password { get; set; }

        public bool Active { get; set; }=true;

		public DateTime CreatedOn { get; set; } = DateTime.Now;



    }
}
