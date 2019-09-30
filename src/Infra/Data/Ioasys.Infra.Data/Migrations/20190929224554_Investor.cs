using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ioasys.Infra.Data.Migrations
{
    public partial class Investor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usr_User",
                newName: "Usr_User_Id");

            migrationBuilder.AddColumn<int>(
                name: "Ent_Enterprise_Id",
                table: "Usr_User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inv_Investor_Id",
                table: "Usr_User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inv_Investor",
                columns: table => new
                {
                    Inv_Investor_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Inv_Name = table.Column<string>(maxLength: 200, nullable: true),
                    Inv_Email = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_City = table.Column<string>(maxLength: 200, nullable: true),
                    Ent_Country = table.Column<string>(maxLength: 200, nullable: true),
                    Inv_Balance = table.Column<float>(nullable: false),
                    Inv_Photo = table.Column<string>(maxLength: 200, nullable: true),
                    Inv_PortfolioValue = table.Column<float>(maxLength: 200, nullable: false),
                    Inv_FirstAccess = table.Column<bool>(nullable: false),
                    Inv_SuperAngel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Investor", x => x.Inv_Investor_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usr_User_Ent_Enterprise_Id",
                table: "Usr_User",
                column: "Ent_Enterprise_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usr_User_Inv_Investor_Id",
                table: "Usr_User",
                column: "Inv_Investor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usr_User_Ent_Enterprise_Ent_Enterprise_Id",
                table: "Usr_User",
                column: "Ent_Enterprise_Id",
                principalTable: "Ent_Enterprise",
                principalColumn: "Ent_Enterprise_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usr_User_Inv_Investor_Inv_Investor_Id",
                table: "Usr_User",
                column: "Inv_Investor_Id",
                principalTable: "Inv_Investor",
                principalColumn: "Inv_Investor_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usr_User_Ent_Enterprise_Ent_Enterprise_Id",
                table: "Usr_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Usr_User_Inv_Investor_Inv_Investor_Id",
                table: "Usr_User");

            migrationBuilder.DropTable(
                name: "Inv_Investor");

            migrationBuilder.DropIndex(
                name: "IX_Usr_User_Ent_Enterprise_Id",
                table: "Usr_User");

            migrationBuilder.DropIndex(
                name: "IX_Usr_User_Inv_Investor_Id",
                table: "Usr_User");

            migrationBuilder.DropColumn(
                name: "Ent_Enterprise_Id",
                table: "Usr_User");

            migrationBuilder.DropColumn(
                name: "Inv_Investor_Id",
                table: "Usr_User");

            migrationBuilder.RenameColumn(
                name: "Usr_User_Id",
                table: "Usr_User",
                newName: "Id");
        }
    }
}
