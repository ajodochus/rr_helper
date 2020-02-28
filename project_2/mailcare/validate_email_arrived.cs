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
        	var test =  mailcare.Mailcare.get_mail_via_subject_task().Result;
        	JObject studentObj = JObject.Parse(test.ToString());
			string id = studentObj["data"][0]["id"].ToString();
			string sender_email = studentObj["data"][0]["sender"]["email"].ToString();
			//Ranorex.Report.Info("r: " + r);
			Ranorex.Report.Info("id: " + id.ToString());
			Ranorex.Report.Info("sender email: " + sender_email.ToString());
        	Thread.Sleep(10000);
        }
    }
}
