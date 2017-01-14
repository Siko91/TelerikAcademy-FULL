﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using NinjaFactory.DataBase.MySql;

namespace NinjaFactory.DataBase.MySql	
{
	public partial class NinjaCatalogueModel : OpenAccessContext, INinjaCatalogueModelUnitOfWork
	{
		private static string connectionStringName = @"Connection";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntitiesModel.rlinq");
		
		public NinjaCatalogueModel()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public NinjaCatalogueModel(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public NinjaCatalogueModel(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public NinjaCatalogueModel(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public NinjaCatalogueModel(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Ninja_catalogue_item> Ninja_catalogue_items 
		{
			get
			{
				return this.GetAll<Ninja_catalogue_item>();
			}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MySql";
			backend.ProviderName = "MySql.Data.MySqlClient";
		
			CustomizeBackendConfiguration(ref backend);
		
			return backend;
		}
		
		/// <summary>
		/// Allows you to customize the BackendConfiguration of NinjaCatalogueModel.
		/// </summary>
		/// <param name="config">The BackendConfiguration of NinjaCatalogueModel.</param>
		static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
		
	}
	
	public interface INinjaCatalogueModelUnitOfWork : IUnitOfWork
	{
		IQueryable<Ninja_catalogue_item> Ninja_catalogue_items
		{
			get;
		}
	}
}
#pragma warning restore 1591