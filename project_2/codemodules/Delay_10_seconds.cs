/*
 * Created by Ranorex
 * User: vagrant
 * Date: 23.02.2020
 * Time: 05:42
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

namespace project_2.codemodules
{
    /// <summary>
    /// Description of Delay_.
    /// </summary>
    [TestModule("73C12313-8545-4329-A28C-564C2A225593", ModuleType.UserCode, 1)]
    public class Delay_10_seconds : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Delay_10_seconds()
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
        	Delay.Seconds(10);
        }
    }
}
