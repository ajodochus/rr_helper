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
using System.Windows.Forms;

using IniParser;
using IniParser.Model;

namespace project_2.lab
{
	public partial class ini_read_write
	{
		/// <summary>
		/// This method gets called right after the recording has been started.
		/// It can be used to execute recording specific initialization code.
		/// </summary>
		private void Init()
		{
			// Your recording specific initialization code goes here.
		}

		public void read()
		{
			
			/*
			 * erwartet wird eine Bezeichnung für eine ini File ohne extension .ini
			 * möglich ist "Server" oder eine 32er String bestehend aus z.B. "0304A6B6C101406EA6CD7DB39C8EE6B6"
			 * 
			 */
			
			bool ini_file_is
			
			string rx = @"[A-Z|\d]{32}";			
			Match match = Regex.Match(ini_file, rx);
			
			// check if ini file name has 32 chars containing A-Z|\d
			if (match.Success) {
				Ranorex.Report.Info("ini ist user ini");
			}
//
//			string appPath = Path.GetDirectoryName(Application.ExecutablePath);
//			Ranorex.Report.Info("exe path: " + appPath);	
//			string ini = Path.Combine(appPath, @"resources\"+ini_file+".ini");
//			var parser = new FileIniDataParser();
//			
//			// read file 
//			IniData data = parser.ReadFile(ini);
//			string value = data[section][key];
//			Ranorex.Report.Info(key + ": " + value );
//			
//			// write file
//			data[section][key] = "hello";
//			parser.WriteFile(ini, data);
//			
//			Ranorex.Report.Info(key + ": " + data[section][key] );
			
		}

	}
}
