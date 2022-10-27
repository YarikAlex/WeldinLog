using System.Runtime.Intrinsics.Arm;
using FluentMigrator;

namespace MyWeldingLog.Migrator.Migrations
{
    [Migration(202209291100)]
    public class Init : Migration
    {
        public override void Up()
        {
            if (!Schema.Table("Objects").Exists())
            {
                Create.Table("Objects")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("Object_id")
                    .WithColumn("Name").AsString(100).NotNullable();
            }

            if (!Schema.Table("SubObjects").Exists())
            {
                Create.Table("SubObjects")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("SubObject_Id")
                    .WithColumn("Name").AsString(100).NotNullable();
            }

            if (!Schema.Table("ProjectCodes").Exists())
            {
                Create.Table("ProjectCodes")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("ProjectCode_Id")
                    .WithColumn("Name").AsString(100).NotNullable()
                    .WithColumn("SubObjectId").AsInt32().NotNullable().ForeignKey("SubObjects", "Id")
                    .WithColumn("ObjectId").AsInt32().NotNullable().ForeignKey("Objects", "Id");
            }

            if (!Schema.Table("BranchesCatalog").Exists())
            {
                Create.Table("BranchesCatalog")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("BranchesCatalog_Id")
                    .WithColumn("Diameter").AsInt16().NotNullable()
                    .WithColumn("Wall").AsInt16().NotNullable()
                    .WithColumn("Angle").AsByte().NotNullable()
                    .WithColumn("BranchType").AsString(10).NotNullable()
                    .WithColumn("Steel").AsString(100).NotNullable()
                    .WithColumn("TechnicalConditions").AsString(100).NotNullable()
                    .WithColumn("Factory").AsString(100)
                    .WithColumn("IsIsolated").AsBoolean().NotNullable();
            }

            if (!Schema.Table("PipesCatalog").Exists())
            {
                Create.Table("PipesCatalog")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("PipesCatalog_Id")
                    .WithColumn("Diameter").AsInt16().NotNullable()
                    .WithColumn("Wall").AsInt16().NotNullable()
                    .WithColumn("Steel").AsString(100).NotNullable()
                    .WithColumn("TechnicalConditions").AsString(100).NotNullable()
                    .WithColumn("Factory").AsString(100)
                    .WithColumn("IsIsolated").AsBoolean().NotNullable();
            }

            if (!Schema.Table("BranchMaterials").Exists())
            {
                Create.Table("BranchMaterials")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("BranchMaterials_Id")
                    .WithColumn("BranchId").AsInt32().NotNullable().ForeignKey(primaryTableName:"BranchesCatalog", primaryColumnName:"Id")
                    .WithColumn("ProjectCodeId").AsInt32().NotNullable().ForeignKey(primaryTableName:"ProjectCodes", primaryColumnName:"Id")
                    .WithColumn("Quantity").AsInt32().NotNullable()
                    .WithColumn("IsDeleted").AsBoolean().NotNullable();
            }
            
            if (!Schema.Table("PipeMaterials").Exists())
            {
                Create.Table("PipeMaterials")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("PipeMaterials_Id")
                    .WithColumn("PipeId").AsInt32().NotNullable().ForeignKey(primaryTableName:"PipesCatalog", primaryColumnName:"Id")
                    .WithColumn("ProjectCodeId").AsInt32().NotNullable().ForeignKey(primaryTableName:"ProjectCodes", primaryColumnName:"Id")
                    .WithColumn("Quantity").AsInt32().NotNullable()
                    .WithColumn("IsDeleted").AsBoolean().NotNullable();
            }
        }

        public override void Down()
        {
            if (Schema.Table("Objects").Exists())
            {
                Delete.Table("Objects");
                Delete.Table("SubObjects");
                Delete.Table("ProjectCodes");
                Delete.Table("BranchesCatalog");
                Delete.Table("PipesCatalog");
                Delete.Table("BranchMaterials");
                Delete.Table("PipeMaterials");
            }
        }
    }
}

