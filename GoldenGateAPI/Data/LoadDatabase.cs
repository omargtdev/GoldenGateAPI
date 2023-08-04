using GoldenGateAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace GoldenGateAPI.Data;

public class LoadDatabase
{

    public static async Task FirstInsertData(AppDbContext context, UserManager<User> userManager) 
    {

        Task? userCreation = null;
        Task? propertiesCreation = null;

        if(!userManager.Users.Any())
        {
            var user = new User {
                Name = "Omar",
                LastName = "Gutierrez",
                Email = "omargtdev@gmail.com",
                UserName = "omargtdev",
                PhoneNumber = "987654321"
            };

            userCreation = userManager.CreateAsync(user, "Passw0rd$123");
        }

        if(!context.Properties.Any())
        {
            propertiesCreation = context.Properties.AddRangeAsync(
                new Property {
                    Name = "Casa de Playa",
                    Direction = "Av. El sol 123",
                    Price = 45000.50m
                },
                new Property {
                    Name = "Casa de Campo",
                    Direction = "Av. La Luna 152",
                    Price = 35000.50m
                },
                new Property {
                    Name = "Casa de Invierno",
                    Direction = "Av. La roca 321",
                    Price = 20000.50m
                },
                new Property {
                    Name = "Casa Rustica",
                    Direction = "Av. Los pitucos 023",
                    Price = 60500.50m
                },
                new Property {
                    Name = "Casa de los Simpson",
                    Direction = "Av. Siempre Viva 123",
                    Price = 142000m
                },
                new Property {
                    Name = "Casa de Omar",
                    Direction = "Av. Some street 123",
                    Price = 1000m
                }
            );

        }

        if(userCreation is not null)
            await userCreation; 

        if(propertiesCreation is not null)
            await propertiesCreation;

        context.SaveChanges();
    }

}
