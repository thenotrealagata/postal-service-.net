using Microsoft.EntityFrameworkCore;
using PostalService.Model;

namespace PostalService
{
    public class DbInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.Migrate();

            // Check if any movies already exist
            if (context.Parcels.Any())
            {
                return;
            }

            List<User> users = [
                new User {
                    Email = "user1@example.com"
                },
                new User {
                    Email = "user2@example.com"
                }
                ];
            context.Users.AddRange(users);

            List<Location> locations = [
                new Location { 
                    Address = "New Street 12.",
                    Capacity = 10,
                    LocationType = LocationType.Automate
                },
                new Location {
                    Address = "City Mall floor 2",
                    Capacity = 0,
                    LocationType = LocationType.Automate
                },
                new Location {
                    Address = "Warehouse Street 1.",
                    Capacity = 500,
                    LocationType = LocationType.Warehouse
                }
            ];
            context.Locations.AddRange(locations);

            List<Parcel> parcels = [
                // Not placed yet
                new Parcel {
                    CreatedAt = DateTime.Now,
                    Size = ParcelSize.M,
                    SenderEmail = users[0].Email,
                    ReceiverEmail = "user2@example.com",
                },
                // Placed but not arrived
                new Parcel {
                    CreatedAt = DateTime.Now.AddDays(-1),
                    Size = ParcelSize.M,
                    SenderEmail = users[1].Email,
                    ReceiverEmail = "user1@example.com"
                },
                // Fulfilled
                new Parcel {
                    CreatedAt = DateTime.Now.AddDays(-50),
                    PlacedAt = DateTime.Now.AddDays(-49),
                    ArrivedAt = DateTime.Now.AddDays(-45),
                    IsFulfilled = true,
                    Size = ParcelSize.S,
                    SenderEmail = users[1].Email,
                    ReceiverEmail = "user1@example.com",

                }
            ];

            
            context.SaveChanges();
        }
    }
}
