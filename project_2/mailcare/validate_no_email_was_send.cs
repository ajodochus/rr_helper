/*
 * Created by Ranorex
 * User: vagrant
 * Date: 29.02.2020
 * Time: 13:06
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

namespace project_2.mailcare
{
    /// <summary>
    /// Description of validate_no_email_was_send.
    /// </summary>
    [TestModule("658C15B0-5D98-4AC4-BCC1-CB1F329D0A48", ModuleType.UserCode, 1)]
    public class validate_no_email_was_send : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_no_email_was_send()
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
        	mailcare.Mailcare.verify_no_email_was_sent(@"vdogrr2@mailix.xyz", 30);
        }
    }
}
