using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GYMDAL.DAO;
using GYMDAL.Data;
using CrossCutting.Models;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace WebApi.Controllers
{
	[Produces("application/json")]
	[Route("api/AccountApi")]
	public class AccountApiController : Controller
	{
		private readonly GymContext _context;

		public AccountApiController(GymContext context)
		{
			_context = context;
		}

		[HttpDelete("DeleteAsync/{id}")]
		public async Task<ApiResult<bool>> DeleteAsync([FromRoute] string id)
		{
			ApiResult<bool> result = new ApiResult<bool>();

			try
			{
				using (TransactionScope transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
				{
					var user = await _context.Users.FindAsync(id);

					_context.Remove(user);

					int i = await _context.SaveChangesAsync();

					result.Value = await Task.FromResult(i == 1 ? true: false);

					transaction.Complete();

					result.Status = ApiResultStatus.SUCCESS;
				}

			}
			catch (Exception ex)
			{
				result.Status = ApiResultStatus.FAIL;
			}

			return await Task.FromResult(result);
		}

		[HttpGet("FindByIdAsync/{id}")]
		public async Task<ApiResult<GymUser>> FindByIdAsync(string id)
		{
			ApiResult<GymUser> result = new ApiResult<GymUser>();
			if (int.TryParse(id, out int userId))
			{
				result.Value = await _context.Users.FindAsync(userId);
				result.Status = ApiResultStatus.SUCCESS;
			}
			else
			{
				result.Status = ApiResultStatus.FAIL;
			}
			return result;
		}

		[HttpGet("FindByNameAsync/{id}")]
		public async Task<ApiResult<GymUser>> FindByNameAsync(string normalizedUserName)
		{
			ApiResult<GymUser> result = new ApiResult<GymUser>();
			result.Value = await _context.Users.AsAsyncEnumerable()
								.SingleOrDefault(p => p.UserName.Equals(normalizedUserName, StringComparison.OrdinalIgnoreCase));
			return await Task.FromResult(result);
		}

		[HttpPost("CreateAsync")]
		public async Task<ApiResult<bool>> CreateAsync([FromBody] GymUser user)
		{
			ApiResult<bool> result = new ApiResult<bool>();

			try
			{
				using (TransactionScope transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
				{
					user.PhoneNumber = "";
					_context.Add(user);

					await _context.SaveChangesAsync();
					transaction.Complete();

					result.Value = true;
					result.Status = ApiResultStatus.SUCCESS;
				}

			}
			catch (Exception ex)
			{
				result.Status = ApiResultStatus.FAIL;
			}

			return await Task.FromResult(result);
		}


	}
}