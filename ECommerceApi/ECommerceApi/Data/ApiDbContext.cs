using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Black Tea", ImageUrl = "blacktea.jpg" },
                new Category { Id = 2, Name = "Green Tea", ImageUrl = "greentea.jpg" },
                new Category { Id = 3, Name = "White Tea", ImageUrl = "whitetea.jpg" },
                new Category { Id = 4, Name = "Oolong Tea", ImageUrl = "oolongtea.jpg" },
                new Category { Id = 5, Name = "Caffeine Free ", ImageUrl = "caffeinefreetea.jpg" }
                );


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Rose Black Tea", ImageUrl = "roseblacktea.jpg", CategoryId = 1, Price = 25, IsBestSelling = true, IsTrending = false, Detail = "A delectable medley with an enticing floral aroma. Rose Black combines loose leaf black tea with smooth notes of rose and a bright finish. Rose Black is delicious hot or cold brewed and poured over ice. The perfect sip for any time of day." },
                new Product { Id = 2, Name = "Earl Grey Crème Tea", ImageUrl = "earlgreycremetea.jpg", CategoryId = 1, Price = 28, IsBestSelling = false, IsTrending = false, Detail = "A customer favorite. Start your day in a bold way with our loose leaf organic Earl Grey Crème tea. This is a remarkable black tea blend that is hand blended with fragrant oil of bergamot for citrus notes followed by a touch of French vanilla for a rich and robust finish." },
                new Product { Id = 3, Name = "English Breakfast Tea", ImageUrl = "englishbreakfasttea.jpg", CategoryId = 1, Price = 20, IsBestSelling = false, IsTrending = false, Detail = "Packed with flavor, our traditional blend of organic loose leaf black tea is perfect for starting the day. This robust black tea brews smooth and malty, with a clean finish." },
                new Product { Id = 4, Name = "London Tea", ImageUrl = "londontea.jpg", CategoryId = 1, Price = 30, IsBestSelling = true, IsTrending = true, Detail = "A unique twist on a traditional favorite. Our London tea blend elicits sweet, fragrant floral notes followed by a rich citrusy finish. This organic lavender earl grey tea is a morning or afternoon delight." },
                new Product { Id = 5, Name = "Classic Black Tea", ImageUrl = "classicblacktea.jpg", CategoryId = 1, Price = 22, IsBestSelling = false, IsTrending = true, Detail = "Start your day in a bold way with our Classic Black blended black tea. This organic loose leaf black tea is a hand-blended mix of whole leaf black tea that is certain to delight all of your senses." },

                new Product { Id = 6, Name = "Cleanse Tea", ImageUrl = "cleansetea.jpg", CategoryId = 2, Price = 23, IsBestSelling = true, IsTrending = false, Detail = "This proprietary blend of traditional organic tea and purifying herbs combine delicious flavor and a gentle yet effective way of regulating the body's natural cleansing process. With citrus, berry, and spicy notes, this ayurvedic tea is a perfect cup of bliss." },
                new Product { Id = 7, Name = "Meyer Lemon Tea", ImageUrl = "meyerlemontea.jpg", CategoryId = 2, Price = 26, IsBestSelling = false, IsTrending = false, Detail = "Our award-winning Meyer Lemon Tea blend combines a delightful medley of bright citrus flavors with our premium classic green tea for a vibrant cup. Enjoy the bright flavor notes of real Meyer lemons, complemented by the sweet grassiness of our ultra-premium green teas in one refreshing cup." },
                new Product { Id = 8, Name = "Liquid Jade Tea", ImageUrl = "liquidjadetea.jpg", CategoryId = 2, Price = 32, IsBestSelling = false, IsTrending = false, Detail = "An award-winning white and green tea blend with a touch of bergamot. Liquid Jade delivers a clean, fresh taste with light notes of honey and citrus." },
                new Product { Id = 9, Name = "Kyoto Tea", ImageUrl = "kyototea.jpg", CategoryId = 2, Price = 35, IsBestSelling = false, IsTrending = true, Detail = "An elevated twist on the classic Gen Mai Cha, our Kyoto green tea is sourced and blended by master tea blenders in Kyoto, Japan. This Japanese green tea is a Matcha Iri Genmaicha made with premium Gyokuro green tea, roasty puffed rice, and Ceremonial Matcha." },
                new Product { Id = 10, Name = "Jasmine Reserve Tea", ImageUrl = "jasminereservetea.jpg", CategoryId = 2, Price = 30, IsBestSelling = false, IsTrending = false, Detail = "An organic green tea that has been repeatedly baked and scented with fresh and fragrant night-blooming jasmine blossoms. This jasmine green tea has beautiful floral and sweet notes." },
                new Product { Id = 11, Name = "Moroccan Mint Tea", ImageUrl = "moroccanminttea.jpg", CategoryId = 2, Price = 25, IsBestSelling = true, IsTrending = false, Detail = "Organic peppermint and spearmint are hand-blended with organic gunpowder green tea to create this refreshing blend. This cool, soothing mint tea adds a refreshing touch to any meal." },

                new Product { Id = 12, Name = "Sakura Tea", ImageUrl = "sakuratea.jpg", CategoryId = 3, Price = 30, IsBestSelling = false, IsTrending = false, Detail = "Experience the fragrance and flavors of Japan's annual cherry blossom season with our Sakura white tea blend. With delicate floral and fruity notes, this Sakura blossom tea exudes a sweet cherry aroma in each cup." },
                new Product { Id = 13, Name = "White Peach Tea", ImageUrl = "whitepeachtea.jpg", CategoryId = 3, Price = 27, IsBestSelling = true, IsTrending = false, Detail = "The essence of fresh-picked peaches infuses the senses in this organic white tea infusion. Steeps a light and refreshing cup perfect for a mid-afternoon lift." },
                new Product { Id = 14, Name = "Silver Needle Tea", ImageUrl = "silverneedletea.jpg", CategoryId = 3, Price = 35, IsBestSelling = false, IsTrending = false, Detail = "Organic Silver needle is the most sought after white tea and is only harvested for a few days each year in the northern district of Fujian, China. This Chinese Silver Needle tea has a light golden flush with a unique savory aroma and a woodsy body, perfect for any time of day." },
                new Product { Id = 15, Name = "Himalayan White Tea", ImageUrl = "himalayanwhitetea.jpg", CategoryId = 3, Price = 32, IsBestSelling = false, IsTrending = false, Detail = "Silver-tipped white tea harvested at the base of the Himalayas in Darjeeling. Rare and unique bud and leaf grades are hand harvested in small quantities during the first flush season of 2023. The high elevation, time of harvest, and minimal processing allow the buds and leaves to deliver a delicate flavor profile and smooth round finish." },
                new Product { Id = 16, Name = "White Coconut Crème Tea", ImageUrl = "whitecoconutcremetea.jpg", CategoryId = 3, Price = 29, IsBestSelling = false, IsTrending = false, Detail = "A dreamy, tropical coconut white tea. White Coconut Crème tea has a light body and smooth creamy texture. A customer favorite both hot and iced." },

                new Product { Id = 17, Name = "Mandarin Silk Tea", ImageUrl = "mandarinsilktea.jpg", CategoryId = 4, Price = 22, IsBestSelling = false, IsTrending = false, Detail = "Our Mandarin Silk tea is a smooth, rich blend of Pouchong tea leaves blended with lemon myrtle and vanilla essence. With creamy and citrus notes, this oolong tea is certain to delight your senses." },
                new Product { Id = 18, Name = "Plum Oolong Tea", ImageUrl = "plumoolongtea.jpg", CategoryId = 4, Price = 26, IsBestSelling = false, IsTrending = false, Detail = "Succulent schizandra berries and sweet amber oolong leaves are blended with the tender essence of plum to create our Plum Oolong tea. This tart and fruity plum tea lends a beautiful cup at any time of day." },
                new Product { Id = 19, Name = "Wuyi Oolong Tea", ImageUrl = "wuyioolongtea.jpg", CategoryId = 4, Price = 24, IsBestSelling = false, IsTrending = false, Detail = "Long, beautiful leaves unwind and unfurl when steeped to release a smooth, rich flavor. Our Wuyi Oolong tea is 60-80% oxidized and steeps a deep golden hue with crisp and earthy tones and a slightly peppery finish." },
                new Product { Id = 20, Name = "Crimson Oolong Tea", ImageUrl = "crimsonoolongtea.jpg", CategoryId = 4, Price = 30, IsBestSelling = false, IsTrending = true, Detail = "Grown and harvested in Fujian, China at a garden elevation of 1500m and straight into your morning cup. This Chinese oolong tea is 90% oxidized and steeps dark amber in color with smooth, sweet flavor notes of honey and aged bourbon and a finish of orange blossom and spice." },
                new Product { Id = 21, Name = "Peach Oolong Tea", ImageUrl = "peachoolongtea.jpg", CategoryId = 4, Price = 28, IsBestSelling = true, IsTrending = false, Detail = "Formerly known as 12:00pm, our Peach Oolong Tea blend is a delightfully refreshing midday pick-me-up. This oolong tea blend has a rich woodsy flavor with notes of ripened peaches and a sweet honey finish. Take a moment to treat yourself to this stunning peach tea." },

                new Product { Id = 22, Name = "Sleep Blend", ImageUrl = "sleepblend.jpg", CategoryId = 5, Price = 18, IsBestSelling = false, IsTrending = true, Detail = "A calming sleepytime tea with smooth and minty flavor notes. Steep this tea for sleep either to accentuate a midday nap or head to your evening slumber." },
                new Product { Id = 23, Name = "Bright Eyed Blend", ImageUrl = "brighteyedblend.jpg", CategoryId = 5, Price = 23, IsBestSelling = true, IsTrending = false, Detail = "An invigorating blend of turmeric, ginger, cinnamon, and other fragrant spices, this loose leaf blend draws from Ayurvedic principles to energize and awaken your mind and body--all without caffeine! This autumnal tisane brews to a beautiful copper hue and can be enjoyed at any time of day." },
                new Product { Id = 24, Name = "Egyptian Chamomile Tea", ImageUrl = "egyptianchamomiletea.jpg", CategoryId = 5, Price = 20, IsBestSelling = false, IsTrending = false, Detail = "Our Egyptian Chamomile elicits sweet, calming flavor notes. This tisane is round and soothing with each and every sip, perfect for any time of day." },
                new Product { Id = 25, Name = "Vanilla Berry Truffle Tea", ImageUrl = "vanillaberrytruffletea.jpg", CategoryId = 5, Price = 25, IsBestSelling = false, IsTrending = false, Detail = "This vanilla rooibos tea is a delectable infusion of enticingly sweet and tangy flavors harmoniously complimented by the soothing smoothness of fresh cream. Our Vanilla Berry Truffle tea is an enjoyable dessert blend at any time of day." },
                new Product { Id = 26, Name = "Lemon Meringue Tea", ImageUrl = "lemonmeringuetea.jpg", CategoryId = 5, Price = 21, IsBestSelling = false, IsTrending = true, Detail = "Our Lemon Meringue tea has a light, fluffy texture and a sweet, creamy finish. This rooibos based blend is a delight for any moments of sweet cravings throughout the day." }
    );
        }

    }

}
