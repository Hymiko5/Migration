using FluentMigrator;

namespace Migration.Extensions
{
    [Migration(202106280003)]
    public class InitialTables_202106280003 : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Column("TestColumn").FromTable("AdminLayoutConfig");
        }

        public override void Up()
        {
            if (!Schema.Table("AdminLayoutConfig").Column("TestColumn").Exists())
                Alter.Table("AdminLayoutConfig").AddColumn("TestColumn").AsString(50).WithDefaultValue("");
        }
    }
}
