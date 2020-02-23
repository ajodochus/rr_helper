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

namespace global_repo
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the global_repo element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    [RepositoryFolder("e8abadf6-fac5-414e-bd6b-9fe377c28278")]
    public partial class global_repo : RepoGenBaseFolder
    {
        static global_repo instance = new global_repo();
        global_repoFolders.ExplorerAppFolder _explorer;
        global_repoFolders.CUserClientAppFolder _cuserclient;

        /// <summary>
        /// Gets the singleton class instance representing the global_repo element repository.
        /// </summary>
        [RepositoryFolder("e8abadf6-fac5-414e-bd6b-9fe377c28278")]
        public static global_repo Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public global_repo() 
            : base("global_repo", "/", null, 0, false, "e8abadf6-fac5-414e-bd6b-9fe377c28278", ".\\RepositoryImages\\global_repoe8abadf6.rximgres")
        {
            _explorer = new global_repoFolders.ExplorerAppFolder(this);
            _cuserclient = new global_repoFolders.CUserClientAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("e8abadf6-fac5-414e-bd6b-9fe377c28278")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The Explorer folder.
        /// </summary>
        [RepositoryFolder("f57b2f6f-4012-450d-9660-de353ba14274")]
        public virtual global_repoFolders.ExplorerAppFolder Explorer
        {
            get { return _explorer; }
        }

        /// <summary>
        /// The CUserClient folder.
        /// </summary>
        [RepositoryFolder("95dfe53f-b6cb-44a0-a481-f85add362169")]
        public virtual global_repoFolders.CUserClientAppFolder CUserClient
        {
            get { return _cuserclient; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    public partial class global_repoFolders
    {
        /// <summary>
        /// The ExplorerAppFolder folder.
        /// </summary>
        [RepositoryFolder("f57b2f6f-4012-450d-9660-de353ba14274")]
        public partial class ExplorerAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _microsoftedgeInfo;
            RepoItemInfo _fileexplorerInfo;
            RepoItemInfo _testInfo;
            RepoItemInfo _explorer1aktivesfensterInfo;

            /// <summary>
            /// Creates a new Explorer  folder.
            /// </summary>
            public ExplorerAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Explorer", "/menubar[@processname='explorer']", parentFolder, 30000, null, true, "f57b2f6f-4012-450d-9660-de353ba14274", "")
            {
                _microsoftedgeInfo = new RepoItemInfo(this, "MicrosoftEdge", "form[@controlid='40965']", 30000, null, "e0d5b68a-ce5f-4921-b7c2-507f1a0e5fa9");
                _fileexplorerInfo = new RepoItemInfo(this, "FileExplorer", "form[@controlid='40965']//toolbar[@accessiblename='Running applications']/button[@accessiblename='File Explorer']", 30000, null, "f180434a-15fb-4fc6-80b8-2611763d08d3");
                _testInfo = new RepoItemInfo(this, "test", "element/element", 30000, null, "56354453-49a3-46a6-8996-5941bf201e4b");
                _explorer1aktivesfensterInfo = new RepoItemInfo(this, "Explorer1AktivesFenster", "form[@controlid='40965']//toolbar[@accessiblename='Ausgeführte Anwendungen']/button[3]", 30000, null, "0b9fde6c-fbb9-4b33-b8b7-e7179c5a177d");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("f57b2f6f-4012-450d-9660-de353ba14274")]
            public virtual Ranorex.MenuBar Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.MenuBar>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("f57b2f6f-4012-450d-9660-de353ba14274")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The MicrosoftEdge item.
            /// </summary>
            [RepositoryItem("e0d5b68a-ce5f-4921-b7c2-507f1a0e5fa9")]
            public virtual Ranorex.Form MicrosoftEdge
            {
                get
                {
                    return _microsoftedgeInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The MicrosoftEdge item info.
            /// </summary>
            [RepositoryItemInfo("e0d5b68a-ce5f-4921-b7c2-507f1a0e5fa9")]
            public virtual RepoItemInfo MicrosoftEdgeInfo
            {
                get
                {
                    return _microsoftedgeInfo;
                }
            }

            /// <summary>
            /// The FileExplorer item.
            /// </summary>
            [RepositoryItem("f180434a-15fb-4fc6-80b8-2611763d08d3")]
            public virtual Ranorex.Button FileExplorer
            {
                get
                {
                    return _fileexplorerInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The FileExplorer item info.
            /// </summary>
            [RepositoryItemInfo("f180434a-15fb-4fc6-80b8-2611763d08d3")]
            public virtual RepoItemInfo FileExplorerInfo
            {
                get
                {
                    return _fileexplorerInfo;
                }
            }

            /// <summary>
            /// The test item.
            /// </summary>
            [RepositoryItem("56354453-49a3-46a6-8996-5941bf201e4b")]
            public virtual Ranorex.Unknown test
            {
                get
                {
                    return _testInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The test item info.
            /// </summary>
            [RepositoryItemInfo("56354453-49a3-46a6-8996-5941bf201e4b")]
            public virtual RepoItemInfo testInfo
            {
                get
                {
                    return _testInfo;
                }
            }

            /// <summary>
            /// The Explorer1AktivesFenster item.
            /// </summary>
            [RepositoryItem("0b9fde6c-fbb9-4b33-b8b7-e7179c5a177d")]
            public virtual Ranorex.Button Explorer1AktivesFenster
            {
                get
                {
                    return _explorer1aktivesfensterInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Explorer1AktivesFenster item info.
            /// </summary>
            [RepositoryItemInfo("0b9fde6c-fbb9-4b33-b8b7-e7179c5a177d")]
            public virtual RepoItemInfo Explorer1AktivesFensterInfo
            {
                get
                {
                    return _explorer1aktivesfensterInfo;
                }
            }
        }

        /// <summary>
        /// The CUserClientAppFolder folder.
        /// </summary>
        [RepositoryFolder("95dfe53f-b6cb-44a0-a481-f85add362169")]
        public partial class CUserClientAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _gleichInfo;
            RepoItemInfo _jobsInfo;
            RepoItemInfo _jobstartenInfo;
            RepoItemInfo _jobstoppenInfo;

            /// <summary>
            /// Creates a new CUserClient  folder.
            /// </summary>
            public CUserClientAppFolder(RepoGenBaseFolder parentFolder) :
                    base("CUserClient", "/form[@name='CUserClient']", parentFolder, 30000, null, true, "95dfe53f-b6cb-44a0-a481-f85add362169", "")
            {
                _gleichInfo = new RepoItemInfo(this, "Gleich", "element[@name='centralwidget']/container[@name='c_pProjectTreeSplitter']//container[@name='CVersionOverview']//container[@name='qt_tabwidget_stackedwidget']/container[@name='c_pJobsTab']//table[@name='client_jobTableView']/row[@index='0']/cell[@columnindex='3']", 30000, null, "9a69837b-1636-44bd-9973-7ecf32206de6");
                _jobsInfo = new RepoItemInfo(this, "Jobs", ".//tabpagelist[@name='qt_tabwidget_tabbar']/tabpage[@title='Jobs']", 30000, null, "ec4deca1-3eaa-4218-9b71-4613e8623848");
                _jobstartenInfo = new RepoItemInfo(this, "JobStarten", ".//container[@name='qt_tabwidget_stackedwidget']/container[8]/?/?/container[@caption='Ausführung']/button[@text='Job starten']", 30000, null, "54e7fa7e-7479-4a2b-80d8-1e554c9380b4");
                _jobstoppenInfo = new RepoItemInfo(this, "JobStoppen", ".//container[@name='qt_tabwidget_stackedwidget']/container[8]/?/?/container[@caption='Ausführung']/button[@text='Jobstoppen' and @enabled='False']", 30000, null, "ff5b27bc-6fa6-44e1-881f-f573800e2943");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("95dfe53f-b6cb-44a0-a481-f85add362169")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("95dfe53f-b6cb-44a0-a481-f85add362169")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The Gleich item.
            /// </summary>
            [RepositoryItem("9a69837b-1636-44bd-9973-7ecf32206de6")]
            public virtual Ranorex.Cell Gleich
            {
                get
                {
                    return _gleichInfo.CreateAdapter<Ranorex.Cell>(true);
                }
            }

            /// <summary>
            /// The Gleich item info.
            /// </summary>
            [RepositoryItemInfo("9a69837b-1636-44bd-9973-7ecf32206de6")]
            public virtual RepoItemInfo GleichInfo
            {
                get
                {
                    return _gleichInfo;
                }
            }

            /// <summary>
            /// The Jobs item.
            /// </summary>
            [RepositoryItem("ec4deca1-3eaa-4218-9b71-4613e8623848")]
            public virtual Ranorex.TabPage Jobs
            {
                get
                {
                    return _jobsInfo.CreateAdapter<Ranorex.TabPage>(true);
                }
            }

            /// <summary>
            /// The Jobs item info.
            /// </summary>
            [RepositoryItemInfo("ec4deca1-3eaa-4218-9b71-4613e8623848")]
            public virtual RepoItemInfo JobsInfo
            {
                get
                {
                    return _jobsInfo;
                }
            }

            /// <summary>
            /// The JobStarten item.
            /// </summary>
            [RepositoryItem("54e7fa7e-7479-4a2b-80d8-1e554c9380b4")]
            public virtual Ranorex.Button JobStarten
            {
                get
                {
                    return _jobstartenInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The JobStarten item info.
            /// </summary>
            [RepositoryItemInfo("54e7fa7e-7479-4a2b-80d8-1e554c9380b4")]
            public virtual RepoItemInfo JobStartenInfo
            {
                get
                {
                    return _jobstartenInfo;
                }
            }

            /// <summary>
            /// The JobStoppen item.
            /// </summary>
            [RepositoryItem("ff5b27bc-6fa6-44e1-881f-f573800e2943")]
            public virtual Ranorex.Button JobStoppen
            {
                get
                {
                    return _jobstoppenInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The JobStoppen item info.
            /// </summary>
            [RepositoryItemInfo("ff5b27bc-6fa6-44e1-881f-f573800e2943")]
            public virtual RepoItemInfo JobStoppenInfo
            {
                get
                {
                    return _jobstoppenInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}
