using Shamsheer.Domain.Entities.Chats;
using Shamsheer.Domain.Enums.Chats;
using System.Collections.Generic;

namespace Shamsheer.Data.Seeds.Users;

public class UsersSeedData
{
    public static IEnumerable<User> GetMockData()
    {
        return new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Nozimjon",
                LastName = "Usmonaliyev",
                Email = "nozimjon04@gmail.com",
                Phone = "+998911670749",
                ChatType = ChatType.User,
                Username = "Usmonaliyev_0749",
            },
            new User
            {
                Id = 2,
                FirstName = "Jasurbek",
                LastName = "Abdunazarov",
                Email = "jasurbekabdunazarov293@gmail.com",
                Phone = "+998939161531",
                ChatType = ChatType.User,
                Username = "dotnetbro",
            },
            new User
            {
                Id = 3,
                FirstName = "Avazbek",
                LastName = "Abdumajidov",
                Email = "abdumajidova51@gmail.com",
                Phone = "+998999093357",
                ChatType = ChatType.User,
                Username = "Abdumajidov_0909",
            },
            new User
            {
                Id = 4,
                FirstName = "Dilshod",
                LastName = "Ismoilov",
                Email = "dilshod123@gmail.com",
                Phone = "+998977236481",
                ChatType = ChatType.User,
                Username = "dilshodismail",
            },
            new User
            {
                Id = 5,
                FirstName = "Feruza",
                LastName = "Xalilova",
                Email = "feruza.xalil@gmail.com",
                Phone = "+998954721367",
                ChatType = ChatType.User,
                Username = "feruzaxali",
            },
            new User
            {
                Id = 6,
                FirstName = "Shavkat",
                LastName = "Ergashev",
                Email = "shavkat_ergashev@gmail.com",
                Phone = "+998941236589",
                ChatType = ChatType.User,
                Username = "shavkat88",
            },
            new User
            {
                Id = 7,
                FirstName = "Mavluda",
                LastName = "Jamolova",
                Email = "mavluda.jamol@gmail.com",
                Phone = "+998973456782",
                ChatType = ChatType.User,
                Username = "mavluda101",
            },
            new User
            {
                Id = 8,
                FirstName = "Azamat",
                LastName = "Rahmonov",
                Email = "azamat.r@gmail.com",
                Phone = "+998992367159",
                ChatType = ChatType.User,
                Username = "azamat7",
            },
            new User
            {
                Id = 9,
                FirstName = "Nargiza",
                LastName = "Sobirova",
                Email = "nargiza.sobirov@gmail.com",
                Phone = "+998958723164",
                ChatType = ChatType.User,
                Username = "nargizasob",
            },
            new User
            {
                Id = 10,
                FirstName = "Farrukh",
                LastName = "Tashpulatov",
                Email = "farrukh_t@gmail.com",
                Phone = "+998914569823",
                ChatType = ChatType.User,
                Username = "farrukhtash",
            }
        };
    }
}
