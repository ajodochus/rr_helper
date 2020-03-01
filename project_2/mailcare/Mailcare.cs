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
using System.Net;

using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


using System.Net.Http;
using System.Web;
namespace project_2.mailcare
{
	
	
	
	/// <summary>
	/// Description of Mailcare.
	/// </summary>
	[TestModule("66FAE167-3623-442E-947F-84D75487486B", ModuleType.UserCode, 1)]
	public class Mailcare : ITestModule
	{
		static int  count_obj = 0;
		
		static string var_api_parameter = "";
		static string var_base_uri = @"https://mailix.xyz/api/";
		static string content_type_mailcare = @"application/vnd.mailcare.v1+json";
		static string content_type_plain = @"text/plain";
		static string content_type = "";
		
		public Mailcare()
		{
			// Do not delete - a parameterless constructor is required!
		}

		void ITestModule.Run()
		{
			
			
		}
		
		
			
		/// <summary>
		/// 
		/// newtonsoft.net.dll relativ zum Projekt ablegen: 
		/// - ordner "dll" im root anlegen und newtonsoft.net.dll ablegen
		/// - dll --> copy to output directory always
		/// - in der .csproj --> <HintPath>..\dll\Newtonsoft.Json.dll</HintPath> 
		/// 
		/// mailcare.Mailcare.wait_for_mail_with_api_paraemter_and_get_data(@"vdogrr2@mailix.xyz");
			
		///	Ranorex.Report.Info("id: " +TestSuite.Current.Parameters["email_id"]);
		///	Ranorex.Report.Info("email_subject: " +TestSuite.Current.Parameters["email_subject"]);
		///	Ranorex.Report.Info("email_sender: " +TestSuite.Current.Parameters["email_sender"]);
		///	Ranorex.Report.Info("email_receipt: " +TestSuite.Current.Parameters["email_receipt"]);
		///	Ranorex.Report.Info("email body: " + TestSuite.Current.Parameters["email_body"]);
		///	Ranorex.Report.Info("email attachment: " + TestSuite.Current.Parameters["email_attachment"]);
		/// </summary>
		/// <param name="api_parameter_inbox"></param>
		public static void wait_for_mail_with_api_paraemter_and_get_data(string api_parameter_inbox){
			var_api_parameter = api_parameter_inbox;
			TestSuite.Current.Parameters["email_id"] = "NA";
			for (int i = 0; i < 60; i++) {
				if (count_obj < 1) {
					wait_for_one_email_at_least();
					Thread.Sleep(1000);
					Ranorex.Report.Info("i: " + i.ToString());
				}  else if (i>0 && i<60 && count_obj>0)  {
					Ranorex.Report.Info("array >= 1");
					get_email_data_obj();
					Thread.Sleep(10000);
					break;
				} else {
					Ranorex.Report.Failure("email wurde nicht gefunden: " + var_api_parameter);
					break;
				}
			}
			
			if (TestSuite.Current.Parameters["email_id"] != "NA") {
				content_type = content_type_plain;
				get_mail_body();
				//content_type = content_type_mailcare;
				//get_mail_attachment_and_more();
				Thread.Sleep(5000);
			}
		}
		
		
		/// <summary>
		///  mailcare.Mailcare.verify_no_email_was_sent(@"vdogrr2@mailix.xyz", 30);
		/// </summary>
		/// <param name="api_parameter_inbox"></param>
		/// <param name="timeout"></param>
		public static void verify_no_email_was_sent(string api_parameter_inbox, int timeout){
			var_api_parameter = api_parameter_inbox;
			count_obj = 0;
			for (int i = 0; i <= timeout; i++) {
				if (count_obj < 1) {
					wait_for_one_email_at_least();
					Thread.Sleep(1000);
					Ranorex.Report.Info("email nicht in der Inbox " + i.ToString());
					
				}else if (i==timeout && count_obj < 1) {
					Ranorex.Report.Success("email wurde wie erwartet nicht versendet: " + api_parameter_inbox);
				}

				else {
					Ranorex.Report.Failure("email wurde  gefunden: " + api_parameter_inbox);
					break;
				}
				
				
			}
		}

		
		
