/*
 * Created by Ranorex
 * User: vagrant
 * Date: 01.02.2020
 * Time: 08:46
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

using System.Collections.ObjectModel;
using System.Management.Automation;

namespace project_2.codemodules
{
	/// <summary>
	/// Description of Powershell_handler.
	/// </summary>
	[TestModule("553498D3-1929-4F46-A8BD-CB79E732D371", Ranorex.Core.Testing.ModuleType.UserCode, 1)]
	public class Powershell_handler : ITestModule
	{
		public static string var_ps_return {get;set;}
		
		
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public Powershell_handler()
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


		public static void powershell_exec_local_or_remote(string action, string var_machine_user, string var_machine_password, string var_machine_name_or_ip){

			using (PowerShell powerShell = PowerShell.Create()){
				
				// https://stackoverflow.com/questions/12895503/how-to-read-powershell-exit-code-via-c-sharp
				
				// VDogSchedularCheckIn.exe
				
				// Alternative -> Script einlesen:
				// string script = File.ReadAllText(@"C:\Scripts\script1.ps1");
				
				if (action == "get_vdogschedulercheckin_cmd") {
					
					powerShell.AddScript("$Username = '"+var_machine_user+"';" +
					                     "$Password = '"+var_machine_password+"';" +
					                     "$pass = ConvertTo-SecureString -AsPlainText $Password -Force;" +
					                     "$Cred = New-Object System.Management.Automation.PSCredential -ArgumentList $Username,$pass;" +
					                     "Invoke-Command -ComputerName "+var_machine_name_or_ip+" -ScriptBlock { Get-CimInstance Win32_Process -Filter \"name = 'notepad.exe'\" | select CommandLine} -credential $Cred");
					Collection<PSObject> PSOutput = powerShell.Invoke();
					Ranorex.Report.Info("count objects; " + PSOutput.Count);
					foreach (PSObject outputItem in PSOutput)
					{
						// get the commandline atribute of an explicit process (local or remote)
						if (outputItem != null)
						{
							// es wird als Rückgabewert der "comandline" Parameter des Prozesses erwartet
							Ranorex.Report.Info("cmd Aufruf der VDogSchedularCheckIn.exe in der lokalen Variable 'var_ps_return' gespeichert");
							var_ps_return = outputItem.Properties["CommandLine"].Value.ToString();
							Ranorex.Report.Info("cmd VDogSchedularCheckIn.exe: " + var_ps_return);
						}
					}
					
				} else if (action == "start_vdogschedulercheckin") {
					
					powerShell.AddScript("$Username = '"+var_machine_user+"';" +
					                     "$Password = '"+var_machine_password+"';" +
					                     "$pass = ConvertTo-SecureString -AsPlainText $Password -Force;" +
					                     "$Cred = New-Object System.Management.Automation.PSCredential -ArgumentList $Username,$pass;" +
					                     "Invoke-Command -ComputerName "+var_machine_name_or_ip+" -ScriptBlock {"+var_ps_return+"} -credential $Cred");
					Collection<PSObject> PSOutput = powerShell.Invoke();
					// es wird als Rückgabewert der "comandline" Parameter des Prozesses erwartet
					Ranorex.Report.Info("vdogschedulercheckin wurde erneut ausgeführt");
				}
				
				
				if (powerShell.Streams.Error.Count > 0)
				{
					Ranorex.Report.Failure(powerShell.Streams.Error.ToString());
					
				}

			}
		}

	}
}
