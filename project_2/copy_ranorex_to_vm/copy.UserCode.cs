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
using System.IO;
using System.Collections.ObjectModel;
using System.Management.Automation;

using System.Diagnostics;

namespace project_2.copy_ranorex_to_vm
{
	public partial class copy
	{
		
		string source_base = @"C:\Users\vagrant\Documents\rr_helper\project_2\bin\Debug";
		string destination_base = @"\\vagrant-10\dest\debug";
		string exceptions = "Reports";
		
		
		/// <summary>
		/// This method gets called right after the recording has been started.
		/// It can be used to execute recording specific initialization code.
		/// </summary>
		private void Init()
		{
			// Your recording specific initialization code goes here.
		}

		public void copy_file()
		{
			PowerShell powerShell = PowerShell.Create();
			powerShell.AddScript(@"Copy-Item C:\df \\vagrant-10\dest -Recurse");
			powerShell.Invoke();
		}

		public void copy_dir_with_response()
		{
			string sb ="Copy-Item -Path (Get-Item -Path "+source_base+ "\\* -Exclude ('Reports')).FullName -Destination "+destination_base+" -Recurse -Force";
				
				using (PowerShell powerShell = PowerShell.Create()){
				
				//powerShell.AddScript(@"Copy-Item "+source_base+ @" \\vagrant-10\dest -Exclude 'Reports' -Recurse -Force");
				powerShell.AddScript(sb);
				powerShell.Invoke();
				
//				Collection<PSObject> PSOutput = powerShell.Invoke().;
//				Ranorex.Report.Info("count objects; " + PSOutput.Count);
//				foreach (PSObject outputItem in PSOutput)
//				{
//					if (outputItem != null)
//					{
//						// 
//					}
//				}
			}
		}

		public void filecopy()
		{
			
			
			List<string> li = new List<string>();
			li.Add(@"project_2.exe");
			li.Add(@"project_2.exe");

			try
			{
				File.Copy("", "");
				Ranorex.Report.Info("Datei im try kopiert");
			}
			catch (IOException e)
			{
				if (e.Message.Contains("in use"))
				{
					Process p = new Process();
					p.StartInfo.UseShellExecute = false;
					p.StartInfo.RedirectStandardOutput = true;
					p.StartInfo.FileName = "cmd.exe";
					//p.StartInfo.Arguments = "/C copy \"" + source_file + "\" \"" + destination_file + "\"";
					p.Start();
					Console.WriteLine(p.StandardOutput.ReadToEnd());
					p.WaitForExit();
					p.Close();
					Ranorex.Report.Info("datei im catch kopiert");
				}
			}
			
		}

	}
}
