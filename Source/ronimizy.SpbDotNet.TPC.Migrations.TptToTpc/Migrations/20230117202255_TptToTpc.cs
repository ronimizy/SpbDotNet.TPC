using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ronimizy.SpbDotNet.TPC.Migrations.TptToTpc.Migrations
{
    /// <inheritdoc />
    public partial class TptToTpc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasualEmployeeUniform_EmployeeUniforms_Id",
                table: "CasualEmployeeUniform");

            migrationBuilder.DropForeignKey(
                name: "FK_DisplayEmployeeUniform_EmployeeUniforms_Id",
                table: "DisplayEmployeeUniform");

            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Subordinate_Id",
                table: "Intern");

            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Employees_Id",
                table: "Manager");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficialEmployeeUniform_EmployeeUniforms_Id",
                table: "OfficialEmployeeUniform");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectClients_Employees_ClientsId",
                table: "ProjectClients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItemSupervisors_Employees_SupervisorsId",
                table: "ProjectItemSupervisors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItemSupervisors_ProjectItems_SupervisedItemsId",
                table: "ProjectItemSupervisors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStage_ProjectItems_Id",
                table: "ProjectStage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Employees_ExecutorId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_ProjectItems_Id",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Subordinate_Employees_Id",
                table: "Subordinate");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeUniforms");

            migrationBuilder.DropTable(
                name: "ProjectItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Subordinate",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Subordinate",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProjectTask",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "ProjectTask",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "ProjectTask",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProjectStage",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "ProjectStage",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "ProjectStage",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Manager",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Manager",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Intern",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Intern",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Subordinate_ManagerId",
                table: "Subordinate",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subordinate_UserId",
                table: "Subordinate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ParentId",
                table: "ProjectTask",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "ProjectTask",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStage_ParentId",
                table: "ProjectStage",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStage_ProjectId",
                table: "ProjectStage",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_ManagerId",
                table: "Manager",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_UserId",
                table: "Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Intern_ManagerId",
                table: "Intern",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Intern_UserId",
                table: "Intern",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Manager_ManagerId",
                table: "Intern",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Users_UserId",
                table: "Intern",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Manager_ManagerId",
                table: "Manager",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Users_UserId",
                table: "Manager",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStage_ProjectStage_ParentId",
                table: "ProjectStage",
                column: "ParentId",
                principalTable: "ProjectStage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStage_Projects_ProjectId",
                table: "ProjectStage",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_ProjectStage_ParentId",
                table: "ProjectTask",
                column: "ParentId",
                principalTable: "ProjectStage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Projects_ProjectId",
                table: "ProjectTask",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subordinate_Manager_ManagerId",
                table: "Subordinate",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subordinate_Users_UserId",
                table: "Subordinate",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Manager_ManagerId",
                table: "Intern");

            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Users_UserId",
                table: "Intern");

            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Manager_ManagerId",
                table: "Manager");

            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Users_UserId",
                table: "Manager");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStage_ProjectStage_ParentId",
                table: "ProjectStage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStage_Projects_ProjectId",
                table: "ProjectStage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_ProjectStage_ParentId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Projects_ProjectId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Subordinate_Manager_ManagerId",
                table: "Subordinate");

            migrationBuilder.DropForeignKey(
                name: "FK_Subordinate_Users_UserId",
                table: "Subordinate");

            migrationBuilder.DropIndex(
                name: "IX_Subordinate_ManagerId",
                table: "Subordinate");

            migrationBuilder.DropIndex(
                name: "IX_Subordinate_UserId",
                table: "Subordinate");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTask_ParentId",
                table: "ProjectTask");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "ProjectTask");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStage_ParentId",
                table: "ProjectStage");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStage_ProjectId",
                table: "ProjectStage");

            migrationBuilder.DropIndex(
                name: "IX_Manager_ManagerId",
                table: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Manager_UserId",
                table: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Intern_ManagerId",
                table: "Intern");

            migrationBuilder.DropIndex(
                name: "IX_Intern_UserId",
                table: "Intern");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Subordinate");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Subordinate");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProjectTask");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ProjectTask");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectTask");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProjectStage");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ProjectStage");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectStage");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Intern");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Intern");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "ProjectItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectItems_ProjectStage_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProjectStage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
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
                name: "IX_ProjectItems_ParentId",
                table: "ProjectItems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ProjectId",
                table: "ProjectItems",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasualEmployeeUniform_EmployeeUniforms_Id",
                table: "CasualEmployeeUniform",
                column: "Id",
                principalTable: "EmployeeUniforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisplayEmployeeUniform_EmployeeUniforms_Id",
                table: "DisplayEmployeeUniform",
                column: "Id",
                principalTable: "EmployeeUniforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Subordinate_Id",
                table: "Intern",
                column: "Id",
                principalTable: "Subordinate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Employees_Id",
                table: "Manager",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialEmployeeUniform_EmployeeUniforms_Id",
                table: "OfficialEmployeeUniform",
                column: "Id",
                principalTable: "EmployeeUniforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectClients_Employees_ClientsId",
                table: "ProjectClients",
                column: "ClientsId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItemSupervisors_Employees_SupervisorsId",
                table: "ProjectItemSupervisors",
                column: "SupervisorsId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItemSupervisors_ProjectItems_SupervisedItemsId",
                table: "ProjectItemSupervisors",
                column: "SupervisedItemsId",
                principalTable: "ProjectItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStage_ProjectItems_Id",
                table: "ProjectStage",
                column: "Id",
                principalTable: "ProjectItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Employees_ExecutorId",
                table: "ProjectTask",
                column: "ExecutorId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_ProjectItems_Id",
                table: "ProjectTask",
                column: "Id",
                principalTable: "ProjectItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subordinate_Employees_Id",
                table: "Subordinate",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
