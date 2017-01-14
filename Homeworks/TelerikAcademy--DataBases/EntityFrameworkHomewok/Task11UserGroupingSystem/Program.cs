using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDBContext;

namespace Task11UserGroupingSystem
{
    internal class Program
    {
        private static void CreateUserWithGroup(UserGropingSystemDB db, string groupName)
        {
            var CustomGroup = db.Groups.FirstOrDefault(g => g.Name == groupName);
            if (CustomGroup == null)
            {
                CustomGroup = new Group()
                {
                    Name = groupName
                };
            }
            var user = new User()
            {
                Name = "NewUser",
                Group = CustomGroup
            };
            db.Users.Add(user);
            db.SaveChanges();
        }

        private static void Main(string[] args)
        {
            UserGropingSystemDB db = new UserGropingSystemDB();

            CreateUserWithGroup(db, "Admin");
        }
    }
}