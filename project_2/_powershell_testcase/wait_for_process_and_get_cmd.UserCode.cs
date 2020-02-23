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
using System.Management.Automation;
using System.Collections.ObjectModel;

using System.IO;

namespace project_2._powershell_testcase
{
	public partial class wait_for_process_and_get_cmd
	{
		
		int process_found = 0;
		static string  var_username = "vagrant";
		static string var_password = "vagrant";
		static string var_remote_ip_or_vmname = "vagrant-1";
		static string var_process = "vdogschedulercheckin";
		string var_process_cmd = "not available";
		string login_ps_script = "$Username = '" +var_username+"';" +
			"$Password = '"+var_password+"';" +
			"$Process = '"+var_process+"';" +
			"$pass = ConvertTo-SecureString -AsPlainText $Password -Force;" +
			"$Cred = New-Object System.Management.Automation.PSCredential -ArgumentList $Username,$pass;";
		

		/// <summary>
		/// This method gets called right after the recording has been started.
		/// It can be used to execute recording specific initialization code.
		/// </summary>
		private void Init()
		{
			// Your recording specific initialization code goes here.
		}

		public void wait_for_process()
		{
			
			
			PowerShell powerShell = PowerShell.Create();
			powerShell.AddScript(login_ps_script +
			                     "Invoke-Command -ComputerName "+var_remote_ip_or_vmname+" -ScriptBlock { Get-CimInstance Win32_Process -Filter \"name = '"+var_process+"'\" | select CommandLine} -credential $Cred");

			for (int i = 0; i < 30; i++) {
				if (process_found==0) {
					Collection<PSObject> PSOutput = powerShell.Invoke();
					Ranorex.Report.Info("count objects; " + PSOutput.Count);
					process_found = PSOutput.Count;
				} else{
					Ranorex.Report.Info("process found");
					break;
				}
			}
			
			
		}

		public void wait_for_process_async()
		{

			//HACK Verschiedene Möglichkeiten den Sriptblock einzulesen


			// [1] multiline
			/*
			string _script_block = "Write-Host \"Waiting for $Name\" -NoNewline" +
				"while ( (Get-Process -Name $Name -ErrorAction SilentlyContinue).Count -eq $NumberOfProcesses )"+
				"{"+
				"Write-Host '.' -NoNewline"+
				"Start-Sleep -Milliseconds 400"+
				"}"+
				"Wait-ForProcess -Name notepad -IgnoreAlreadyRunningProcesses";
			 */
			
			// [2] semicolon separated
			//string script_block = "start-sleep -s 20; get-service";
			
			// [3] ps1 script
			//string script_block = File.ReadAllText(@"invoke_start_explorer.ps1");
			
			

			
			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
				PowerShellInstance.AddScript(login_ps_script + "Invoke-Command -ArgumentList $Process -ComputerName "+var_remote_ip_or_vmname+" -ScriptBlock {"+File.ReadAllText(@"wait_for_process.ps1")+"} -credential $Cred");
				IAsyncResult result = PowerShellInstance.BeginInvoke();

				while (result.IsCompleted == false)
				{
					Ranorex.Report.Info("Waiting for pipeline to finish..." + result.IsCompleted.ToString());
					Thread.Sleep(500);
				}

				Ranorex.Report.Info("Finished!");
			}

		}

		public void get_cmd_parameter()
		{
			using (PowerShell powerShell = PowerShell.Create()){

				
				powerShell.AddScript(login_ps_script + "Invoke-Command -ComputerName "+var_remote_ip_or_vmname+" -ScriptBlock { Get-CimInstance Win32_Process -Filter \"name = '"+ var_process+".exe'\" | select CommandLine} -credential $Cred");
				
				Collection<PSObject> PSOutput = powerShell.Invoke();
				Ranorex.Report.Info("count objects; " + PSOutput.Count);
				foreach (PSObject outputItem in PSOutput)
				{
					if (outputItem != null)
					{
						var_process_cmd = outputItem.Properties["CommandLine"].Value.ToString();
						Ranorex.Report.Info("ps out: " + var_process_cmd);
					}
				}

				if (powerShell.Streams.Error.Count > 0)
				{
					Ranorex.Report.Failure("powershell stream error");
				}
			}
		}

		public void test_with_add_parameter()
		{
			// https://stackoverflow.com/questions/40013482/set-paramerters-in-scriptblock-when-executing-powershell-commands-with-c-sharp
			
			PowerShell ps = PowerShell.Create();
			ps.AddCommand("Invoke-Command");
			ps.AddParameter("ComputerName", var_remote_ip_or_vmname);
			ps.AddParameter("credential", File.ReadAllText(@"credentials.ps1"));
			
			
		}

        public void execute_cmd()
        {
        	//string sb =  @"start-process C:\Program Files (x86)\vdogServer\VDogSchedulerCheckIn.exe" /at:c "/rd:C:\vdServerArchive\VD_TMP_VD\654_50" "/DirRPrj:\test" "/Name:test" "/Backup:C:\vdServerArchive\test\BACKUP\test\58CC0116EF414719ACA02730BC02A386\20200218.000\\Backup.zip" "/CFile:C:\vdServerArchive\VD_TMP_VD\654_50\result.ini" "/Key:txYoMzRp+DS98uEYG9rkR9LONX3KAHxKMQEKv3OmJtLXj0+wEYmVXaLo7HaVzpdrV2CbtxIuwH0=" 
            PowerShell powerShell = PowerShell.Create();
			powerShell.AddScript(login_ps_script +
			                     "Invoke-Command -ComputerName "+var_remote_ip_or_vmname+" -ScriptBlock {iex "+var_process_cmd+"} -credential $Cred");
            var result = powerShell.Invoke();
            
            Ranorex.Report.Info("after invoke");

        }
		
		
	}
}