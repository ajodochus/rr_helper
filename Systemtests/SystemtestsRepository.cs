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
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace Systemtests
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the SystemtestsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    [RepositoryFolder("0b58e130-767e-44e0-a063-14868ccfd3e0")]
    public partial class SystemtestsRepository : RepoGenBaseFolder
    {
        static SystemtestsRepository instance = new SystemtestsRepository();

        /// <summary>
        /// Gets the singleton class instance representing the SystemtestsRepository element repository.
        /// </summary>
        [RepositoryFolder("0b58e130-767e-44e0-a063-14868ccfd3e0")]
        public static SystemtestsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public SystemtestsRepository() 
            : base("SystemtestsRepository", "/", null, 0, false, "0b58e130-767e-44e0-a063-14868ccfd3e0", ".\\RepositoryImages\\SystemtestsRepository0b58e130.rximgres")
        {
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("0b58e130-767e-44e0-a063-14868ccfd3e0")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    public partial class SystemtestsRepositoryFolders
    {
    }
#pragma warning restore 0436
}
