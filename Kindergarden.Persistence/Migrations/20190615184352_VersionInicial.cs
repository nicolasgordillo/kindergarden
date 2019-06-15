using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindergarden.Persistence.Migrations
{
    public partial class VersionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentTypeId = table.Column<int>(nullable: true),
                    DocumentId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PersonType = table.Column<int>(nullable: false),
                    CellPhone = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Section = table.Column<string>(maxLength: 10, nullable: true),
                    TimeSpan = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Persons_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(nullable: true),
                    SentDate = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Read = table.Column<bool>(nullable: false),
                    ReadDate = table.Column<DateTime>(nullable: true),
                    Confirmed = table.Column<bool>(nullable: false),
                    ConfirmedDate = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    SentToId = table.Column<int>(nullable: false),
                    SentById = table.Column<int>(nullable: false),
                    RegardingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Persons_RegardingId",
                        column: x => x.RegardingId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Persons_SentById",
                        column: x => x.SentById,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Persons_SentToId",
                        column: x => x.SentToId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Messages_MessageTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MessageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IndividualId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.IndividualId);
                    table.ForeignKey(
                        name: "FK_Person_Persons_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CanSendMessage = table.Column<bool>(nullable: false),
                    CanSendNotification = table.Column<bool>(nullable: false),
                    IndividualId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Persons_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFamilyMember",
                columns: table => new
                {
                    FamilyMemberId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Relationship = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFamilyMember", x => new { x.FamilyMemberId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentFamilyMember_Persons_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentFamilyMember_Persons_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IndividualGroup",
                columns: table => new
                {
                    FamilyMemberId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualGroup", x => new { x.FamilyMemberId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_IndividualGroup_Persons_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SentDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Persons_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonNotification",
                columns: table => new
                {
                    ReceiverId = table.Column<int>(nullable: false),
                    NotificationId = table.Column<int>(nullable: false),
                    Read = table.Column<bool>(nullable: false),
                    ReadDate = table.Column<DateTime>(nullable: true),
                    Confirmed = table.Column<bool>(nullable: false),
                    ConfirmedDate = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonNotification", x => new { x.NotificationId, x.ReceiverId });
                    table.ForeignKey(
                        name: "FK_PersonNotification_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonNotification_Persons_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualGroup_GroupId",
                table: "IndividualGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RegardingId",
                table: "Messages",
                column: "RegardingId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SentById",
                table: "Messages",
                column: "SentById");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SentToId",
                table: "Messages",
                column: "SentToId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TypeId",
                table: "Messages",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_GroupId",
                table: "Notifications",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonNotification_ReceiverId",
                table: "PersonNotification",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DocumentTypeId",
                table: "Persons",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_IndividualId",
                table: "Roles",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFamilyMember_StudentId",
                table: "StudentFamilyMember",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualGroup");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PersonNotification");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "StudentFamilyMember");

            migrationBuilder.DropTable(
                name: "MessageTypes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "DocumentTypes");
        }
    }
}
