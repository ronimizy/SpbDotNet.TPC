using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ronimizy.SpbDotNet.TPC.Migrations.TphToTpc.Migrations
{
    /// <summary>
    ///     В данной миграции реализован только переход от TPH к TPC для таблиц Employees и ProjectItems
    ///     Миграции для таблицы EmployeeUniforms и миграции обратно – не будут работать
    /// </summary>
    public partial class TphToTpc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectStage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectStage_ProjectStage_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProjectStage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectStage_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Manager_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intern",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: true),
                    InternshipExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intern", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intern_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Intern_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql($"""
insert into "Manager" ("Id", "UserId", "ManagerId")
select "Id", "UserId", "ManagerId" from "Employees" where "Discriminator" = 3
""");
            
            migrationBuilder.Sql($"""
insert into "Intern" ("Id", "UserId", "ManagerId", "InternshipExpiration")
select "Id", "UserId", "ManagerId", "InternshipExpiration" from "Employees" where "Discriminator" = 1
""");

            migrationBuilder.Sql($"""
insert into "ProjectStage" ("Id", "Name", "ProjectId", "ParentId")
select "Id", "Name", "ProjectId", "ParentId" from "ProjectItems" where "Discriminator" = 2
""");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectClients_Employees_ClientsId",
                table: "ProjectClients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_Employees_ExecutorId",
                table: "ProjectItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_ProjectItems_ParentId",
                table: "ProjectItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_Projects_ProjectId",
                table: "ProjectItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItemSupervisors_Employees_SupervisorsId",
                table: "ProjectItemSupervisors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItemSupervisors_ProjectItems_SupervisedItemsId",
                table: "ProjectItemSupervisors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectItems",
                table: "ProjectItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.Sql($"""
delete from "Employees"
where "Discriminator" != 2
""");

            migrationBuilder.Sql($"""
delete from "ProjectItems"
where "Discriminator" != 2
""");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "InternshipExpiration",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "ProjectItems",
                newName: "ProjectTask");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Subordinate");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectItems_ProjectId",
                table: "ProjectTask",
                newName: "IX_ProjectTask_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectItems_ParentId",
                table: "ProjectTask",
                newName: "IX_ProjectTask_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectItems_ExecutorId",
                table: "ProjectTask",
                newName: "IX_ProjectTask_ExecutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserId",
                table: "Subordinate",
                newName: "IX_Subordinate_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ManagerId",
                table: "Subordinate",
                newName: "IX_Subordinate_ManagerId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectTask",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTask",
                table: "ProjectTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subordinate",
                table: "Subordinate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Intern_ManagerId",
                table: "Intern",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Intern_UserId",
                table: "Intern",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_ManagerId",
                table: "Manager",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_UserId",
                table: "Manager",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStage_ParentId",
                table: "ProjectStage",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStage_ProjectId",
                table: "ProjectStage",
                column: "ProjectId");

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

            migrationBuilder.DropTable(
                name: "Intern");

            migrationBuilder.DropTable(
                name: "ProjectStage");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subordinate",
                table: "Subordinate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTask",
                table: "ProjectTask");

            migrationBuilder.RenameTable(
                name: "Subordinate",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "ProjectTask",
                newName: "ProjectItems");

            migrationBuilder.RenameIndex(
                name: "IX_Subordinate_UserId",
                table: "Employees",
                newName: "IX_Employees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Subordinate_ManagerId",
                table: "Employees",
                newName: "IX_Employees_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "ProjectItems",
                newName: "IX_ProjectItems_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_ParentId",
                table: "ProjectItems",
                newName: "IX_ProjectItems_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_ExecutorId",
                table: "ProjectItems",
                newName: "IX_ProjectItems_ExecutorId");

            migrationBuilder.AddColumn<int>(
                name: "Discriminator",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "InternshipExpiration",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Discriminator",
                table: "ProjectItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectItems",
                table: "ProjectItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
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
                name: "FK_ProjectItems_Employees_ExecutorId",
                table: "ProjectItems",
                column: "ExecutorId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_ProjectItems_ParentId",
                table: "ProjectItems",
                column: "ParentId",
                principalTable: "ProjectItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_Projects_ProjectId",
                table: "ProjectItems",
                column: "ProjectId",
                principalTable: "Projects",
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
        }
    }
}
