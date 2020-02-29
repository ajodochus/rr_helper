﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// Your custom recording code should go in this file.
// The designer will only add methods to this file, so your custom code won't be overwritten.
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;
using System.Net.Http;

using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace project_2.mailcare
{
	public partial class get_mail
	{
		/// <summary>
		/// This method gets called right after the recording has been started.
		/// It can be used to execute recording specific initialization code.
		/// </summary>
		/// 
		bool s_sleep = true;
		
		
		private  void Init()
		{

			//get_mail_via_subject(); //async, passes through immediately
			
			
			//delete_mail_by_id();
			Console.WriteLine("FIRST"); //prints sooner than pages
			 //just to get the output from Test()
			//Delay.Seconds(10);
		}
		
		static async void get_mail_via_subject()
		{
			var r = await get_mail_via_subject_task();
			r = r.ToString();
			JObject studentObj = JObject.Parse(r);
			var id = studentObj["data"][0]["id"];
			Ranorex.Report.Info("r: " + r);
			Ranorex.Report.Info("id: " + id.ToString());
		}
		
		static async Task<string> get_mail_via_subject_task()
		{
			var baseAddress = new Uri("https://mailix.xyz/api/");
			
			using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
			{
				httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/vnd.mailcare.v1+json");
				
				using(var response = await httpClient.GetAsync("emails?subject=vdogrrsub"))
				{
					string responseData = await response.Content.ReadAsStringAsync();
					return responseData;
				}
			}
		}
		
		static async void delete_mail_by_id()
		{
			var r = await delete_mail_by_id_task();
			Ranorex.Report.Info("r: " + r.ToString());
		}
		
		static async Task<string> delete_mail_by_id_task()
		{
			var baseAddress = new Uri("https://mailix.xyz/api/");
			
			using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
			{
				httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/vnd.mailcare.v1+json");
				
				using(var response = await httpClient.DeleteAsync("emails/795b63d0-e48d-4e02-b875-d0fffae4f211"))
				{
					string responseData = await response.Content.ReadAsStringAsync();
					return responseData;
				}
			}
		}

	}
}
