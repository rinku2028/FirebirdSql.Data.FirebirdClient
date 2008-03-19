/*
 *  Visual Studio 2005 DDEX Provider for Firebird
 * 
 *     The contents of this file are subject to the Initial 
 *     Developer's Public License Version 1.0 (the "License"); 
 *     you may not use this file except in compliance with the 
 *     License. You may obtain a copy of the License at 
 *     http://www.firebirdsql.org/index.php?op=doc&id=idpl
 *
 *     Software distributed under the License is distributed on 
 *     an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either 
 *     express or implied.  See the License for the specific 
 *     language governing rights and limitations under the License.
 * 
 *  Copyright (c) 2005 Carlos Guzman Alvarez
 *  All Rights Reserved.
 */

using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Data.Framework;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

namespace FirebirdSql.VisualStudio.DataTools
{
    [Guid(GuidList.GuidObjectFactoryServiceString)]
    internal class FbDataProviderObjectFactory : DataProviderObjectFactory
    {
        #region � Constructors �

        public FbDataProviderObjectFactory() : base()
        {
            System.Diagnostics.Trace.WriteLine("FbDataProviderObjectFactory()");
        }

        #endregion

        #region � Methods �

        public override object CreateObject(Type objectType)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("FbDataProviderObjectFactory::CreateObject({0})", objectType.FullName));

            if (objectType == typeof(IVsDataConnectionProperties) ||
                objectType == typeof(IVsDataConnectionUIProperties))
            {
                return new FbDataConnectionProperties();
            }
            if (objectType == typeof(IVsDataConnectionSupport))
            {
                return new FbDataConnectionSupport();
            }
            if (objectType == typeof(IVsDataConnectionUIControl))
            {
                return new FbDataConnectionUIControl();
            }
            if (objectType == typeof(IVsDataViewSupport))
            {
                return new DataViewSupport(GetType().Namespace + ".FbDataViewSupport", GetType().Assembly);
            }

            return null;
        }

        #endregion
    }
}