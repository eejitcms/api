using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace EejitCMS.API.Models
{
	public class Account
	{
		public string Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string PasswordSalt { get; set; }

		public DateTime CreatedOn { get; set; }
		public DateTime LastLogin { get; set; }

		public bool EmailVerified { get; set; }

		public static implicit operator AccountResult(Account account)
		{
			return new AccountResult (account);
		}

		public bool TrySetPassword (string password, out string reason)
		{
			reason = "";
			if (!ValidatePassword (password, out reason)) return false;

			byte [] salt = new byte [128 / 8];

			using (var rng = RandomNumberGenerator.Create ())
			{
				rng.GetBytes (salt);
			}

			byte [] key = KeyDerivation.Pbkdf2 (
				password,
				salt,
				KeyDerivationPrf.HMACSHA1,
				10000,
				256 / 8
			);

			PasswordHash = Convert.ToBase64String (key);
			PasswordSalt = Convert.ToBase64String (salt);
			return true;
		}

		public bool IsPassword(string password)
		{	
			// Generate hash using salt from password
			byte [] key_bytes = KeyDerivation.Pbkdf2 (
				password,
				Convert.FromBase64String(PasswordSalt),
				KeyDerivationPrf.HMACSHA1,
				10000,
				256 / 8
			);

			byte [] password_bytes = Convert.FromBase64String (PasswordHash);

			// Check if equal
			uint diff = (uint)password_bytes.Length ^ (uint)key_bytes.Length;
			for (int i = 0; i < password_bytes.Length && i < key_bytes.Length; i++)
			{
				diff |= (uint)(password_bytes [i] ^ key_bytes [i]);
			}
			return diff == 0;
		}
		
		private bool ValidatePassword(string password, out string reason)
		{
			byte allow_char_start = 33;
			byte allow_char_end = 126;

			// Min length 8 chars
			reason = "Password is below 8 characters";
			if (password.Length < 8) return false;
			// Must only contain allowed_chars
			reason = "Password contains invalid characters";
			if (password.Any (c => 
					Convert.ToByte(c) < allow_char_start 
					|| Convert.ToByte(c) > allow_char_end)) return false;
			return true;
		}
	}
}
