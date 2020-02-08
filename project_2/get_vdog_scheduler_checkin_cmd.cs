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

namespace project_2
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The get_vdog_scheduler_checkin_cmd recording.
    /// </summary>
    [TestModule("ab98337f-8b78-4c47-aea4-4489a55b8d9a", ModuleType.Recording, 1)]
    public partial class get_vdog_scheduler_checkin_cmd : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::global_repo.global_repo repository.
        /// </summary>
        public static global::global_repo.global_repo repo = global::global_repo.global_repo.Instance;

        static get_vdog_scheduler_checkin_cmd instance = new get_vdog_scheduler_checkin_cmd();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public get_vdog_scheduler_checkin_cmd()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static get_vdog_scheduler_checkin_cmd Instance
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

            powershell_exec_local_or_remote("get_vdogschedulercheckin_cmd", "vagrant", "vagrant", "vagrant-10");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
