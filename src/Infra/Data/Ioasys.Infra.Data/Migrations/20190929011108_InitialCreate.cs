using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ioasys.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ett_EnterpriseType",
                columns: table => new
                {
                    Ett_EnterpriseType_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ett_Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ett_EnterpriseType", x => x.Ett_EnterpriseType_Id);
                });

            migrationBuilder.CreateTable(
                name: "Ent_Enterprise",
                columns: table => new
                {
                    Ent_Enterprise_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ent_Email = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_Facebook = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_Twitter = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_Linkedin = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_Phone = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_Own = table.Column<bool>(nullable: false),
                    Ent_Name = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_Photo = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_Description = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_City = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_Country = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_Value = table.Column<int>(nullable: false),
                    Ent_SharePrice = table.Column<float>(nullable: false),
                    Ett_EnterpriseType_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ent_Enterprise", x => x.Ent_Enterprise_Id);
                    table.ForeignKey(
                        name: "FK_Ent_Enterprise_Ett_EnterpriseType_Ett_EnterpriseType_Id",
                        column: x => x.Ett_EnterpriseType_Id,
                        principalTable: "Ett_EnterpriseType",
                        principalColumn: "Ett_EnterpriseType_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ent_Enterprise_Ett_EnterpriseType_Id",
                table: "Ent_Enterprise",
                column: "Ett_EnterpriseType_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ent_Enterprise");

            migrationBuilder.DropTable(
                name: "Ett_EnterpriseType");
        }
    }
}
