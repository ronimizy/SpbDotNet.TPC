using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ronimizy.SpbDotNet.TPC.Migrations.TptToTpc.Migrations
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "CasualEmployeeUniform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShirtColorArgb = table.Column<int>(type: "integer", nullable: false),
                    ShirtName = table.Column<string>(type: "text", nullable: false),
                    ShirtMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    JeansColorArgb = table.Column<int>(type: "integer", nullable: false),
                    JeansName = table.Column<string>(type: "text", nullable: false),
                    JeansMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    ShoesColorArgb = table.Column<int>(type: "integer", nullable: false),
                    ShoesName = table.Column<string>(type: "text", nullable: false),
                    ShoesMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    HoodieAllowed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasualEmployeeUniform", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasualEmployeeUniform_EmployeeUniforms_Id",
                        column: x => x.Id,
                        principalTable: "EmployeeUniforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisplayEmployeeUniform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TuxedoColorArgb = table.Column<int>(type: "integer", nullable: false),
                    TuxedoName = table.Column<string>(type: "text", nullable: false),
                    TuxedoMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    DisplayShirtColorArgb = table.Column<int>(type: "integer", nullable: false),
                    DisplayShirtName = table.Column<string>(type: "text", nullable: false),
                    DisplayShirtMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    DisplayShoeColorArgb = table.Column<int>(type: "integer", nullable: false),
                    DisplayShoeName = table.Column<string>(type: "text", nullable: false),
                    DisplayShoeMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    DisplayTieColorArgb = table.Column<int>(type: "integer", nullable: false),
                    DisplayTieName = table.Column<string>(type: "text", nullable: false),
                    DisplayTieMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    DisplayBeltColorArgb = table.Column<int>(type: "integer", nullable: false),
                    DisplayBeltName = table.Column<string>(type: "text", nullable: false),
                    DisplayBeltMostPopularSize = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayEmployeeUniform", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisplayEmployeeUniform_EmployeeUniforms_Id",
                        column: x => x.Id,
                        principalTable: "EmployeeUniforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficialEmployeeUniform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JacketColorArgb = table.Column<int>(type: "integer", nullable: false),
                    JacketName = table.Column<string>(type: "text", nullable: false),
                    JacketMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    OfficialPantsColorArgb = table.Column<int>(type: "integer", nullable: false),
                    OfficialPantsName = table.Column<string>(type: "text", nullable: false),
                    OfficialPantsMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    OfficialShoesColorArgb = table.Column<int>(type: "integer", nullable: false),
                    OfficialShoesName = table.Column<string>(type: "text", nullable: false),
                    OfficialShoesMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    OfficialShirtColorArgb = table.Column<int>(type: "integer", nullable: false),
                    OfficialShirtName = table.Column<string>(type: "text", nullable: false),
                    OfficialShirtMostPopularSize = table.Column<int>(type: "integer", nullable: false),
                    OfficialTieColorArgb = table.Column<int>(type: "integer", nullable: false),
                    OfficialTieName = table.Column<string>(type: "text", nullable: false),
                    OfficialTieMostPopularSize = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialEmployeeUniform", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialEmployeeUniform_EmployeeUniforms_Id",
                        column: x => x.Id,
                        principalTable: "EmployeeUniforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
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
                name: "Subordinate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subordinate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subordinate_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intern",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InternshipExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intern", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intern_Subordinate_Id",
                        column: x => x.Id,
                        principalTable: "Subordinate",
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
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "ProjectStage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectStage_ProjectItems_Id",
                        column: x => x.Id,
                        principalTable: "ProjectItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExecutorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTask_Employees_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTask_ProjectItems_Id",
                        column: x => x.Id,
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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ExecutorId",
                table: "ProjectTask",
                column: "ExecutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Manager_ManagerId",
                table: "Employees",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_ProjectStage_ParentId",
                table: "ProjectItems",
                column: "ParentId",
                principalTable: "ProjectStage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Manager_ManagerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_Projects_ProjectId",
                table: "ProjectItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_ProjectStage_ParentId",
                table: "ProjectItems");

            migrationBuilder.DropTable(
                name: "CasualEmployeeUniform");

            migrationBuilder.DropTable(
                name: "DisplayEmployeeUniform");

            migrationBuilder.DropTable(
                name: "Intern");

            migrationBuilder.DropTable(
                name: "OfficialEmployeeUniform");

            migrationBuilder.DropTable(
                name: "ProjectClients");

            migrationBuilder.DropTable(
                name: "ProjectItemSupervisors");

            migrationBuilder.DropTable(
                name: "ProjectTask");

            migrationBuilder.DropTable(
                name: "Subordinate");

            migrationBuilder.DropTable(
                name: "EmployeeUniforms");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectStage");

            migrationBuilder.DropTable(
                name: "ProjectItems");
        }
    }
}
