using API.Data.Converters;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) //skip if user table not empty
                return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            options.Converters.Add(new JsonDateTimeConverter("yyyy-MM-dd"));
            options.Converters.Add(new DateOnlyJsonConverter());
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData,options);

            foreach ( var user in users )
            {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}
