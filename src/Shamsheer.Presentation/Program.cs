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

        var message = await dbContext.Messages
            .Include(m => m.To)
            .ThenInclude(u => u.Assets)
            .Include(m => m.From)
            .ThenInclude(u => u.Assets)
            .Include(m => m.Content)
            .FirstOrDefaultAsync();
        if(message != null)
        {
            Console.WriteLine(message.From.FirstName + " dan " + message.To.FirstName + " ga habar: \n" + message.Content.Text);
            foreach (var asset in message.To.Assets)
            {
                Console.WriteLine(asset.Extension + " " + asset.Size);
            }
        }
    }
}