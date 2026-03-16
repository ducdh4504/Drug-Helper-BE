using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Seeding
{
    public static class SeedingUser
    {
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                // Admin user
                new User
                {
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    UserName = "admin",
                    // password đã hash cho password: "123456"
                    Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u",
                    Email = "admin@example.com",
                    FullName = "Administrator",
                    Role = RoleEnum.Admin,
                    Status = ActivityStatusEnum.Active
                },

                  // Staff user
                  new User
                  {
                      UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                      UserName = "LyPhongstaff",
                      // password đã hash cho password: "123456"
                      Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u",
                      Email = "lyphongstaff@example.com",
                      FullName = "Ly Tuan Phong",
                      Role = RoleEnum.Staff,
                      Status = ActivityStatusEnum.Active
                  },
                  new User
                  {
                      UserID = Guid.Parse("00000000-0000-0000-0000-000000000112"),
                      UserName = "GoothStaff",
                      // password đã hash cho password: "123456"
                      Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u",
                      Email = "goothstaff@example.com",
                      FullName = "Gooth Yunoly",
                      Role = RoleEnum.Staff,
                      Status = ActivityStatusEnum.Active
                  },

                  // Manager user
                  new User
                  {
                      UserID = Guid.Parse("00000000-0000-0000-0000-200000000222"),
                      UserName = "HoKhaManager",
                      // password đã hash cho password: "123456"
                      Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u",
                      Email = "khahomanager@example.com",
                      FullName = "Ho Kha",
                      Role = RoleEnum.Manager,
                      Status = ActivityStatusEnum.Active
                  },

                // Consultant users
                new User
                {
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    UserName = "NhatNguyen",
                    Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", // "123456"
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/consultantImage%2Fconsultant1.png?alt=media&token=d2177c39-baa2-415b-9e2a-02c1e7ad0386",
                    Email = "nhatbn1@example.com",
                    FullName = "Nguyen Ba Nhat",
                    Role = RoleEnum.Consultant,
                    Status = ActivityStatusEnum.Active,
                    Phone = "0901001001",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Address = "123 Nguyen Trai, Ha Noi"
                },
                new User
                {
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    UserName = "JoinPotter",
                    Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", // "123456"
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/consultantImage%2Fconsultant2.png?alt=media&token=389c0581-31f9-4cea-8e67-b8c552dfd492",
                    Email = "joinp2@example.com",
                    FullName = "John Potter",
                    Role = RoleEnum.Consultant,
                    Status = ActivityStatusEnum.Active,
                    Phone = "0901000232",
                    DateOfBirth = new DateTime(1988, 2, 2),
                    Address = "456 Le Loi, Da Nang"
                },
                new User
                {
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    UserName = "MaryJarry",
                    Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", // "123456"
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/consultantImage%2Fconsultant3.png?alt=media&token=eb17235b-0ccc-441a-8f13-52d91cdf6463",
                    Email = "maryj3@example.com",
                    FullName = "Mary Jarry",
                    Role = RoleEnum.Consultant,
                    Status = ActivityStatusEnum.Active,
                    Phone = "0901708003",
                    DateOfBirth = new DateTime(1992, 3, 3),
                    Address = "789 Tran Phu, Ho Chi Minh"
                },
                new User
                {
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    UserName = "LeeSanghyeok",
                    Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", // "123456"
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/consultantImage%2Fconsutant4.png?alt=media&token=54968421-4493-4d2c-9df3-1ee0ef4bc6fe",
                    Email = "sanghl4@example.com",
                    FullName = "Lee Sang-hyeok",
                    Role = RoleEnum.Consultant,
                    Status = ActivityStatusEnum.Active,
                    Phone = "0901984564",
                    DateOfBirth = new DateTime(1991, 4, 4),
                    Address = "101 Nguyen Hue, Hue"
                },
                new User
                {
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    UserName = "VyLe",
                    Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", // "123456"
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/consultantImage%2Fconsultant5.png?alt=media&token=35292f58-6cf4-4d3f-b099-8b2e550d6811",
                    Email = "vylt5@example.com",
                    FullName = "Le Tuong Vy",
                    Role = RoleEnum.Consultant,
                    Status = ActivityStatusEnum.Active,
                    Phone = "0901003005",
                    DateOfBirth = new DateTime(1993, 5, 5),
                    Address = "202 Vo Thi Sau, Vung Tau"
                },
                new User
                {
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                    UserName = "Khayeudo",
                    Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", // "123456"
                    Email = "vykhat5@example.com",
                    FullName = "Le Vy Kha",
                    Role = RoleEnum.Member,
                    Status = ActivityStatusEnum.Active,
                    Phone = "0901693005",
                    DateOfBirth = new DateTime(1969, 10, 30),
                    Address = "252 Vo Thi Sau, Go Vap, Ho Chi Minh"
                },
                new User
                {
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                    UserName = "KhongTaiDau",
                    Password = "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", // "123456"
                    Email = "taikdau9@example.com",
                    FullName = "Khong Tai Dau",
                    Role = RoleEnum.Member,
                    Status = ActivityStatusEnum.Active,
                    Phone = "0110693005",
                    DateOfBirth = new DateTime(2000, 10, 20),
                    Address = "250 Vo Thi Sau, Con Dao"
                }
            );
        }
    }
}
