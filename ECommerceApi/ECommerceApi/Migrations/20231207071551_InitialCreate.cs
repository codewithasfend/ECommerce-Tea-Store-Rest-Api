using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsTrending = table.Column<bool>(type: "bit", nullable: false),
                    IsBestSelling = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "blacktea.jpg", "Black Tea" },
                    { 2, "greentea.jpg", "Green Tea" },
                    { 3, "whitetea.jpg", "White Tea" },
                    { 4, "oolongtea.jpg", "Oolong Tea" },
                    { 5, "caffeinefreetea.jpg", "Caffeine Free " }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Detail", "ImageUrl", "IsBestSelling", "IsTrending", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "A delectable medley with an enticing floral aroma. Rose Black combines loose leaf black tea with smooth notes of rose and a bright finish. Rose Black is delicious hot or cold brewed and poured over ice. The perfect sip for any time of day.", "roseblacktea.jpg", true, false, "Rose Black Tea", 25.0 },
                    { 2, 1, "A customer favorite. Start your day in a bold way with our loose leaf organic Earl Grey Crème tea. This is a remarkable black tea blend that is hand blended with fragrant oil of bergamot for citrus notes followed by a touch of French vanilla for a rich and robust finish.", "earlgreycremetea.jpg", false, false, "Earl Grey Crème Tea", 28.0 },
                    { 3, 1, "Packed with flavor, our traditional blend of organic loose leaf black tea is perfect for starting the day. This robust black tea brews smooth and malty, with a clean finish.", "englishbreakfasttea.jpg", false, false, "English Breakfast Tea", 20.0 },
                    { 4, 1, "A unique twist on a traditional favorite. Our London tea blend elicits sweet, fragrant floral notes followed by a rich citrusy finish. This organic lavender earl grey tea is a morning or afternoon delight.", "londontea.jpg", true, true, "London Tea", 30.0 },
                    { 5, 1, "Start your day in a bold way with our Classic Black blended black tea. This organic loose leaf black tea is a hand-blended mix of whole leaf black tea that is certain to delight all of your senses.", "classicblacktea.jpg", false, true, "Classic Black Tea", 22.0 },
                    { 6, 2, "This proprietary blend of traditional organic tea and purifying herbs combine delicious flavor and a gentle yet effective way of regulating the body's natural cleansing process. With citrus, berry, and spicy notes, this ayurvedic tea is a perfect cup of bliss.", "cleansetea.jpg", true, false, "Cleanse Tea", 23.0 },
                    { 7, 2, "Our award-winning Meyer Lemon Tea blend combines a delightful medley of bright citrus flavors with our premium classic green tea for a vibrant cup. Enjoy the bright flavor notes of real Meyer lemons, complemented by the sweet grassiness of our ultra-premium green teas in one refreshing cup.", "meyerlemontea.jpg", false, false, "Meyer Lemon Tea", 26.0 },
                    { 8, 2, "An award-winning white and green tea blend with a touch of bergamot. Liquid Jade delivers a clean, fresh taste with light notes of honey and citrus.", "liquidjadetea.jpg", false, false, "Liquid Jade Tea", 32.0 },
                    { 9, 2, "An elevated twist on the classic Gen Mai Cha, our Kyoto green tea is sourced and blended by master tea blenders in Kyoto, Japan. This Japanese green tea is a Matcha Iri Genmaicha made with premium Gyokuro green tea, roasty puffed rice, and Ceremonial Matcha.", "kyototea.jpg", false, true, "Kyoto Tea", 35.0 },
                    { 10, 2, "An organic green tea that has been repeatedly baked and scented with fresh and fragrant night-blooming jasmine blossoms. This jasmine green tea has beautiful floral and sweet notes.", "jasminereservetea.jpg", false, false, "Jasmine Reserve Tea", 30.0 },
                    { 11, 2, "Organic peppermint and spearmint are hand-blended with organic gunpowder green tea to create this refreshing blend. This cool, soothing mint tea adds a refreshing touch to any meal.", "moroccanminttea.jpg", true, false, "Moroccan Mint Tea", 25.0 },
                    { 12, 3, "Experience the fragrance and flavors of Japan's annual cherry blossom season with our Sakura white tea blend. With delicate floral and fruity notes, this Sakura blossom tea exudes a sweet cherry aroma in each cup.", "sakuratea.jpg", false, false, "Sakura Tea", 30.0 },
                    { 13, 3, "The essence of fresh-picked peaches infuses the senses in this organic white tea infusion. Steeps a light and refreshing cup perfect for a mid-afternoon lift.", "whitepeachtea.jpg", true, false, "White Peach Tea", 27.0 },
                    { 14, 3, "Organic Silver needle is the most sought after white tea and is only harvested for a few days each year in the northern district of Fujian, China. This Chinese Silver Needle tea has a light golden flush with a unique savory aroma and a woodsy body, perfect for any time of day.", "silverneedletea.jpg", false, false, "Silver Needle Tea", 35.0 },
                    { 15, 3, "Silver-tipped white tea harvested at the base of the Himalayas in Darjeeling. Rare and unique bud and leaf grades are hand harvested in small quantities during the first flush season of 2023. The high elevation, time of harvest, and minimal processing allow the buds and leaves to deliver a delicate flavor profile and smooth round finish.", "himalayanwhitetea.jpg", false, false, "Himalayan White Tea", 32.0 },
                    { 16, 3, "A dreamy, tropical coconut white tea. White Coconut Crème tea has a light body and smooth creamy texture. A customer favorite both hot and iced.", "whitecoconutcremetea.jpg", false, false, "White Coconut Crème Tea", 29.0 },
                    { 17, 4, "Our Mandarin Silk tea is a smooth, rich blend of Pouchong tea leaves blended with lemon myrtle and vanilla essence. With creamy and citrus notes, this oolong tea is certain to delight your senses.", "mandarinsilktea.jpg", false, false, "Mandarin Silk Tea", 22.0 },
                    { 18, 4, "Succulent schizandra berries and sweet amber oolong leaves are blended with the tender essence of plum to create our Plum Oolong tea. This tart and fruity plum tea lends a beautiful cup at any time of day.", "plumoolongtea.jpg", false, false, "Plum Oolong Tea", 26.0 },
                    { 19, 4, "Long, beautiful leaves unwind and unfurl when steeped to release a smooth, rich flavor. Our Wuyi Oolong tea is 60-80% oxidized and steeps a deep golden hue with crisp and earthy tones and a slightly peppery finish.", "wuyioolongtea.jpg", false, false, "Wuyi Oolong Tea", 24.0 },
                    { 20, 4, "Grown and harvested in Fujian, China at a garden elevation of 1500m and straight into your morning cup. This Chinese oolong tea is 90% oxidized and steeps dark amber in color with smooth, sweet flavor notes of honey and aged bourbon and a finish of orange blossom and spice.", "crimsonoolongtea.jpg", false, true, "Crimson Oolong Tea", 30.0 },
                    { 21, 4, "Formerly known as 12:00pm, our Peach Oolong Tea blend is a delightfully refreshing midday pick-me-up. This oolong tea blend has a rich woodsy flavor with notes of ripened peaches and a sweet honey finish. Take a moment to treat yourself to this stunning peach tea.", "peachoolongtea.jpg", true, false, "Peach Oolong Tea", 28.0 },
                    { 22, 5, "A calming sleepytime tea with smooth and minty flavor notes. Steep this tea for sleep either to accentuate a midday nap or head to your evening slumber.", "sleepblend.jpg", false, true, "Sleep Blend", 18.0 },
                    { 23, 5, "An invigorating blend of turmeric, ginger, cinnamon, and other fragrant spices, this loose leaf blend draws from Ayurvedic principles to energize and awaken your mind and body--all without caffeine! This autumnal tisane brews to a beautiful copper hue and can be enjoyed at any time of day.", "brighteyedblend.jpg", true, false, "Bright Eyed Blend", 23.0 },
                    { 24, 5, "Our Egyptian Chamomile elicits sweet, calming flavor notes. This tisane is round and soothing with each and every sip, perfect for any time of day.", "egyptianchamomiletea.jpg", false, false, "Egyptian Chamomile Tea", 20.0 },
                    { 25, 5, "This vanilla rooibos tea is a delectable infusion of enticingly sweet and tangy flavors harmoniously complimented by the soothing smoothness of fresh cream. Our Vanilla Berry Truffle tea is an enjoyable dessert blend at any time of day.", "vanillaberrytruffletea.jpg", false, false, "Vanilla Berry Truffle Tea", 25.0 },
                    { 26, 5, "Our Lemon Meringue tea has a light, fluffy texture and a sweet, creamy finish. This rooibos based blend is a delight for any moments of sweet cravings throughout the day.", "lemonmeringuetea.jpg", false, true, "Lemon Meringue Tea", 21.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
