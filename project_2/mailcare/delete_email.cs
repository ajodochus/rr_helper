/*
 * Created by Ranorex
 * User: vagrant
 * Date: 29.02.2020
 * Time: 09:25
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
    /// Description of delete_email.
    /// </summary>
    [TestModule("E544C677-7477-4E47-BEBE-808AEC12B020", ModuleType.UserCode, 1)]
    public class delete_email : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public delete_email()
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
        	mailcare.Mailcare.delete_email();
        
        }
    }
}
