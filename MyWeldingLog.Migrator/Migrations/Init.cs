using FluentMigrator;

namespace MyWeldingLog.Migrator.Migrations
{
    [Migration(1)]
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

            if (!Schema.Table("Hierarchy").Exists())
            {
                Create.Table("Hierarchy")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("Hierarchy_Id")
                    .WithColumn("ObjectId").AsInt32().NotNullable()
                    .WithColumn("SubObjectId").AsInt32().NotNullable();
            }

            if (!Schema.Table("ProjectCodes").Exists())
            {
                Create.Table("ProjectCodes")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("ProjectCode_Id")
                    .WithColumn("Name").AsString(100).NotNullable().Unique()
                    .WithColumn("HierarchyId").AsInt32().NotNullable();
            }

            if (!Schema.Table("Cluster").Exists())
            {
                Create.Table("Cluster")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("Cluster_Id")
                    .WithColumn("Name").AsString(100).NotNullable()
                    .WithColumn("HierarchyId").AsInt32().NotNullable();
            }

            if (!Schema.Table("JobTypes").Exists())
            {
                Create.Table("JobTypes")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("JobTypes_Id")
                    .WithColumn("Name").AsString(100).NotNullable().Unique();
            }

            if (!Schema.Table("ProjectMaterials").Exists())
            {
                Create.Table("ProjectMaterials")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("ProjectMaterials_Id")
                    .WithColumn("ProjectCodeId").AsInt32().NotNullable().ForeignKey(primaryTableName:"ProjectCodes", primaryColumnName:"Id")
                    .WithColumn("MaterialType").AsInt32().NotNullable()
                    .WithColumn("FirstDiameter").AsInt16().NotNullable()
                    .WithColumn("FirstWall").AsInt16().NotNullable()
                    .WithColumn("SecondDiameter").AsInt16()
                    .WithColumn("SecondWall").AsInt16()
                    .WithColumn("Angle").AsByte()
                    .WithColumn("Type").AsString(10)
                    .WithColumn("Strength").AsString(100).WithColumnDescription("Класс прочности")
                    .WithColumn("Steel").AsString(100).NotNullable()
                    .WithColumn("TechnicalConditions").AsString(100).NotNullable()
                    .WithColumn("Factory").AsString(100)
                    .WithColumn("IsIsolated").AsBoolean().NotNullable()
                    .WithColumn("IsolationType").AsString(100)
                    .WithColumn("Quantity").AsDouble().NotNullable()
                    .WithColumn("Used").AsDouble().NotNullable()
                    .WithColumn("IsDeleted").AsBoolean().NotNullable();
            }

            if (!Schema.Table("Jobs").Exists())
            {
                Create.Table("Jobs")
                    .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey("Jobs_Id")
                    .WithColumn("ClusterId").AsInt32().NotNullable().ForeignKey(primaryTableName:"Cluster", primaryColumnName:"Id")
                    .WithColumn("ProjectCodeId").AsInt32().NotNullable().ForeignKey(primaryTableName:"ProjectCodes", primaryColumnName:"Id")
                    .WithColumn("JobTypeId").AsInt32().NotNullable().ForeignKey(primaryTableName:"JobTypes", primaryColumnName:"Id")
                    .WithColumn("ProjectMaterialId").AsInt32().NotNullable().ForeignKey(primaryTableName:"ProjectMaterials", primaryColumnName:"Id")
                    .WithColumn("Quantity").AsDouble().NotNullable();
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

            if (Schema.Table("Hierarchy").Exists())
            {
                Delete.Table("Hierarchy");
            }

            if (Schema.Table("Cluster").Exists())
            {
                Delete.Table("Cluster");
            }

            if (Schema.Table("JobTypes").Exists())
            {
                Delete.Table("JobTypes");
            }

            if (Schema.Table("ProjectCodes").Exists())
            {
                Delete.Table("ProjectCodes");
            }

            if (Schema.Table("ProjectMaterials").Exists())
            {
                Delete.Table("ProjectMaterials");
            }

            if (Schema.Table("Jobs").Exists())
            {
                Delete.Table("Jobs");
            }
        }
    }
}

