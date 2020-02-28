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
using System;
using System.Net.Http;

using System.Threading.Tasks;

namespace project_2.mailcare
{
	public partial class get_mail
	{
		/// <summary>
		/// This method gets called right after the recording has been started.
		/// It can be used to execute recording specific initialization code.
		/// </summary>

		
		
		private  void Init()
		{

			Test(); //async, passes through immediately

			Console.WriteLine("FIRST"); //prints sooner than pages
			Thread.Sleep(10000); //just to get the output from Test()
			Delay.Seconds(10);
		}
		
		static async void Test()
		{
			var r = await DownloadPage();
			Console.WriteLine(r.ToString());
			Ranorex.Report.Info("r: " + r.ToString());
		}
		
		static async Task<string> DownloadPage()
		{
			var baseAddress = new Uri("https://mailix.xyz/api/");
			
			using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
			{
				httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/vnd.mailcare.v1+json");
				
				using(var response = await httpClient.GetAsync("emails?subject=Vdog"))
				{
					string responseData = await response.Content.ReadAsStringAsync();
					return responseData;
				}
			}
		}
		
		
		

	}
}