		/// <summary>
		/// mailcare.Mailcare.delete_email();
		/// </summary>
		public static void delete_email()
		{

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(var_base_uri + @"emails/" + TestSuite.Current.Parameters["email_id"]);
			request.Method = "DELETE";
			request.ContentType = content_type_mailcare;

			try {
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)request.GetResponse();
				if (myHttpWebResponse.StatusCode == HttpStatusCode.OK){
					Ranorex.Report.Info("email gelöscht");
					
				} else {
					Ranorex.Report.Failure("email konnte nicht gelöscht werden: " + myHttpWebResponse.StatusCode.ToString());
				}
				myHttpWebResponse.Close();
			}

			catch(Exception e)
			{
				Console.WriteLine("\nThe following Exception was raised : {0}",e.Message);
				Ranorex.Report.Failure("email "+ TestSuite.Current.Parameters[""]+" konnte nicht gelöscht werden: ", e.Message);
			}

		}
		
		
		
		static async void wait_for_one_email_at_least()
		{
			count_obj = 0;
			var r = await get_mail_via_api_parameter_task();
			JObject studentObj = JObject.Parse(r);
			count_obj = ((JArray)studentObj["data"]).Count;
		}

		static async void get_email_data_obj()
		{
			
			var r = await get_mail_via_api_parameter_task();
			JObject studentObj = JObject.Parse(r);
			
			string email_id = studentObj["data"][0]["id"].ToString();
			string email_subject = studentObj["data"][0]["subject"].ToString();
			string email_sender = studentObj["data"][0]["sender"]["email"].ToString();
			string email_receipt = studentObj["data"][0]["inbox"]["email"].ToString();
			
			int count_attachment = ((JArray)studentObj["data"][0]["attachments"]).Count;
			if (count_attachment >= 1) {
				string email_attachment = studentObj["data"][0]["attachments"][0]["file_name"].ToString();
				TestSuite.Current.Parameters["email_attachment"] = email_attachment;
			} else {
				TestSuite.Current.Parameters["email_attachment"] = "not available";
			}
			

			TestSuite.Current.Parameters["email_id"] = email_id;
			TestSuite.Current.Parameters["email_subject"] = email_subject;
			TestSuite.Current.Parameters["email_receipt"] = email_receipt;
			TestSuite.Current.Parameters["email_sender"] = email_sender;
			
		}
		
		static async Task<string> get_mail_via_api_parameter_task()
		{
			var baseAddress = new Uri(var_base_uri);
			
			using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
			{
				httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/vnd.mailcare.v1+json");
				
				using(var response = await httpClient.GetAsync("emails?inbox=" + var_api_parameter))
				{
					string responseData = await response.Content.ReadAsStringAsync();
					
					return responseData;
				}
			}
		}
		
		
		
		
		static async void get_mail_body(){
			var r = await get_mail_with_content_type_task();
			TestSuite.Current.Parameters["email_body"] = r.ToString();
		}
		
		static async void get_mail_attachment_and_more(){
			var r = await get_mail_with_content_type_task();
			JObject studentObj = JObject.Parse(r);
			
			string email_attachment = studentObj["data"]["attachments"][0]["file_name"].ToString();
			TestSuite.Current.Parameters["email_attachment"] = email_attachment;

		}
		
		static async Task<string> get_mail_with_content_type_task()
		{
			var baseAddress = new Uri(var_base_uri);
			
			using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
			{
				httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", content_type);
				
				using(var response = await httpClient.GetAsync("emails/" + TestSuite.Current.Parameters["email_id"]))
				{
					string responseData = await response.Content.ReadAsStringAsync();
					
					return responseData;
				}
			}
		}
		
		
	}
}
