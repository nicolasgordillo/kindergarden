using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarden.Persistence.Migrations
{
    public partial class PersonRoleManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Persons_IndividualId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_IndividualId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IndividualId",
                table: "Roles");

            migrationBuilder.CreateTable(
                name: "PersonRole",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRole", x => new { x.PersonId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_PersonRole_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_RoleId",
                table: "PersonRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonRole");

            migrationBuilder.AddColumn<int>(
                name: "IndividualId",
                table: "Roles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_IndividualId",
                table: "Roles",
                column: "IndividualId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Persons_IndividualId",
                table: "Roles",
                column: "IndividualId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
