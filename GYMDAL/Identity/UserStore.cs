using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossCutting;
using GYMDAL.DAO;
using GYMDAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace GYMDAL.Identity
{
	public class UserStore : IUserStore<GymUser>, IUserPasswordStore<GymUser>
	{
		private readonly GymContext db;

		public UserStore(GymContext db)
		{
			this.db = db;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				db?.Dispose();
			}
		}

		public Task<string> GetUserIdAsync(GymUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Id.ToString());
		}

		public Task<string> GetUserNameAsync(GymUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.UserName);
		}

		public Task SetUserNameAsync(GymUser user, string userName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException(nameof(SetUserNameAsync));
		}

		public Task<string> GetNormalizedUserNameAsync(GymUser user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException(nameof(GetNormalizedUserNameAsync));
		}

		public Task SetNormalizedUserNameAsync(GymUser user, string normalizedName, CancellationToken cancellationToken)
		{
			return Task.FromResult((object)null);
		}

		public async Task<IdentityResult> CreateAsync(GymUser user, CancellationToken cancellationToken)
		{
			var result = await Utils.ApiPost<bool>("/api/AccountApi/CreateAsync", user);
			
			if(result??false)
				return await Task.FromResult(IdentityResult.Success);
			else
				return await Task.FromResult(IdentityResult.Failed( ));
		}

		public Task<IdentityResult> UpdateAsync(GymUser user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException(nameof(UpdateAsync));
		}

		public async Task<IdentityResult> DeleteAsync(GymUser user, CancellationToken cancellationToken)
		{
			var result = await Utils.ApiDelete<bool>("/api/AccountApi/DeleteAsync/"+ user.Id);

			if (result ?? false)
				return await Task.FromResult(IdentityResult.Success);
			else
				return await Task.FromResult(IdentityResult.Failed());
		}

		public async Task<GymUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
			var result = await Utils.ApiGet<GymUser>("/api/AccountApi/FindByIdAsync/" + userId);
			if (result==null)
			{
				return await Task.FromResult((GymUser)null);
			}
			else
			{
				return await Task.FromResult(result);
			}
		}

		public async Task<GymUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			return await db.Users
								.AsAsyncEnumerable()
								.SingleOrDefault(p => p.UserName.Equals(normalizedUserName, StringComparison.OrdinalIgnoreCase), cancellationToken);
		}

		public Task SetPasswordHashAsync(GymUser user, string passwordHash, CancellationToken cancellationToken)
		{
			user.PasswordHash = passwordHash;

			return Task.FromResult((object)null);
		}

		public Task<string> GetPasswordHashAsync(GymUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.PasswordHash);
		}

		public Task<bool> HasPasswordAsync(GymUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
		}
	}
}