/*
 * Created by Ranorex
 * User: vagrant
 * Date: 23.02.2020
 * Time: 04:59
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
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json; //nuget package
using System.Net.Http;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace project_2.codemodules
{
	/// <summary>
	/// Description of Mailslurper_server.
	/// </summary>
	[TestModule("4372DA50-7A55-4A1B-96DE-417D24A9AF33", ModuleType.UserCode, 1)]
	public class Mailslurper_server : ITestModule
	{
		
		
		string _server_call = "start";
		[TestVariable("9c4fc009-1816-4bab-8e59-aea135d54806")]
		public string server_call
		{
			get { return _server_call; }
			set { _server_call = value; }
		}
		
		
		string _api_url = "";
		[TestVariable("e77964fb-cc88-4548-9eaf-4f7d812be4f2")]
		public string api_url
		{
			get { return _api_url; }
			set { _api_url = value; }
		}
		
		
		string _send_test_mail = "";
		[TestVariable("025bba9b-bd98-4e1f-b12a-9e8aecdba392")]
		public string send_test_mail
		{
			get { return _send_test_mail; }
			set { _send_test_mail = value; }
		}
		
		public static bool ServerLaeuft = false;
		public static string server_process_name = "mailslurper";
		public static string path_to_mailslurper_exe = Path.Combine(Directory.GetCurrentDirectory(), @"mailslurper\mailslurper.exe");
		
		
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public Mailslurper_server()
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
			switch (server_call) {
				case "start":
					start_server();
					break;
				case  "shutdown":
					shutdown_server();
					break;
				case  "get mail":
					get_email();
					break;
				case  "send mail":
					send_mail();
					break;
				default:
					Ranorex.Report.Failure("mailslurper could not be started");
					break;
			}
			
		}

		public static void start_server()
		{
			
			//ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Users\vagrant\Documents\mailslurper-1.14.1-windows\mailslurper.exe");
			ProcessStartInfo startInfo = new ProcessStartInfo(path_to_mailslurper_exe);
			startInfo.Verb = "runas";
			startInfo.WorkingDirectory =@"C:\Users\vagrant\Documents\mailslurper-1.14.1-windows\";
			//startInfo.Arguments = "ui";
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.RedirectStandardError = true;
			Process process = new Process();
			process.StartInfo = startInfo;
			process.OutputDataReceived += CaptureOutput;
			process.ErrorDataReceived += CaptureError;
			process.Start();
			int ServerId = process.Id;
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
			for (int i=1;i<=60 ;i++ ) {
				Delay.Seconds(1);
				if (ServerLaeuft) {
					Ranorex.Report.Info("Mailslurper Läuft, weiter gehts ...");
					//process.CloseMainWindow();
					//process.Close();
					break;
				}
			}

		}
		
		public static void shutdown_server(){
			Process[] MatchingProcesses = Process.GetProcessesByName(server_process_name);
			
			if (MatchingProcesses.Length >= 1){
				foreach (Process p in MatchingProcesses){ p.CloseMainWindow();}
			}
			if (MatchingProcesses.Length >= 1){
				MatchingProcesses = Process.GetProcessesByName(server_process_name);
				foreach (Process p in MatchingProcesses){p.Kill();}
			}
		}
		
		public void get_email()
		{
			Ranorex.Report.Info("get mail");
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api_url);
			request.Method = "GET";
			request.ContentType = "application/json";
			//request.ContentLength = DATA.Length;
			//StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
			//requestWriter.Write(DATA);
			//requestWriter.Close();

			try {
				WebResponse webResponse = request.GetResponse();
				Stream webStream = webResponse.GetResponseStream();
				//StreamReader responseReader = new StreamReader(webStream, Encoding.ASCII);
				StreamReader responseReader = new StreamReader(webStream);
				string response = responseReader.ReadToEnd();
				Ranorex.Report.Info(response);
				
				JObject studentObj = JObject.Parse(response);
				var id = studentObj["mailItems"][0]["id"];
				var subject = studentObj["mailItems"][0]["subject"];
				var body = studentObj["mailItems"][0]["body"];
				
				Ranorex.Report.Info("id: " + id.ToString());
				Ranorex.Report.Info("subject: " + subject.ToString());
				Ranorex.Report.Info("body: " + body.ToString());
				responseReader.Close();
			} catch (Exception e) {
				Ranorex.Report.Info("-----------------");
				Ranorex.Report.Info(e.Message);
			}
		}
		
		public void send_mail()
		{
			try
			{
				
				MailMessage mail = new MailMessage();
				SmtpClient SmtpServer = new SmtpClient("127.0.0.1");
				mail.From = new MailAddress("from@test.de");
				mail.To.Add("test@test.de");
				mail.Subject = "slurpermail";
				mail.Body = "This is for testing SMTP mail from GMAIL";

				SmtpServer.Port = 25;
				SmtpServer.Credentials = new System.Net.NetworkCredential("", "");
				SmtpServer.EnableSsl = false;

				SmtpServer.Send(mail);
				Ranorex.Report.Info("mail Send");
				Delay.Seconds(5);
			}
			catch (Exception ex)
			{
				Ranorex.Report.Info(ex.ToString());
			}
		}
		
		static void CaptureOutput(object sender, DataReceivedEventArgs e)
		{
			ShowOutput(e.Data);
		}
		
		static void CaptureError(object sender, DataReceivedEventArgs e)
		{
			ShowOutput(e.Data);
		}
		
		static void ShowOutput(string data)
		{
			if (data != null)
			{
				Console.WriteLine("Received: {0}", data);
				//Mail collection page 1 retrieved" who=ServiceController
				if(data== @"Γç¿ http server started on 127.0.0.1:8081"){
					Console.WriteLine("helllooooooooooooooooooooooooooooooooooooooo");
					ServerLaeuft = true;
					//Codemodules.Helper.KmsServerLaeuft = true;
					
					
				}
			}
		}

	}
}
