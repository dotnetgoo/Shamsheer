using Microsoft.EntityFrameworkCore;
using Shamsheer.Data.DbContexts;
using Shamsheer.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)   
    {
        var dbContext = new ShamsheerDbContext();

        await dbContext.Users.AddAsync(new User
        {
            FirstName = "Mukhammadkarim",
            LastName = "fwef",
            Email = "toxa@gmail.com",
            Username = "dotnetgo",
            Password = "12345",
            Phone = "123456789"
        });

        await dbContext.SaveChangesAsync();

        foreach (var user in dbContext.Users)
        {
            Console.WriteLine(user.Id);
        }

        Console.ReadLine();

        //var message = await dbContext.Messages
        //    .Include(m => m.To)
        //    .ThenInclude(u => u.Assets)
        //    .Include(m => m.From)
        //    .ThenInclude(u => u.Assets)
        //    .Include(m => m.Content)
        //    .Include(m => m.Parent)
        //    .ThenInclude(pm => pm.Content)
        //    .OrderBy(m => m.Id)
        //    .FirstOrDefaultAsync();
        //if(message != null)
        //{
        //    Console.WriteLine($"Message: {message.Content.Text}");
        //    Console.WriteLine($"From: {message.From.FirstName}");
        //    Console.WriteLine($"To: {message.To.FirstName}");
        //    Console.WriteLine($"Parent: {message.Parent?.Content.Text}");
        //}
    }
}