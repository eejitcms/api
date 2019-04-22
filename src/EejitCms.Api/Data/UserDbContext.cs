using EejitCms.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EejitCms.Api.Data
{
	public class UserDbContext : IdentityDbContext<User>
	{
		public UserDbContext(DbContextOptions options) : base(options)
		{
		}
	}
}
