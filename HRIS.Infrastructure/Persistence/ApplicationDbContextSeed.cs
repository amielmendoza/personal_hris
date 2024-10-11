using HRIS.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace HRIS.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        //public static async Task SeedSampleDataAsync(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        //{
        //    // Seed, if necessary
        //    if (!context.Employees.Any())
        //    {
        //        using (context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                for (int i = 0; i < 100; i++)
        //                {
        //                    var EmployeeStatus = context.EmployeeStatuses.FirstOrDefault();

        //                    var empUser = new ApplicationUser { UserName = $"emp000@rgc{i}", Email = $"emp000@rgc{i}" };
        //                    if (userManager.Users.All(u => u.UserName != empUser.UserName))
        //                    {
        //                        await userManager.CreateAsync(empUser, "password1");
        //                        await userManager.AddToRolesAsync(empUser, new[] { "Employee" });
        //                    }

        //                    var juan = await userManager.FindByNameAsync($"emp000@rgc{i}");

        //                    var person = new Person
        //                    {
        //                        FirstName = "Juan",
        //                        MiddleName = "Garcia",
        //                        LastName = "Dela Cruz",
        //                        MotherMaidenName = "Teresa Cruz",
        //                        Extension = "III",
        //                        Address = "Bacoor, Cavite",
        //                        ContactNo = "(632) 888 99 00",
        //                        Gender = GenderType.Male,
        //                        MaritalStatus = MaritalStatusType.Married,
        //                        EmergencyContact = "Petra Dela Cruz",
        //                        EmergencyContactNo = "(632) 888 99 00",
        //                        Password = "password1"
        //                    };

        //                    await context.People.AddAsync(person);

        //                    var employee = new Employee
        //                    {
        //                        UserId = Guid.Parse(juan.Id),
        //                        PersonId = person.Id,
        //                        EmployeeNo = "emp000",
        //                        HireDate = DateTime.UtcNow,
        //                        Position = "supervisor",
        //                        DailyRate = 1000,
        //                        MonthlyRate = 24000,
        //                        Allowance = 500,
        //                        Insurance = true,
        //                        BankAccountNumber = "012345",
        //                        BirthCertificate = "54321",
        //                        SSS = "12-345678-9",
        //                        TIN = "123-456-789",
        //                        NoOfDependents = 3,
        //                        Remarks = "ghost employee",
        //                        EmployeeStatusId = EmployeeStatus.Id
        //                    };

        //                    await context.Employees.AddAsync(employee);

        //                    var certifications = new List<EmployeeCertification>();
        //                    certifications.Add(new EmployeeCertification { EmployeeId = employee.Id, Name = "AWS Certification" });
        //                    certifications.Add(new EmployeeCertification { EmployeeId = employee.Id, Name = "Azure Certification" });

        //                    await context.EmployeeCertifications.AddRangeAsync(certifications);
        //                }
        //                await context.SaveChangesAsync().ConfigureAwait(false);
        //                context.Database.CommitTransaction();
        //            }
        //            catch (Exception)
        //            {
        //                context.Database.RollbackTransaction();
        //            }
        //        }
        //    }
        //}
        public static async Task SeedDefaultUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole(Roles.Administrator);
            var loanEmployeeRole = new IdentityRole(Roles.LoanEmployee);
            var siteManagerRole = new IdentityRole(Roles.SiteManager);
            var employeeRole = new IdentityRole(Roles.Employee);
            var payrollRole = new IdentityRole(Roles.PayrollEmployee);

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
                await roleManager.CreateAsync(administratorRole);

            if (roleManager.Roles.All(r => r.Name != siteManagerRole.Name))
                await roleManager.CreateAsync(siteManagerRole);

            if (roleManager.Roles.All(r => r.Name != employeeRole.Name))
                await roleManager.CreateAsync(employeeRole);

            if (roleManager.Roles.All(r => r.Name != loanEmployeeRole.Name))
                await roleManager.CreateAsync(loanEmployeeRole);

            if (roleManager.Roles.All(r => r.Name != payrollRole.Name))
                await roleManager.CreateAsync(payrollRole);

            var administrator = new IdentityUser { UserName = "admin@rgc.net", Email = "admin@rgc.net" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        public static async Task SeedReferenceDataAsync(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (
                context.EmployeeStatuses.Any() &&
                context.EmployeeLeaveStatuses.Any() &&
                context.EmployeeLeaveTypes.Any() &&
                context.EmployeeLoanStatuses.Any() &&
                context.EmployeeLoanTypes.Any() &&
                context.Sites.Any() &&
                context.Departments.Any() &&
                context.ContractEndReasons.Any()
                )
                return;

            if (!context.EmployeeStatuses.Any())
            {
                await SeedEmployeeStatus(context);
            }

            if (!context.EmployeeLeaveStatuses.Any())
            {
                await SeedLeaveStatuses(context);
            }

            if (!context.EmployeeLeaveTypes.Any())
            {
                await SeedLeaveTypes(context);
            }

            if (!context.EmployeeLoanTypes.Any())
            {
                await SeedLoanTypes(context);
            }

            if (!context.EmployeeLoanStatuses.Any())
            {
                await SeedLoanStatuses(context);
            }

            if (!context.ContractEndReasons.Any())
            {
                await SeedContractEndReasons(context);
            }

            if (!context.Sites.Any())
            {
                await SeedSites(context);
            }

            //if (!context.Departments.Any())
            //{
            //    await SeedDepartments(context);
            //}

            using (context.Database.BeginTransaction())
            {
                try
                {
                    await context.SaveChangesAsync().ConfigureAwait(false);
                    context.Database.CommitTransaction();
                }
                catch (Exception)
                {
                    context.Database.RollbackTransaction();
                }
            }
        }
        private static async Task SeedSites(ApplicationDbContext context)
        {
            if (!context.Sites.Any())
            {
                var list = new[]
                {
                    new Site(Guid.NewGuid(), "Bacolod", "BA", "Bacolod"),
                    new Site(Guid.NewGuid(), "Legazpi", "L", "Legazpi"),
                    new Site(Guid.NewGuid(), "Ormoc", "O", "Ormoc"),
                    new Site(Guid.NewGuid(), "Bauang", "BU", "Bauang"),
                    new Site(Guid.NewGuid(), "Poro", "P", "Poro"),
                    new Site(Guid.NewGuid(), "Tagbilaran", "T", "Tagbilaran"),
                    new Site(Guid.NewGuid(), "Roxas", "RX", "Roxas"),
                    new Site(Guid.NewGuid(), "Jimenez", "J", "Jimenez"),
                    new Site(Guid.NewGuid(), "Navotas", "N", "Navotas"),
                    new Site(Guid.NewGuid(), "Rosario", "RO", "Rosario"),
                    new Site(Guid.NewGuid(), "Rosario Subcon Rios", "RSR", "Rosario Subcon Rios"),
                    new Site(Guid.NewGuid(), "Rosario Subcon Tagle", "RST", "Rosario Subcon Tagle"),
                    new Site(Guid.NewGuid(), "Imus Office", "IO", "Imus Office"),
                    new Site(Guid.NewGuid(), "Imus Fabrication", "IF", "Imus Fabrication"),
                }.OrderBy(x => x.Name);

                await context.Sites.AddRangeAsync(list);
                await SeedDepartments(context, list);
            }
        }

        private static async Task SeedDepartments(ApplicationDbContext context, IEnumerable<Site> sites)
        {
            if (!context.Departments.Any())
            {
                var jimenezSite = sites.FirstOrDefault(x => x.Name == "Jimenez").Id;
                var navotasSite = sites.FirstOrDefault(x => x.Name == "Navotas").Id;
                var tagbilaranSite = sites.FirstOrDefault(x => x.Name == "Tagbilaran").Id;
                var roxasSite = sites.FirstOrDefault(x => x.Name == "Roxas").Id;
                var ormocSite = sites.FirstOrDefault(x => x.Name == "Ormoc").Id;
                var legazpiSite = sites.FirstOrDefault(x => x.Name == "Legazpi").Id;
                var poroSite = sites.FirstOrDefault(x => x.Name == "Poro").Id;
                var rosarioSite = sites.FirstOrDefault(x => x.Name == "Rosario").Id;
                var bauangSite = sites.FirstOrDefault(x => x.Name == "Bauang").Id;
                var imusFabricationSite = sites.FirstOrDefault(x => x.Name == "Imus Fabrication").Id;
                var imusOfficeSite = sites.FirstOrDefault(x => x.Name == "Imus Office").Id;

                var list = new[]
                {
                    // Jimenez
                    new Department(Guid.NewGuid(), "GBM", "G", "GBM", jimenezSite),
                    new Department(Guid.NewGuid(), "PM", "P", "PM", jimenezSite),
                    new Department(Guid.NewGuid(), "TRA", "T", "TRA", jimenezSite),
                    new Department(Guid.NewGuid(), "ETHANOL", "E", "ETHANOL", jimenezSite),
                    new Department(Guid.NewGuid(), "WAREHOUSE", "W", "WAREHOUSE", jimenezSite),
                    new Department(Guid.NewGuid(), "WORK ORDER", "WO", "WORK ORDER", jimenezSite),
                    new Department(Guid.NewGuid(), "BIG PROJECT", "BP", "BIG PROJECT", jimenezSite),

                    // Navotas
                    new Department(Guid.NewGuid(), "PM", "P", "PM", navotasSite),
                    new Department(Guid.NewGuid(), "GBM", "G", "GBM", navotasSite),
                    new Department(Guid.NewGuid(), "TRA", "T", "TRA", navotasSite),
                    new Department(Guid.NewGuid(), "WORK ORDER", "WO", "WORK ORDER", navotasSite),
                    new Department(Guid.NewGuid(), "BIG PROJECT", "BP", "BIG PROJECT", navotasSite),

                    // Tagbilaran
                    new Department(Guid.NewGuid(), "GBM", "G", "GBM", tagbilaranSite),

                    // Roxas
                    new Department(Guid.NewGuid(), "GBM", "G", "GBM", roxasSite),
                    new Department(Guid.NewGuid(), "TRA", "T", "TRA", roxasSite),
                    new Department(Guid.NewGuid(), "ETHANOL", "E", "ETHANOL", roxasSite),
                    new Department(Guid.NewGuid(), "MOORING", "M", "MOORING", roxasSite),
                    new Department(Guid.NewGuid(), "WORK ORDER", "WO", "WORK ORDER", roxasSite),
                    new Department(Guid.NewGuid(), "BIG PROJECT", "BP", "BIG PROJECT", roxasSite),

                    // Ormoc
                    new Department(Guid.NewGuid(), "GBM", "G", "GBM", ormocSite),
                    new Department(Guid.NewGuid(), "PM", "P", "PM", ormocSite),
                    new Department(Guid.NewGuid(), "TRA", "T", "TRA", ormocSite),
                    new Department(Guid.NewGuid(), "WAREHOUSE", "W", "WAREHOUSE", ormocSite),
                    new Department(Guid.NewGuid(), "LPG", "L", "LPG", ormocSite),
                    new Department(Guid.NewGuid(), "TTLR, TTIP, Ethanol Receiving, Additive & Tank Gauging Asst.", "TTERAT", "TTLR, TTIP, Ethanol Receiving, Additive & Tank Gauging Asst.", ormocSite),
                    new Department(Guid.NewGuid(), "WORK ORDER", "WO", "WORK ORDER", ormocSite),
                    new Department(Guid.NewGuid(), "PROJECT", "P", "PROJECT", ormocSite),

                    // Legazpi
                    new Department(Guid.NewGuid(), "GBM", "G", "GBM", legazpiSite),
                    new Department(Guid.NewGuid(), "PM", "P", "PM", legazpiSite),
                    new Department(Guid.NewGuid(), "LPG", "L", "LPG", legazpiSite),
                    new Department(Guid.NewGuid(), "WORK ORDER", "WO", "WORK ORDER", legazpiSite),
                    new Department(Guid.NewGuid(), "BIG PROJECT", "BP", "BIG PROJECT", legazpiSite),

                    // Poro
                    new Department(Guid.NewGuid(), "GBM", "G", "GBM", poroSite),
                    new Department(Guid.NewGuid(), "PM", "P", "PM", poroSite),
                    new Department(Guid.NewGuid(), "LPG", "L", "LPG", poroSite),
                    new Department(Guid.NewGuid(), "TRA", "T", "TRA", poroSite),
                    new Department(Guid.NewGuid(), "WORK ORDER", "WO", "WORK ORDER", poroSite),
                    new Department(Guid.NewGuid(), "BIG PROJECT", "BP", "BIG PROJECT", poroSite),

                    // Rosario 
                    new Department(Guid.NewGuid(), "GBM", "G", "GBM", rosarioSite),
                    new Department(Guid.NewGuid(), "PM", "P", "PM", rosarioSite),
                    new Department(Guid.NewGuid(), "LPG", "L", "LPG", rosarioSite),
                    new Department(Guid.NewGuid(), "TRA", "T", "TRA", rosarioSite),
                    new Department(Guid.NewGuid(), "ADMIN", "A", "ADMIN", rosarioSite),
                    new Department(Guid.NewGuid(), "CLINIC", "C", "CLINIC", rosarioSite),
                    new Department(Guid.NewGuid(), "FIESSTA", "F", "FIESSTA", rosarioSite),
                    new Department(Guid.NewGuid(), "WORK ORDER", "WO", "WORK ORDER", rosarioSite),
                    new Department(Guid.NewGuid(), "SUBCON PROJECT", "SP", "SUBCON PROJECT", rosarioSite),
                    

                    // Bauang
                    new Department(Guid.NewGuid(), "COMMERCIAL BUILDING", "CB", "COMMERCIAL BUILDING", bauangSite),
                    new Department(Guid.NewGuid(), "RESORT", "R", "RESORT", bauangSite),

                    // Imus Fabrication
                    new Department(Guid.NewGuid(), "with deduction", "WD", "with deduction", imusFabricationSite),
                    new Department(Guid.NewGuid(), "without deduction", "WOD", "without deduction", imusFabricationSite),

                    // Imus Office
                    new Department(Guid.NewGuid(), "General Manager", "GM", "General Manager", imusOfficeSite),
                    new Department(Guid.NewGuid(), "Dela Cruz", "DC", "Dela Cruz", imusOfficeSite),
                    new Department(Guid.NewGuid(), "Supervisor", "S", "Supervisor", imusOfficeSite),
                    new Department(Guid.NewGuid(), "OJT", "OJT", "OJT", imusOfficeSite),
                    new Department(Guid.NewGuid(), "Part-time", "PT", "Part-time", imusOfficeSite),
                    new Department(Guid.NewGuid(), "HR", "HR", "HR", imusOfficeSite),
                    new Department(Guid.NewGuid(), "Admin and Engineering", "AE", "Admin and Engineering", imusOfficeSite),
                };

                await context.Departments.AddRangeAsync(list);
            }
        }
        private static async Task SeedEmployeeStatus(ApplicationDbContext context)
        {
            if (!context.EmployeeStatuses.Any())
            {
                var list = new[]
                {
                    new EmployeeStatus(Guid.NewGuid(), "Regular", "R", "Regular"),
                    new EmployeeStatus(Guid.NewGuid(), "Reliever", "R", "Reliever"),
                    new EmployeeStatus(Guid.NewGuid(), "Contractual", "C", "Contractual"),
                    new EmployeeStatus(Guid.NewGuid(), "Project Based", "PB", "Project Based"),
                    new EmployeeStatus(Guid.NewGuid(), "Probationary", "P", "Probationary"),
                    new EmployeeStatus(Guid.NewGuid(), "Apprentice", "AL", "Apprentice"),
                    new EmployeeStatus(Guid.NewGuid(), "Terminated", "T", "Terminated"),
                    new EmployeeStatus(Guid.NewGuid(), "Resigned", "RS", "Resigned"),
                    new EmployeeStatus(Guid.NewGuid(), "Retired", "RT", "Retired"),
                    new EmployeeStatus(Guid.NewGuid(), "Deceased", "D", "Deceased"),
                    new EmployeeStatus(Guid.NewGuid(), "AWOL", "A", "AWOL")
                };

                await context.EmployeeStatuses.AddRangeAsync(list);
            }
        }
        private static async Task SeedContractEndReasons(ApplicationDbContext context)
        {
            if (!context.ContractEndReasons.Any())
            {
                var list = new[]
                {
                    new ContractEndReason(Guid.NewGuid(), "Terminated", "T", "Terminated"),
                    new ContractEndReason(Guid.NewGuid(), "Resigned", "RE", "Resigned"),
                    new ContractEndReason(Guid.NewGuid(), "Transferred", "TR", "Transferred"),
                    new ContractEndReason(Guid.NewGuid(), "Retirement", "R", "Retirement"),
                    new ContractEndReason(Guid.NewGuid(), "Death", "D", "Death")
                };

                await context.ContractEndReasons.AddRangeAsync(list);
            }
        }

        private static async Task SeedLeaveTypes(ApplicationDbContext context)
        {
            if (!context.EmployeeLeaveTypes.Any())
            {
                var list = new[]
                {
                    new EmployeeLeaveType(Guid.NewGuid(), "Vacation Leave", "VL", "Vacation Leave"),
                    new EmployeeLeaveType(Guid.NewGuid(), "Sick Leave", "SL", "Sick Leave"),
                    new EmployeeLeaveType(Guid.NewGuid(), "Maternity Leave", "ML", "Maternity Leave"),
                    new EmployeeLeaveType(Guid.NewGuid(), "Paternity Leave", "PL", "Paternity Leave"),
                };
                await context.EmployeeLeaveTypes.AddRangeAsync(list);
            }
        }


        private static async Task SeedLoanTypes(ApplicationDbContext context)
        {
            if (!context.EmployeeLoanTypes.Any())
            {
                var list = new[]
                {
                    new EmployeeLoanType(Guid.NewGuid(), "SSS Salary Loan", "SSL", "SSS Salary Loan"),
                    new EmployeeLoanType(Guid.NewGuid(), "SSS Calamity Loan", "SCL", "SSS Calamity Loan"),
                    new EmployeeLoanType(Guid.NewGuid(), "Pag-IBIG Salary Loan", "PSL", "Pag-IBIG Salary Loan"),
                    new EmployeeLoanType(Guid.NewGuid(), "Pag-IBIG Calamity Loan", "PCL", "Pag-IBIG Calamity Loan")
                };
                await context.EmployeeLoanTypes.AddRangeAsync(list);
            }
        }

        private static async Task SeedLeaveStatuses(ApplicationDbContext context)
        {
            if (!context.EmployeeLeaveStatuses.Any())
            {
                var list = new[]
                {
                    new EmployeeLeaveStatus(Guid.NewGuid(), "New", "N", "New"),
                    new EmployeeLeaveStatus(Guid.NewGuid(), "Approved", "A", "Approved"),
                    new EmployeeLeaveStatus(Guid.NewGuid(), "Denied", "D", "Denied")
                };
                await context.EmployeeLeaveStatuses.AddRangeAsync(list);
            }
        }

        private static async Task SeedLoanStatuses(ApplicationDbContext context)
        {
            if (!context.EmployeeLoanStatuses.Any())
            {
                var list = new[]
                {
                    new EmployeeLoanStatus(Guid.NewGuid(), "Inactive", "I", "Inactive"),
                    new EmployeeLoanStatus(Guid.NewGuid(), "Active", "A", "Active"),
                    new EmployeeLoanStatus(Guid.NewGuid(), "Done", "D", "Done")
                };
                await context.EmployeeLoanStatuses.AddRangeAsync(list);
            }
        }
    }
}
