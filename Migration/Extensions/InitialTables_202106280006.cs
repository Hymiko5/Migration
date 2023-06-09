﻿using Dapper;
using FluentMigrator;
using FluentMigrator.Model;
using FluentMigrator.Runner.Generators.Base;
using FluentMigrator.Runner.Processors.Firebird;
using Microsoft.Data.SqlClient;
using Migration.Context;
using Migration.Entities;
using System.Diagnostics.Metrics;

namespace Migration.Extensions
{
    [Migration(202106280006)]
    public class InitialTables_202106280006 : FluentMigrator.Migration
    {
        private readonly UserManagementContext _context;
        public InitialTables_202106280006(UserManagementContext context)
        {
            _context = context;
        }
        public override void Down()
        {
        }

        private void ChangeTable<T>(T inputClass) where T: new()
        {
            var props = typeof(T).GetProperties().Select(item => item.Name).ToList();
            var adminLayoutConfig = new T();
            var className = inputClass.GetType().Name;
            var info = _context.CreateConnection().Query<TableInfomation>(@$"SELECT DATA_TYPE, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '{className}'");
            props.ForEach(async (prop) =>
            {
                var objType = adminLayoutConfig.GetPropertyTypeHelper(prop);
                if (!Schema.Table(className).Column(prop).Exists())
                {
                    if (objType == typeof(string))
                    {
                        Create.Column(prop).OnTable(className).AsString(250).Nullable();
                    }
                    else if (objType == typeof(int))
                    {
                        Create.Column(prop).OnTable(className).AsInt32().Nullable();
                    }
                    else if (objType == typeof(long))
                    {
                        Create.Column(prop).OnTable(className).AsInt64().Nullable();
                    }
                    else if (objType == typeof(float))
                    {
                        Create.Column(prop).OnTable(className).AsFloat().Nullable();
                    }
                    else if (objType == typeof(double))
                    {
                        Create.Column(prop).OnTable(className).AsDouble().Nullable();
                    }
                    else if (objType == typeof(DateTime))
                    {
                        Create.Column(prop).OnTable(className).AsDateTime().Nullable();
                    }
                }

                string dataType = "";
                if (objType == typeof(string))
                {
                    dataType = "nvarchar";
                }
                else if (objType == typeof(int))
                {
                    dataType = "int";
                }
                else if (objType == typeof(long))
                {
                    dataType = "bigint";
                }
                else if (objType == typeof(float))
                {
                    dataType = "double";
                }
                else if (objType == typeof(double))
                {
                    dataType = "double";
                }
                else if (objType == typeof(DateTime))
                {
                    dataType = "datetime";
                }

                var updateColumn = info.Where(s => s.COLUMN_NAME == prop && s.DATA_TYPE != dataType);
                if (updateColumn.Any())
                {
                    if (objType == typeof(string))
                    {
                        Alter.Table(className).AlterColumn(prop).AsString(250).Nullable();
                    }
                    else if (objType == typeof(int))
                    {
                        Alter.Table(className).AlterColumn(prop).AsInt32().Nullable();
                    }
                    else if (objType == typeof(long))
                    {
                        Alter.Table(className).AlterColumn(prop).AsInt64().Nullable();
                    }
                    else if (objType == typeof(float))
                    {
                        Alter.Table(className).AlterColumn(prop).AsFloat().Nullable();
                    }
                    else if (objType == typeof(double))
                    {
                        Alter.Table(className).AlterColumn(prop).AsDouble().Nullable();
                    }
                    else if (objType == typeof(DateTime))
                    {
                        Alter.Table(className).AlterColumn(prop).AsDateTime().Nullable();
                    }
                }
            });
        }
        public override void Up()
        {
            AdminLayoutConfig tmps = new ();
            ChangeTable(tmps);

        }
    }
}
