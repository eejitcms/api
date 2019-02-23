using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EejitCMS.API.Models
{
	public class PageContext : DbContext
	{
		public PageContext(DbContextOptions<PageContext> options) : base(options) { }

		public DbSet<Page> Pages { get; set; }
	}
}
