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

using System.Diagnostics;

namespace project_2.copy_ranorex_to_vm
{
	public partial class run_remote
	{
		/// <summary>
		/// This method gets called right after the recording has been started.
		/// It can be used to execute recording specific initialization code.
		/// </summary>
		private void Init()
		{
			// Your recording specific initialization code goes here.
		}

		public void remote()
		{
			string environment_var = Environment.GetEnvironmentVariable("OS");

			Process p = new Process();
			p.StartInfo.Verb = "runas";
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.RedirectStandardError = true;
			p.StartInfo.RedirectStandardInput = true;
			p.StartInfo.FileName = @"PsExec.exe";
			//
			p.StartInfo.Arguments = "\\\\vagrant-10 -u vagrant -p vagrant -nobanner -accepteula -i powershell -command \"D:\\dest\\debug\\ranorex_playground.exe /rf:d:\\reports\\report.rxlog /rc:remote\"";
			p.OutputDataReceived += CaptureOutput;
			p.ErrorDataReceived += CaptureError;
			p.Start();
			p.BeginOutputReadLine();
			p.BeginErrorReadLine();

			// string output = p.StandardOutput.ReadToEnd();
			// Ranorex.Report.Info("remote: " + output);
			// Ranorex.Report.Info(output);
			// string errormessage = p.StandardError.ReadToEnd();
//
			p.WaitForExit();
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
				Ranorex.Report.Info("Received: {0}", data);

				if(Regex.IsMatch(data, @"\bstarted\b")){
					Console.WriteLine("server is running on localhost");
					//ServerLaeuft = true;
				}
			}
		}

	}
}