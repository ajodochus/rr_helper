﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
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
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace project_2._powershell_testcase
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The wait_for_process_and_get_cmd recording.
    /// </summary>
    [TestModule("d79707e0-fca0-44ab-86cf-db406d853359", ModuleType.Recording, 1)]
    public partial class wait_for_process_and_get_cmd : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::global_repo.global_repo repository.
        /// </summary>
        public static global::global_repo.global_repo repo = global::global_repo.global_repo.Instance;

        static wait_for_process_and_get_cmd instance = new wait_for_process_and_get_cmd();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public wait_for_process_and_get_cmd()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static wait_for_process_and_get_cmd Instance
        {
            get { return instance; }
        }

#region Variables

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 500;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            //test_with_add_parameter();
            //Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'CUserClient.Gleich' at 126;75.", repo.CUserClient.GleichInfo, new RecordItemIndex(1));
            repo.CUserClient.Gleich.Click("126;75");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'CUserClient.Jobs' at 32;18.", repo.CUserClient.JobsInfo, new RecordItemIndex(2));
            repo.CUserClient.Jobs.Click("32;18");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'CUserClient.JobStarten' at 39;35.", repo.CUserClient.JobStartenInfo, new RecordItemIndex(3));
            repo.CUserClient.JobStarten.Click("39;35");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(4));
            Delay.Duration(1000, false);
            
            wait_for_process_async();
            Delay.Milliseconds(0);
            
            get_cmd_parameter();
            Delay.Milliseconds(0);
            
            //Report.Log(ReportLevel.Info, "Wait", "Waiting 40s to exist. Associated repository item: 'CUserClient.JobStoppen'", repo.CUserClient.JobStoppenInfo, new ActionTimeout(40000), new RecordItemIndex(7));
            //repo.CUserClient.JobStoppenInfo.WaitForExists(40000);
            
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 20s.", new RecordItemIndex(8));
            //Delay.Duration(20000, false);
            
            //execute_cmd();
            //Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}