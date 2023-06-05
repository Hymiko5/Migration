using FluentMigrator;

namespace Migration.Extensions
{
    [Migration(202106280004)]
    public class InitialTables_202106280004 : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Column("TestColumn2").FromTable("AdminLayoutConfig");
        }

        public override void Up()
        {
            if (!Schema.Table("AdminLayoutConfig").Column("TestColumn2").Exists())
                Alter.Table("AdminLayoutConfig").AddColumn("TestColumn2").AsString(50).WithDefaultValue("");
        }
    }
}
