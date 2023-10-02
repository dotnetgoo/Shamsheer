using Shamsheer.Data.DbContexts;
using Shamsheer.Domain.Entities;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)   
    {
        var dbContext = new ShamsheerDbContext();

        await dbContext.Users.AddAsync(new User
        {
            FirstName = "TeASDASDst",
            LastName = "TestFSDFSDF",
            Phone = "+998936900723",
            Password = "PasswordFD",
        });
        await dbContext.SaveChangesAsync();

        //foreach (var user in users)
        //{
        //    Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName);
        //}
    }
}