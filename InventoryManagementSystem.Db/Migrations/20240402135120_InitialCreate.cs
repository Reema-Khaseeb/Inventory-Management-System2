using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryManagementSystem.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Books" },
                    { 4, "Kitchen Appliances" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "user1@example.com", "$2a$11$yahCOxMg6Rwv7NYWhCS1GOJBq2tk3HGOWvkWt2spsyva0KpK3j3CG", "user1" },
                    { 2, "user2@example.com", "$2a$11$YY381W06BNlpt3rU/on4CunDQjjD9MwD.YqYhvBzkUxH4N76qbgTy", "user2" },
                    { 3, "user3@example.com", "$2a$11$d6s76qB5SOwxWLjQ.xfV2OMHGYtRGT9Uo52ZZvB.gQiCnyeUFhM4u", "user3" },
                    { 4, "user4@example.com", "$2a$11$oNLEjuRPg0IxVAi9ZlbDseJ7HWva0EHLBa2GDG1b9QletYBGqmBeC", "user4" },
                    { 5, "user5@example.com", "$2a$11$JyK1EIpy5TlgkfnpRBXL2uNYoNO7054Yw8SEVQbBEjR.vjltVJAUG", "user5" },
                    { 6, "user6@example.com", "$2a$11$Nk17MqR0b3Xy59Hio1.nqOKu8y74JvI8tiGikVtQg0cPBHsgKiGZG", "user6" },
                    { 7, "user7@example.com", "$2a$11$5GRznd0kdTlt2P3zVn7B8.ovFv2FP09BqBUBODC7zbHmjLv8kbudq", "user7" },
                    { 8, "user8@example.com", "$2a$11$HMuhTUxaNH7pEPFKkYoeTeNflRZALJtZK0f3SG3Y17IIu3ZbsJMKC", "user8" },
                    { 9, "user9@example.com", "$2a$11$6y1bNprzthgUGx15M7dsqOTFKMFB2gjvWqeW1fQLBbiDbjLZq7IXS", "user9" },
                    { 10, "user10@example.com", "$2a$11$n/HsY0ROmMh1lY7NcqvYYu4HMH0ZjWTif1hj5fmhWcHNwqRLjy1Q6", "user10" },
                    { 11, "user11@example.com", "$2a$11$UW2mRYaxWCRGo5MC3MXaTOsSI.9xtWn8uZcC/hskoUTJYZpEnVIWq", "user11" },
                    { 12, "user12@example.com", "$2a$11$rGASBo/h9dGhFWCL7wQlAuKh59FfrZzC0/vYFW2Mp5WOUGrXdlkdW", "user12" },
                    { 13, "user13@example.com", "$2a$11$YXN.tOYdO2TFrF2qxvN8FOF93QkzqkGkDX9ZCJW24HdbBV/wBZ.SG", "user13" },
                    { 14, "user14@example.com", "$2a$11$ocfn6J5zQwXdKwcH6HPso.Y9JujDvdUH/T5K5VNU6VKJrxuzvaXA6", "user14" },
                    { 15, "user15@example.com", "$2a$11$DECJGnmm0F/97PekbQuTv.li7RLcPg4NRaZaTJZf8uzRpxOL7.NDy", "user15" },
                    { 16, "user16@example.com", "$2a$11$SbV/GuevY6RPzI/8geiIwutC88vIQeH4R5UsUg6t/pjL7QmCEAW0W", "user16" },
                    { 17, "user17@example.com", "$2a$11$KiDaiCW8yAZZdKrQQ.B2veBHUjWikhYgr/N5o7cvJ9etc/MbSqYNW", "user17" },
                    { 18, "user18@example.com", "$2a$11$9JfVgE3Mv3Y0INWZ3AFN/ukG3K1J.3QB9cKpOoa1L3ivovtZ.mOla", "user18" },
                    { 19, "user19@example.com", "$2a$11$DQnGH5wwxiOJPXur2ST54u13WovBdpvS32WQ845YipS37zHVS2GHq", "user19" },
                    { 20, "user20@example.com", "$2a$11$94p7QIVaOkoJ0XuBz4nEOuB5oxvcBTwN2uYEYRIMZPVFn8O9QJ7SG", "user20" },
                    { 21, "user21@example.com", "$2a$11$khF986iNnhiHGZP/9j0OyOGMnL3oLSCfH2OCYbqSFHCteRwaKARGW", "user21" },
                    { 22, "user22@example.com", "$2a$11$WHKD05V96T5ntqqcCHWl0exy/GMi1LRn8zdL6dGxhpI4ZR43Uh3fu", "user22" },
                    { 23, "user23@example.com", "$2a$11$m1DBACOvT/.xxNxSNEtT2u6gkVRebmNeYDcRIJj5Coizvv/JqEfvC", "user23" },
                    { 24, "user24@example.com", "$2a$11$apwQorJwP6qH.fFVnk9PvOFNMm3Wy/8KiWx71A.bSeIOOlW8ZjhFC", "user24" },
                    { 25, "user25@example.com", "$2a$11$4yg2XIt4nyJNkxArdAIr8ef.60WrI3qKl2JxZQowUkDh6kGg5jD2.", "user25" },
                    { 26, "user26@example.com", "$2a$11$8U6hzveO6oN08HR6PSdFaOrpXDmxQfWW/jY1qc8n4Q.YppeUqpGsO", "user26" },
                    { 27, "user27@example.com", "$2a$11$JfPW/hsXjVzrVYRrW.nvAuUgvYnhuLjBeJDKSUDVa1kyCmuux0P8e", "user27" },
                    { 28, "user28@example.com", "$2a$11$.SX7Sxip7BnjIP.QdFlbdeOp8d6MTilDQQbKAf3b/tJUEnxdoK0ii", "user28" },
                    { 29, "user29@example.com", "$2a$11$Sdgxh3gANiHUb98XkBgGauZNClpBsSzKQjMqVmA3dPYdJtirjfG2G", "user29" },
                    { 30, "user30@example.com", "$2a$11$qhU1nFUPr8FElz/YTEAL5uIcB28zt1JBM7zjtgTz7Sd4TyVEguBhu", "user30" },
                    { 31, "user31@example.com", "$2a$11$zXCx.VrJMzJws5ocCbEeHeatUo/uKK0rAY9VantOIdMJbtqr7waie", "user31" },
                    { 32, "user32@example.com", "$2a$11$R5pBGMBzsz2WsMAvTBIOAuEoUDhYgLD/79QEuHF60O13vjg7GM1AC", "user32" },
                    { 33, "user33@example.com", "$2a$11$NemJw4/P.1Aah1ZtpuzNxOW96vu/c/eu9xZvtU9ZeynNh5x7zHUUS", "user33" },
                    { 34, "user34@example.com", "$2a$11$mjyL00CZYUNEQJHzXN2QGeooWlhxFMurPNhU8VkeExYXeuI5O4Mra", "user34" },
                    { 35, "user35@example.com", "$2a$11$UTcQUf2UaXpKcNYpDjatK.dMq/FyY2CWHuwrwn9RVTAcMVg2HgiD.", "user35" },
                    { 36, "user36@example.com", "$2a$11$ZEN7x3fk9HJazF1X8epFBuDVAX5/aUr9vgNFyPLLPfRuNKigTQ8Ou", "user36" },
                    { 37, "user37@example.com", "$2a$11$jkvdINT5nJvH7i/fcbqhsOCBAbGRaZvmDwMFBwRURTdfrJB6UCxES", "user37" },
                    { 38, "user38@example.com", "$2a$11$jhA9QiMo28s.eUPHfBKp3elE.v98QI6tttODyXhGDIo8WDMaXaWka", "user38" },
                    { 39, "user39@example.com", "$2a$11$Em3/IPqO.zAM26AM8ypWPudkmvFTAYMsjHVM.7D6SFp29WPsGnQxi", "user39" },
                    { 40, "user40@example.com", "$2a$11$l7uAIGnVsCjTcvPR9j6Tqeu9ZaKzv72yIHTPiHCaNGjqnwe7xu9Zy", "user40" },
                    { 41, "user41@example.com", "$2a$11$hPrR5Je9CJTkcn24BdNwYOLfsl9YCw6G3KZ50i3.eIDUoh6YDA/0m", "user41" },
                    { 42, "user42@example.com", "$2a$11$puAExtRaCU2O1d5vDk20W.PtAFgE3WL9YxyCOa130BTbqhBpPCnqG", "user42" },
                    { 43, "user43@example.com", "$2a$11$ayPu5rmpQp1kcqBskiFix.OlGlm0xktGCQr3xAjFTL8HGplZSI2qK", "user43" },
                    { 44, "user44@example.com", "$2a$11$kiM9I7QveNSgsvKHZcxSAeEhmz/.qBVniF0Z28OXeOpWVEYZl2kGq", "user44" },
                    { 45, "user45@example.com", "$2a$11$qcTlSFzYD7PSnJF.w3odmOCYHna2Hu3cM1tfC8hlh5hoRegW29Mly", "user45" },
                    { 46, "user46@example.com", "$2a$11$.SnI66qr0CjSkeeqxpU.BOGTAOlyNUQj8pCT5JkxW5Dz69og/tHUi", "user46" },
                    { 47, "user47@example.com", "$2a$11$QhnGrg1pcEfjyLQBybSayeqz9DsEnST0CqJKkcWGhpZ/j8qNOcepS", "user47" },
                    { 48, "user48@example.com", "$2a$11$FX9YaKPa6meJkp9.ohp71O0kRgoWkYtoPKyHe8wiZDzFW3JiPZC.O", "user48" },
                    { 49, "user49@example.com", "$2a$11$Fx397PQsypLPPvt3awfIK.klz.Jv.Vom8UQF2oQDtvjTxfOHjjpLG", "user49" },
                    { 50, "user50@example.com", "$2a$11$Dg8ZuJnwG0Tl8/IKGgA8..6RKx0mU7NECJjJUjPr3rme4MpTRJoLy", "user50" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Quantity", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "A portable computer", "Laptop", 10, 1, 1 },
                    { 2, 2, "A cotton shirt", "T-Shirt", 50, 0, 2 },
                    { 3, 1, "High-end mobile phone", "Smartphone", 25, 0, 3 },
                    { 4, 2, "Denim jeans", "Jeans", 0, 2, 4 },
                    { 5, 3, "Electronic book reader", "E-Reader", 15, 1, 5 },
                    { 6, 4, "Kitchen appliance", "Blender", 20, 0, 6 },
                    { 7, 4, "Heats food quickly and efficiently", "Microwave Oven", 30, 0, 7 },
                    { 8, 3, "A novel set in a fictional universe", "Fantasy Novel", 50, 0, 8 },
                    { 9, 1, "Wireless over-ear headphones", "Headphones", 60, 0, 9 },
                    { 10, 2, "Warm wool sweater", "Sweater", 35, 0, 10 },
                    { 11, 4, "LED desk lamp", "Lamp", 40, 0, 11 },
                    { 12, 3, "Covers world history", "History Book", 20, 0, 12 },
                    { 13, 1, "Latest generation home video game console", "Gaming Console", 15, 1, 13 },
                    { 14, 2, "Lightweight and comfortable running shoes", "Running Shoes", 25, 0, 14 },
                    { 15, 3, "Space adventure novel", "Sci-Fi Novel", 30, 0, 15 },
                    { 16, 4, "Automatic drip coffee maker", "Coffee Maker", 20, 0, 16 },
                    { 17, 1, "Wearable technology for fitness tracking", "Smartwatch", 40, 0, 17 },
                    { 18, 2, "High-quality leather jacket", "Leather Jacket", 10, 1, 18 },
                    { 19, 3, "Collection of gourmet recipes", "Cookbook", 50, 0, 19 },
                    { 20, 4, "Improves indoor air quality", "Air Purifier", 15, 1, 20 },
                    { 21, 2, "Portable touchscreen computer", "Tablet", 25, 0, 1 },
                    { 26, 2, "Soft cotton hoodie", "Hoodie", 60, 0, 2 },
                    { 27, 4, "Adjustable LED desk lamp", "Desk Lamp", 70, 0, 3 },
                    { 28, 3, "Engaging and suspenseful mystery novel", "Mystery Novel", 80, 0, 4 },
                    { 29, 1, "1TB USB external hard drive", "External Hard Drive", 90, 0, 5 },
                    { 30, 2, "UV protection sunglasses", "Sunglasses", 100, 0, 6 },
                    { 31, 4, "4-slice toaster", "Toaster", 110, 0, 7 },
                    { 32, 3, "Biography of a historical figure", "Biography Book", 120, 0, 8 },
                    { 33, 1, "Mechanical RGB gaming keyboard", "Gaming Keyboard", 130, 0, 9 },
                    { 34, 2, "Lightweight running shorts", "Running Shorts", 0, 2, 10 },
                    { 35, 4, "Bagless cyclone vacuum cleaner", "Vacuum Cleaner", 150, 0, 11 },
                    { 36, 3, "Guide to personal growth and productivity", "Self-Help Book", 160, 0, 12 },
                    { 37, 1, "High-definition USB webcam", "Webcam", 170, 0, 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserId",
                table: "Item",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
