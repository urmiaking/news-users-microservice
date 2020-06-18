using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersMicroService.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ResetPasswordCode = table.Column<string>(nullable: true),
                    ActivationCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "Email", "FullName", "IsActive", "Password", "ResetPasswordCode", "UserType" },
                values: new object[] { 1, null, "admin@admin.com", "مدیر سایت", true, "db901737c41e490dec8bded913f112e5e7c720c3847558f0e5c65128bdb1b34c", null, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "Email", "FullName", "IsActive", "Password", "ResetPasswordCode", "UserType" },
                values: new object[] { 2, null, "user@user.com", "کاربر سایت", true, "db901737c41e490dec8bded913f112e5e7c720c3847558f0e5c65128bdb1b34c", null, "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
