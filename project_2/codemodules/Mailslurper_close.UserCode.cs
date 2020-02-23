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
namespace project_2.codemodules
{
	public partial class Mailslurper_close
	{
		/// <summary>
		/// This method gets called right after the recording has been started.
		/// It can be used to execute recording specific initialization code.
		/// </summary>
		private void Init()
		{
			// Your recording specific initialization code goes here.
		}



		public void kill()
		{
			Process[] MatchingProcesses = Process.GetProcessesByName("mailslurper");
			
			if (MatchingProcesses.Length >= 1){
				foreach (Process p in MatchingProcesses){ p.CloseMainWindow();}
			}
			if (MatchingProcesses.Length >= 1){
				MatchingProcesses = Process.GetProcessesByName("mailslurper");
				foreach (Process p in MatchingProcesses){p.Kill();}
			}
		}
		
		public static void checkRemainingAndClose(){
			// check for remaining KMS processes, try to close it or in the end, kill it
			
		}

	}
}
