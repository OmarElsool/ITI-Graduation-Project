using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airbnb.Data.Migrations
{
    public partial class addAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [BirthDate], [City], [FName], [Gender], [LName], [Photo], [Street], [ZipCode]) VALUES (N'af1a143f-7d00-49a6-af51-a2384399d40c', N'Admin@test.com', N'ADMIN@TEST.COM', N'Admin@test.com', N'ADMIN@TEST.COM', 1, N'AQAAAAEAACcQAAAAEMhfNUgvCsP3jWu7Da9simOr5KCy/dVrBWo3nN/ZMVFn4vtNX+8ZpVvcablfjzXDTg==', N'6TAVGGO65DPIIWSG6X3OIFHIJK5MMS5U', N'848d3175-ef17-4746-b1ef-d219098ef2a8', NULL, 0, 0, NULL, 1, 0, N'0001-01-01', N'', N'', 0, N'', N'', N'', N'')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE id = 'af1a143f-7d00-49a6-af51-a2384399d40c'");
        }
    }
}
