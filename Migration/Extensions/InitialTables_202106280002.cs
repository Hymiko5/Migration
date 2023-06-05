using FluentMigrator;
using Migration.Entities;

namespace Migration.Extensions
{
    [Migration(202106280002)]
    public class InitialTables_202106280002 : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table("Admin");
            Delete.Table("AdminLayoutConfig");
            Delete.Table("FunctionRouter");
            Delete.Table("FunctionSite");
            Delete.Table("GroupLayoutConfig");
            Delete.Table("GroupPermissions");
            Delete.Table("Groups");
            Delete.Table("MenuLists");
        }

        public override void Up()
        {
            Create.Table("Admin")
            .WithColumn("AdminId").AsInt32().Unique().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(50)
            .WithColumn("GroupId").AsInt32()
            .WithColumn("IsActive").AsBoolean()
            .WithColumn("Email").AsString(250)
            .WithColumn("KeyId").AsString(50)
            .WithColumn("NormalizedUserName").AsString(256)
            .WithColumn("StatusActive").AsInt16().WithDefaultValue(1)
            .WithColumn("PhoneNumber").AsString()
            .WithColumn("LayoutConfigId").AsInt32();
            Create.Table("AdminLayoutConfig")
            .WithColumn("Id").AsInt32().Unique().NotNullable().PrimaryKey()
            .WithColumn("Config").AsString().NotNullable();
            Create.Table("FunctionRouter")
            .WithColumn("Id").AsInt32().Unique().NotNullable().PrimaryKey()
            .WithColumn("Unique").AsString(50)
            .WithColumn("Name").AsString(250)
            .WithColumn("ParentId").AsInt32()
            .WithColumn("Url").AsString(250)
            .WithColumn("Order").AsInt32()
            .WithColumn("IconClass").AsString(250)
            .WithColumn("Type").AsInt32()
            .WithColumn("ShowInMenu").AsBoolean()
            .WithColumn("NameClass").AsString(250)
            .WithColumn("Alias").AsString(250)
            .WithColumn("Path").AsString(250);
            Create.Table("FunctionSite")
            .WithColumn("Id").AsInt32().Unique().NotNullable().PrimaryKey()
            .WithColumn("SiteId").AsInt32()
            .WithColumn("FunctionId").AsInt32()
            .WithColumn("ParentId").AsInt32()
            .WithColumn("Name").AsString(500)
            .WithColumn("IconClass").AsString(500)
            .WithColumn("Order").AsInt32()
            .WithColumn("CloneFromId").AsInt32()
            .WithColumn("MenuId").AsInt32();
            Create.Table("GroupLayoutConfig")
                .WithColumn("Id").AsInt32().Unique().NotNullable().PrimaryKey()
                .WithColumn("Config").AsString().NotNullable();
            Create.Table("GroupPermissions")
                .WithColumn("GroupPermissionId").AsInt32().Unique().NotNullable().PrimaryKey()
                .WithColumn("GroupId").AsInt32().NotNullable()
                .WithColumn("FunctionId").AsInt32().NotNullable()
                .WithColumn("Permission").AsInt32().NotNullable();
            Create.Table("Groups")
            .WithColumn("GroupId").AsInt32().Unique().NotNullable().PrimaryKey()
            .WithColumn("GroupName").AsString(50)
            .WithColumn("ParentId").AsInt32()
            .WithColumn("LastFBAlarmId").AsInt64()
            .WithColumn("SiteDomain").AsString(250)
            .WithColumn("ReceiveLogBenchmarkCreate").AsBoolean()
            .WithColumn("ReceiveLogEmail").AsString(500)
            .WithColumn("AutoCrawlBenchmarkCreate").AsBoolean()
            .WithColumn("HostCluster").AsString(250)
            .WithColumn("MenuId").AsInt32()
            .WithColumn("LayoutConfigId").AsInt32();
            Create.Table("MenuLists")
            .WithColumn("Id").AsInt32().Unique().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(250);
        }
    }
}
