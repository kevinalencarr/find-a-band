using FindABand.Data.Enums;
using FindABand.Models;

namespace FindABand.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Bands.Any())
                {
                    context.Bands.AddRange(new List<Band>()
                    {
                        new Band()
                        {
                            Name = "Metallica",
                            Bio = "Fathers of Thrash Metal. Need to say more?",
                            Image = "https://i0.wp.com/guitarload.com.br/wp-content/uploads/2021/09/metallica-tributo-black-album.jpg?fit=1200%2C628&ssl=1",
                            BandGenre = BandGenre.HeavyMetal,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "San Francisco",
                                State = "CA"
                            }
                        },
                        new Band()
                        {
                            Name = "Rammstein",
                            Bio = "Best band in the world and also in Germany.",
                            Image = "https://static.dw.com/image/48777860_605.jpg",
                            BandGenre = BandGenre.HeavyMetal,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Berlin",
                                State = "BE"
                            }
                        },
                        new Band()
                        {
                            Name = "My Chemical Romance",
                            Bio = "We are back from the dead, but still as deadly.",
                            Image = "https://mtv.mtvnimages.com/uri/mgid:ao:image:mtv.com:701868?quality=0.8&format=jpg&width=1440&height=810&.jpg",
                            BandGenre = BandGenre.Rock,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Newark",
                                State = "NJ"
                            }
                        },
                        new Band()
                        {
                            Name = "Bring Me the Horizon",
                            Bio = "The best brazilian band not from Brazil",
                            Image = "https://i0.wp.com/www.wikimetal.com.br/wp-content/uploads/2022/07/BringMeTheHorizon.jpg?resize=1170%2C658&ssl=1",
                            BandGenre = BandGenre.Rock,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Sheffield",
                                State = "SY"
                            }
                        }
                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.Ads.Any())
                {
                    context.Ads.AddRange(new List<Ad>()
                    {
                        new Ad()
                        {
                            Title = "Metal band looking for guitarist",
                            Description = "Lost our guitarist recently to the Upside Down. Need a new one.",
                            Image = "https://i0.wp.com/guitarload.com.br/wp-content/uploads/2021/09/metallica-tributo-black-album.jpg?fit=1200%2C628&ssl=1",
                            AdCategory = AdCategory.FixedMember,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        },
                        new Ad()
                        {
                            Title = "Bring Me the Horizon",
                            Description = "We need more brazilians to our Brazil-based band",
                            Image = "https://i0.wp.com/www.wikimetal.com.br/wp-content/uploads/2022/07/BringMeTheHorizon.jpg?resize=1170%2C658&ssl=1",
                            AdCategory = AdCategory.FixedMember,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //        string adminUserEmail = "teddysmithdeveloper@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                UserName = "teddysmithdev",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}
