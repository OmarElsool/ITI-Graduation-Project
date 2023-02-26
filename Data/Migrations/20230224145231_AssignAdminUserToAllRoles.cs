using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airbnb.Data.Migrations
{
    public partial class AssignAdminUserToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] (UserId,RoleId) SELECT 'af1a143f-7d00-49a6-af51-a2384399d40c',Id FROM [dbo].[AspNetRoles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId = 'af1a143f-7d00-49a6-af51-a2384399d40c'");
        }
    }
}
