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

namespace project_2
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the Repository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    [RepositoryFolder("fe244156-b2ec-4b29-ac88-f61643b09cb8")]
    public partial class Repository : RepoGenBaseFolder
    {
        static Repository instance = new Repository();
        RepositoryFolders.CUserClientAppFolder _cuserclient;
        RepositoryFolders.IeAppFolder _ie;

        /// <summary>
        /// Gets the singleton class instance representing the Repository element repository.
        /// </summary>
        [RepositoryFolder("fe244156-b2ec-4b29-ac88-f61643b09cb8")]
        public static Repository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public Repository() 
            : base("Repository", "/", null, 0, false, "fe244156-b2ec-4b29-ac88-f61643b09cb8", ".\\RepositoryImages\\Repositoryfe244156.rximgres")
        {
            _cuserclient = new RepositoryFolders.CUserClientAppFolder(this);
            _ie = new RepositoryFolders.IeAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("fe244156-b2ec-4b29-ac88-f61643b09cb8")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The CUserClient folder.
        /// </summary>
        [RepositoryFolder("b15fef7c-35f5-43d0-9c67-ea5640cddf29")]
        public virtual RepositoryFolders.CUserClientAppFolder CUserClient
        {
            get { return _cuserclient; }
        }

        /// <summary>
        /// The Ie folder.
        /// </summary>
        [RepositoryFolder("8e26ca35-95c9-4202-922a-05d73b4dea7b")]
        public virtual RepositoryFolders.IeAppFolder Ie
        {
            get { return _ie; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    public partial class RepositoryFolders
    {
        /// <summary>
        /// The CUserClientAppFolder folder.
        /// </summary>
        [RepositoryFolder("b15fef7c-35f5-43d0-9c67-ea5640cddf29")]
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
                    base("CUserClient", "/form[@name='CUserClient']", parentFolder, 30000, null, true, "b15fef7c-35f5-43d0-9c67-ea5640cddf29", "")
            {
                _gleichInfo = new RepoItemInfo(this, "Gleich", "element[@name='centralwidget']/container[@name='c_pProjectTreeSplitter']//container[@name='CVersionOverview']//container[@name='qt_tabwidget_stackedwidget']/container[@name='c_pJobsTab']//table[@name='client_jobTableView']/row[@index='0']/cell[@columnindex='3']", 30000, null, "d32479aa-17c0-43a3-bc94-74a83ba6185b");
                _jobsInfo = new RepoItemInfo(this, "Jobs", ".//tabpagelist[@name='qt_tabwidget_tabbar']/tabpage[@title='Jobs']", 30000, null, "5c6ff813-6ad0-4f7d-b161-e31f4405aaff");
                _jobstartenInfo = new RepoItemInfo(this, "JobStarten", ".//container[@name='qt_tabwidget_stackedwidget']/container[8]/?/?/container[@caption='Ausführung']/button[@text='Job starten']", 30000, null, "8962eefb-eda1-4c05-a6d9-ec8ffa233c53");
                _jobstoppenInfo = new RepoItemInfo(this, "JobStoppen", ".//container[@name='qt_tabwidget_stackedwidget']/container[8]/?/?/container[@caption='Ausführung']/button[@text='Jobstoppen' and @enabled='False']", 30000, null, "a0553e74-62a7-4a4f-b473-6a73dac767f3");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("b15fef7c-35f5-43d0-9c67-ea5640cddf29")]
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
            [RepositoryItemInfo("b15fef7c-35f5-43d0-9c67-ea5640cddf29")]
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
            [RepositoryItem("d32479aa-17c0-43a3-bc94-74a83ba6185b")]
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
            [RepositoryItemInfo("d32479aa-17c0-43a3-bc94-74a83ba6185b")]
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
            [RepositoryItem("5c6ff813-6ad0-4f7d-b161-e31f4405aaff")]
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
            [RepositoryItemInfo("5c6ff813-6ad0-4f7d-b161-e31f4405aaff")]
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
            [RepositoryItem("8962eefb-eda1-4c05-a6d9-ec8ffa233c53")]
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
            [RepositoryItemInfo("8962eefb-eda1-4c05-a6d9-ec8ffa233c53")]
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
            [RepositoryItem("a0553e74-62a7-4a4f-b473-6a73dac767f3")]
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
            [RepositoryItemInfo("a0553e74-62a7-4a4f-b473-6a73dac767f3")]
            public virtual RepoItemInfo JobStoppenInfo
            {
                get
                {
                    return _jobstoppenInfo;
                }
            }
        }

        /// <summary>
        /// The IeAppFolder folder.
        /// </summary>
        [RepositoryFolder("8e26ca35-95c9-4202-922a-05d73b4dea7b")]
        public partial class IeAppFolder : RepoGenBaseFolder
        {

            /// <summary>
            /// Creates a new Ie  folder.
            /// </summary>
            public IeAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Ie", "/dom[@browsername='IE']", parentFolder, 30000, null, false, "8e26ca35-95c9-4202-922a-05d73b4dea7b", "")
            {
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("8e26ca35-95c9-4202-922a-05d73b4dea7b")]
            public virtual Ranorex.WebDocument Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.WebDocument>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("8e26ca35-95c9-4202-922a-05d73b4dea7b")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}
