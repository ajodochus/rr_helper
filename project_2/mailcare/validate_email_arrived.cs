/*
 * Created by Ranorex
 * User: vagrant
 * Date: 28.02.2020
 * Time: 13:44
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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace project_2.mailcare
{
	/// <summary>
	/// Description of validate_email_arrived.
	/// </summary>
	[TestModule("2605909B-98EC-4F03-B8CF-7F39118C4AA0", ModuleType.UserCode, 1)]
	public class validate_email_arrived : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public validate_email_arrived()
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
			
			mailcare.Mailcare.wait_for_mail_with_api_paraemter_and_get_data(@"vdogrr2@mailix.xyz");
			
			Ranorex.Report.Info("id: " +TestSuite.Current.Parameters["email_id"]);
			Ranorex.Report.Info("email_subject: " +TestSuite.Current.Parameters["email_subject"]);
			Ranorex.Report.Info("email_sender: " +TestSuite.Current.Parameters["email_sender"]);
			Ranorex.Report.Info("email_receipt: " +TestSuite.Current.Parameters["email_receipt"]);
			Ranorex.Report.Info("email body: " + TestSuite.Current.Parameters["email_body"]);
			Ranorex.Report.Info("email attachment: " + TestSuite.Current.Parameters["email_attachment"]);

			
			
		}
	}
}
