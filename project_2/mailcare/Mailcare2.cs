/*
 * Created by Ranorex
 * User: vagrant
 * Date: 02.03.2020
 * Time: 12:08
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
using System.Net;

using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.IO;

using System.Web;

namespace project_2.mailcare
{
	/// <summary>
	/// Description of Mailcare2.
	/// </summary>
	[TestModule("6891E9E0-8CE2-4131-B3E8-F2C6F3A81438", ModuleType.UserCode, 1)]
	public class Mailcare2 : ITestModule
	{
		
		public static string receipt_1 = @"123_";
		public static string receipt_2 = @"321_";
		public static string sender = @"vdog_sender@test.de";
		public static string id_1 = "";
		public static string id_2 = "";
		public static string body_1 = "";
		
		static string var_base_uri = @"https://mailix.xyz/api/";
		static string content_type_mailcare = @"application/vnd.mailcare.v1+json";
		
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public Mailcare2()
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
			//get_id(receipt_1);
			//get_id(receipt_2);
			get_mail_content();

		}
		
		
		
		public void get_id(string receipt){

			for (int i = 0; i <= 10; i++)
			{
				
				Delay.Seconds(6);
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(var_base_uri + @"emails?inbox=" + receipt + "@mailix.xyz");
				request.Method = "GET";
				request.ContentType = content_type_mailcare;

				try {
					WebResponse webResponse = request.GetResponse();
					
					Stream webStream = webResponse.GetResponseStream();
					//StreamReader responseReader = new StreamReader(webStream, Encoding.ASCII);
					StreamReader responseReader = new StreamReader(webStream);
					string response = responseReader.ReadToEnd();
					Ranorex.Report.Info(response);
					JObject studentObj = JObject.Parse(response);
					TestSuite.Current.Parameters["id_" + receipt] = studentObj["data"][0]["id"].ToString();

					responseReader.Close();

					break;
				} catch (Exception e) {
					Ranorex.Report.Info("-----------------");
					Ranorex.Report.Info(e.Message);
				}

			}
			
		}
		
		public async void get_mail_content(){
			
			//HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://mailix.xyz/api/emails/cf2da1be-aabf-4934-9262-10fa2a40fe36");
			var baseAddress = new Uri(var_base_uri);
			
			using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
			{
				httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", content_type);
				
				using(var response = await httpClient. GetAsync("emails/" + TestSuite.Current.Parameters["email_id"]))
				{
					string responseData = await response.Content.ReadAsStringAsync();
					
					return responseData;
				}
			}
			
			
			
			
			
			using (var client = new HttpClient())
			{
				var response = client.GetAsync("http://google.com").Result;

				if (response.IsSuccessStatusCode)
				{
					var responseContent = response.Content;

					// by calling .Result you are synchronously reading the result
					string responseString = responseContent.ReadAsStringAsync().Result;

					Console.WriteLine(responseString);
				}
			}
		}
	}
}
