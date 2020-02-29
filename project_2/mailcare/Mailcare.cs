/*
 * Created by Ranorex
 * User: vagrant
 * Date: 28.02.2020
 * Time: 13:03
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using System.Net.Http;

using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace project_2.mailcare
{
	
	
	
	/// <summary>
	/// Description of Mailcare.
	/// </summary>
	[TestModule("66FAE167-3623-442E-947F-84D75487486B", ModuleType.UserCode, 1)]
	public class Mailcare : ITestModule
	{
		static int  count_obj = 0;
		
		
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public Mailcare()
		{
			// Do not delete - a parameterless constructor is required!
		}

		/// <summary>
		/// Performs the playback of actions in this module.
		/// </summary>
		/// <remarks>You should not call this method directly, instead pass the module
		/// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
		/// that will in turn invoke this method.</remarks>
		void ITestModule.Run()
		{
			TestSuite.Current.Parameters["email_id"] = "NA";
			for (int i = 0; i < 50; i++) {
				if (count_obj < 1) {
					wait_for_one_email_at_least();
					Thread.Sleep(5000);
					Ranorex.Report.Info("i: " + i.ToString());
				}  else	 {
					Ranorex.Report.Info("array >= 1");
					get_email_data_obj();
					Thread.Sleep(5000);
					break;
				}
			}
			
			if (TestSuite.Current.Parameters["email_id"] != "NA") {
				get_mail_body_with_id();
				Thread.Sleep(5000);
				
			}
			
		}
		

		public static async void wait_for_one_email_at_least()
		{
			var r = await get_mail_via_subject_task();
			JObject studentObj = JObject.Parse(r);
			count_obj = ((JArray)studentObj["data"]).Count;
		}
		
		static async void get_email_data_obj(){
			var r = await get_mail_via_subject_task();
			JObject studentObj = JObject.Parse(r);
			
			string email_id = studentObj["data"][0]["id"].ToString();
			string email_subject = studentObj["data"][0]["inbox"]["email"].ToString();
			string email_sender = studentObj["data"][0]["sender"]["email"].ToString();
			//Ranorex.Report.Info("r: " + r);
			Ranorex.Report.Info("id: " + email_id.ToString());
			TestSuite.Current.Parameters["email_id"] = email_id;
			TestSuite.Current.Parameters["email_subject"] = email_subject;
			TestSuite.Current.Parameters["email_sender"] = email_sender;
			
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
		

		static async void get_mail_body_with_id(){
			var r = await get_mail_body_with_id_task();
			
			
			Ranorex.Report.Info("body: " + r.ToString());
			
		}

		
		static async Task<string> get_mail_body_with_id_task()
		{
			var baseAddress = new Uri("https://mailix.xyz/api/");
			
			using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
			{
				httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "text/plain");
				
				using(var response = await httpClient.GetAsync("emails/" + TestSuite.Current.Parameters["email_id"]))
				{
					string responseData = await response.Content.ReadAsStringAsync();
					
					return responseData;
				}
			}
		}
	}
}
