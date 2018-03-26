using CrossCutting.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CrossCutting
{
    public static class Utils
    {
		public static async Task<Nullable<TReturn>> ApiPost<TReturn>(string url, object data, string datapass = "", bool isJson = false) where TReturn : struct
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://localhost:44379");
					HttpResponseMessage response = await client.PostAsJsonAsync(url, data);
					//HttpResponseMessage response = await client.PostAsync(url, data);
					response.EnsureSuccessStatusCode();
					if (response.IsSuccessStatusCode)
					{
						ApiResult<TReturn> result = await response.Content.ReadAsAsync<ApiResult<TReturn>>();
						if (result.Status == ApiResultStatus.SUCCESS)
						{
							return result.Value;
						}
						else
						{
							return null;
						}
					}
				}
			}
			catch (Exception ex)
			{
				//string message = ex.Message;
				//result.Status = ApiResultStatus.FAIL;
				//result.Errors.Add(message);
				//Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
				//Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("More error details - " + (sAPIBaseURL + apiurl)));
				//throw new ApplicationException(ex.ToString() + " - " + (sAPIBaseURL + apiurl));
			}

			return null;
		}

		public static async Task<Nullable<TReturn>> ApiDelete<TReturn>(string url) where TReturn : struct
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://localhost:44379");
					HttpResponseMessage response = await client.DeleteAsync(url);
					response.EnsureSuccessStatusCode();
					if (response.IsSuccessStatusCode)
					{
						ApiResult<TReturn> result = await response.Content.ReadAsAsync<ApiResult<TReturn>>();
						if (result.Status == ApiResultStatus.SUCCESS)
						{
							return result.Value;
						}
						else
						{
							return null;
						}
					}
				}
			}
			catch (Exception ex)
			{
				string message = ex.Message;
				//result.Status = ApiResultStatus.FAIL;
				//result.Errors.Add(message);
				//Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
				//Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("More error details - " + (sAPIBaseURL + apiurl)));
				//throw new ApplicationException(ex.ToString() + " - " + (sAPIBaseURL + apiurl));
			}

			return null;
		}

		public static async Task<TReturn> ApiGet<TReturn>(string url) where TReturn : class
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://localhost:44379");
					HttpResponseMessage response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					if (response.IsSuccessStatusCode)
					{
						ApiResult<TReturn> result = await response.Content.ReadAsAsync<ApiResult<TReturn>>();
						if (result.Status == ApiResultStatus.SUCCESS)
						{
							return result.Value;
						}
						else {
							return null;
						}
					}
				}
			}
			catch (Exception ex)
			{
				string message = ex.Message;
				//result.Status = ApiResultStatus.FAIL;
				//result.Errors.Add(message);
				//Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
				//Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception("More error details - " + (sAPIBaseURL + apiurl)));
				//throw new ApplicationException(ex.ToString() + " - " + (sAPIBaseURL + apiurl));
			}

			return null;
		}
	}
}
