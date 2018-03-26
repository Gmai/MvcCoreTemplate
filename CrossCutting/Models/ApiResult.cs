using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Models
{
	public class ApiResult<T>
	{
		public List<string> Errors { get; set; }
		public ApiResultStatus Status { get; set; }
		public T Value { get; set; }
		public int Count { get; set; }

		public ApiResult()
		{
			Errors = new List<string>();
			Status = ApiResultStatus.NONE;
		}
	}

	public enum ApiResultStatus {
		SUCCESS, FAIL, NONE
	}
}
