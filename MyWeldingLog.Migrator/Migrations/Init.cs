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
                    .WithColumn("Name").AsString(100).NotNullable().Unique();
            }

            if (!Schema.Table("SubObjects").Exists())
            {
                Create.Table("SubObjects")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("SubObject_Id")
                    .WithColumn("Name").AsString(100).NotNullable().Unique();
            }

            if (!Schema.Table("ProjectCodes").Exists())
            {
                Create.Table("ProjectCodes")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("ProjectCode_Id")
                    .WithColumn("Name").AsString(100).NotNullable().Unique()
                    .WithColumn("SubObjectId").AsInt32().NotNullable().ForeignKey("SubObjects", "Id")
                    .WithColumn("ObjectId").AsInt32().NotNullable().ForeignKey("Objects", "Id");
            }

            if (!Schema.Table("ProjectBranchMaterials").Exists())
            {
                Create.Table("ProjectBranchMaterials").WithDescription("В данной таблице хранятся отводы внесенные по проекту")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("BranchMaterials_Id")
                    .WithColumn("ProjectCodeId").AsInt32().NotNullable().ForeignKey(primaryTableName:"ProjectCodes", primaryColumnName:"Id")
                    .WithColumn("Diameter").AsInt16().NotNullable()
                    .WithColumn("Wall").AsInt16().NotNullable()
                    .WithColumn("Angle").AsByte().NotNullable()
                    .WithColumn("BranchType").AsString(10).NotNullable()
                    .WithColumn("Steel").AsString(100).NotNullable()
                    .WithColumn("TechnicalConditions").AsString(100).NotNullable()
                    .WithColumn("Factory").AsString(100)
                    .WithColumn("IsIsolated").AsBoolean().NotNullable()
                    .WithColumn("Quantity").AsInt32().NotNullable()
                    .WithColumn("IsDeleted").AsBoolean().NotNullable();
            }

            if (!Schema.Table("ProjectPipeMaterials").Exists())
            {
                Create.Table("ProjectPipeMaterials").WithDescription("В данной таблице хранятся трубы внесенные по проекту")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("PipeMaterials_Id")
                    .WithColumn("ProjectCodeId").AsInt32().NotNullable().ForeignKey(primaryTableName:"ProjectCodes", primaryColumnName:"Id")
                    .WithColumn("Diameter").AsInt16().NotNullable()
                    .WithColumn("Wall").AsInt16().NotNullable()
                    .WithColumn("Steel").AsString(100).NotNullable()
                    .WithColumn("TechnicalConditions").AsString(100).NotNullable()
                    .WithColumn("Factory").AsString(100)
                    .WithColumn("IsIsolated").AsBoolean().NotNullable()
                    .WithColumn("Quantity").AsInt32().NotNullable()
                    .WithColumn("IsDeleted").AsBoolean().NotNullable();
            }

            if (!Schema.Table("ActualPipeMaterials").Exists())
            {
                Create.Table("ActualPipeMaterials")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("ActualPipeMaterials_Id")
                    .WithColumn("Date").AsDate().NotNullable()
                    .WithColumn("Diameter").AsInt16().NotNullable()
                    .WithColumn("Wall").AsInt16().NotNullable()
                    .WithColumn("Steel").AsString(100).NotNullable()
                    .WithColumn("TechnicalConditions").AsString(100).NotNullable()
                    .WithColumn("Factory").AsString(100)
                    .WithColumn("IsIsolated").AsBoolean().NotNullable()
                    .WithColumn("Quantity").AsInt32().NotNullable()
                    .WithColumn("Certificate").AsString().NotNullable()
                    .WithColumn("FactoryNumber").AsString().NotNullable()
                    .WithColumn("ProjectCodeId").AsInt32().NotNullable().ForeignKey(primaryTableName: "ProjectCodes", primaryColumnName: "Id")
                    .WithColumn("ProjectPipeId").AsInt32().ForeignKey(primaryTableName: "ProjectPipeMaterials", primaryColumnName: "Id");
            }

            if (!Schema.Table("ActualBranchMaterials").Exists())
            {
                Create.Table("ActualBranchMaterials")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("ActualBranchMaterials_Id")
                    .WithColumn("Date").AsDate().NotNullable()
                    .WithColumn("Diameter").AsInt16().NotNullable()
                    .WithColumn("Wall").AsInt16().NotNullable()
                    .WithColumn("Angle").AsByte().NotNullable()
                    .WithColumn("BranchType").AsString(10).NotNullable()
                    .WithColumn("Steel").AsString(100).NotNullable()
                    .WithColumn("TechnicalConditions").AsString(100).NotNullable()
                    .WithColumn("Factory").AsString(100)
                    .WithColumn("IsIsolated").AsBoolean().NotNullable()
                    .WithColumn("Quantity").AsInt32().NotNullable()
                    .WithColumn("Certificate").AsString().NotNullable()
                    .WithColumn("FactoryNumber").AsString().NotNullable()
                    .WithColumn("ProjectCodeId").AsInt32().ForeignKey(primaryTableName: "ProjectCodes", primaryColumnName: "Id")
                    .WithColumn("ProjectBranchId").AsInt32().ForeignKey(primaryTableName: "ProjectBranchMaterials", primaryColumnName: "Id");
            }

            if (!Schema.Table("Hierarchy").Exists())
            {
                Create.Table("Hierarchy")
                    .WithColumn("ObjectId").AsInt32().PrimaryKey("HierarchyIds")
                    .WithColumn("SubObjectId").AsInt32().PrimaryKey("HierarchyIds");
            }
        }

        public override void Down()
        {
            if (Schema.Table("Objects").Exists())
            {
                Delete.Table("Objects");
            }

            if (Schema.Table("SubObjects").Exists())
            {
                Delete.Table("SubObjects");
            }

            if (Schema.Table("ProjectCodes").Exists())
            {
                Delete.Table("ProjectCodes");
            }

            if (Schema.Table("BranchMaterials").Exists())
            {
                Delete.Table("BranchMaterials");
            }

            if (Schema.Table("PipeMaterials").Exists())
            {
                Delete.Table("PipeMaterials");
            }

            if (Schema.Table("Hierarchy").Exists())
            {
                Delete.Table("Hierarchy");
            }

            if (Schema.Table("ActualPipeMaterials").Exists())
            {
                Delete.Table("ActualPipeMaterials");
            }

            if (Schema.Table("ActualBranchMaterials").Exists())
            {
                Delete.Table("ActualBranchMaterials");
            }
        }
    }
}

