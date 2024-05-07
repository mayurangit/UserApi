using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApiApp.Data;
using UserApiApp.Model;

namespace UserApiApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly APIDbContext _db;

        public UserController(APIDbContext db)
        {
            _db = db;
        }

        [HttpGet]
		[Route("GetAllUsers")]
		public IActionResult getAll()
		{
				List<User> users = _db.Users.ToList();
				if (users == null)
				{
					return NotFound();
				}
				return Ok(users);
			

		}

		[HttpGet]
		[Route("GetUserByID")]
		public IActionResult get(int id)
		{
			var user = _db.Users.Find(id) as User;
			if(user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}

		[HttpPost]
		[Route("Registration")]

		public IActionResult Add(RegistrationDTO registrationDTO)
		{
			if(ModelState.IsValid)
			{
				var objuser = _db.Users.FirstOrDefault(x => x.Email == registrationDTO.Email);
				if(objuser == null) {
							_db.Users.Add(new User
							{
								FirstName = registrationDTO.FirstName,
								LastName = registrationDTO.LastName,
								Email = registrationDTO.Email,
								Password = registrationDTO.Password
							});
							_db.SaveChanges();
							return Ok("User Registered Successfully");
				}
				else
				{
							return BadRequest("User E-Mail Already Registered");
				}
			}
			return BadRequest(ModelState);

		}

		[HttpPost]
		[Route("Login")]
		public IActionResult login(LoginDTO loginDTO)
		{
			var dbuser = _db.Users.FirstOrDefault(x=>x.Email == loginDTO.Email && x.Password==loginDTO.Password);
			if(dbuser == null)
			{
				return NotFound("No user found, Please check your login details");
			}
			{
				return Ok(dbuser);
			}
			
		}

		[HttpPut]
		[Route("Update")]
		public IActionResult update(UpdateUserDTO updateUserDTO)
		{
			if (ModelState.IsValid)
			{
				var objuser = _db.Users.FirstOrDefault(x => x.UserId == updateUserDTO.UserId);
				if (objuser != null)
				{
					_db.Users.Update(new User
					{
						FirstName = updateUserDTO.FirstName,
						LastName = updateUserDTO.LastName,
						Email= objuser.Email,//Email can't change
						Password = updateUserDTO.Password
					});
					_db.SaveChanges();
					return Ok("User Updated Successfully");
				}
				else
				{
					return BadRequest("Invalid User");
				}
			}
			return BadRequest(ModelState);

		}

		[HttpDelete]
		[Route("DeletebyID")]

		public IActionResult delete(int id) {
			
			var dbuser = _db.Users.FirstOrDefault(x=>x.UserId == id);
			if (dbuser != null)
			{
				_db.Users.Remove(dbuser); 
				_db.SaveChanges();
				return Ok("User Deleted Successfully");
			}
			return BadRequest("No user found");
			
		
		}

	}
}