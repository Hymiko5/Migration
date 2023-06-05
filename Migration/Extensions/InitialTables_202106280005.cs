using FluentMigrator;

namespace Migration.Extensions
{
    [Migration(202106280005)]
    public class InitialTables_202106280005 : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Column("TestColumn3").FromTable("AdminLayoutConfig");
        }

        public override void Up()
        {
            if (!Schema.Table("AdminLayoutConfig").Column("TestColumn3").Exists())
                Alter.Table("AdminLayoutConfig").AddColumn("TestColumn3").AsString(50).WithDefaultValue("");
        }
    }
}
