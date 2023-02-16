using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ronimizy.SpbDotNet.TPC.Migrations.TphToTpc.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeUniforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<int>(type: "integer", nullable: false),
                    ShirtColorArgb = table.Column<int>(type: "integer", nullable: true),
                    ShirtName = table.Column<string>(type: "text", nullable: true),
                    ShirtMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    JeansColorArgb = table.Column<int>(type: "integer", nullable: true),
                    JeansName = table.Column<string>(type: "text", nullable: true),
                    JeansMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    ShoesColorArgb = table.Column<int>(type: "integer", nullable: true),
                    ShoesName = table.Column<string>(type: "text", nullable: true),
                    ShoesMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    HoodieAllowed = table.Column<bool>(type: "boolean", nullable: true),
                    TuxedoColorArgb = table.Column<int>(type: "integer", nullable: true),
                    TuxedoName = table.Column<string>(type: "text", nullable: true),
                    TuxedoMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    DisplayShirtColorArgb = table.Column<int>(type: "integer", nullable: true),
                    DisplayShirtName = table.Column<string>(type: "text", nullable: true),
                    DisplayShirtMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    DisplayShoeColorArgb = table.Column<int>(type: "integer", nullable: true),
                    DisplayShoeName = table.Column<string>(type: "text", nullable: true),
                    DisplayShoeMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    DisplayTieColorArgb = table.Column<int>(type: "integer", nullable: true),
                    DisplayTieName = table.Column<string>(type: "text", nullable: true),
                    DisplayTieMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    DisplayBeltColorArgb = table.Column<int>(type: "integer", nullable: true),
                    DisplayBeltName = table.Column<string>(type: "text", nullable: true),
                    DisplayBeltMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    JacketColorArgb = table.Column<int>(type: "integer", nullable: true),
                    JacketName = table.Column<string>(type: "text", nullable: true),
                    JacketMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    OfficialPantsColorArgb = table.Column<int>(type: "integer", nullable: true),
                    OfficialPantsName = table.Column<string>(type: "text", nullable: true),
                    OfficialPantsMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    OfficialShoesColorArgb = table.Column<int>(type: "integer", nullable: true),
                    OfficialShoesName = table.Column<string>(type: "text", nullable: true),
                    OfficialShoesMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    OfficialShirtColorArgb = table.Column<int>(type: "integer", nullable: true),
                    OfficialShirtName = table.Column<string>(type: "text", nullable: true),
                    OfficialShirtMostPopularSize = table.Column<int>(type: "integer", nullable: true),
                    OfficialTieColorArgb = table.Column<int>(type: "integer", nullable: true),
                    OfficialTieName = table.Column<string>(type: "text", nullable: true),
                    OfficialTieMostPopularSize = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUniforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<int>(type: "integer", nullable: false),
                    InternshipExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectClients",
                columns: table => new
                {
                    ClientsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectClients", x => new { x.ClientsId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_ProjectClients_Employees_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectClients_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExecutorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectItems_Employees_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectItems_ProjectItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProjectItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItemSupervisors",
                columns: table => new
                {
                    SupervisedItemsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupervisorsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItemSupervisors", x => new { x.SupervisedItemsId, x.SupervisorsId });
                    table.ForeignKey(
                        name: "FK_ProjectItemSupervisors_Employees_SupervisorsId",
                        column: x => x.SupervisorsId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectItemSupervisors_ProjectItems_SupervisedItemsId",
                        column: x => x.SupervisedItemsId,
                        principalTable: "ProjectItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectClients_ProjectsId",
                table: "ProjectClients",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ExecutorId",
                table: "ProjectItems",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ParentId",
                table: "ProjectItems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ProjectId",
                table: "ProjectItems",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItemSupervisors_SupervisorsId",
                table: "ProjectItemSupervisors",
                column: "SupervisorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeUniforms");

            migrationBuilder.DropTable(
                name: "ProjectClients");

            migrationBuilder.DropTable(
                name: "ProjectItemSupervisors");

            migrationBuilder.DropTable(
                name: "ProjectItems");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
