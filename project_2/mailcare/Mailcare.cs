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
			Mouse.DefaultMoveTime = 300;
			Keyboard.DefaultKeyPressTime = 100;
			Delay.SpeedFactor = 1.0;
		}
/*		
		static async void get_mail_via_subject()
		{
			var r = await get_mail_via_subject_task();
			r = r.ToString();
			JObject studentObj = JObject.Parse(r);
			string id = studentObj["data"][0]["id"].ToString();
			Ranorex.Report.Info("r: " + r);
			Ranorex.Report.Info("id: " + id.ToString());

		}
*/		
		public static async Task<string> get_mail_via_subject_task()
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
	}
}
