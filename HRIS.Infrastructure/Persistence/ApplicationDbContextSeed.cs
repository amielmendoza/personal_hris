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
        //                    var employmentStatus = context.EmploymentStatuses.FirstOrDefault();

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
        //                        EmploymentStatusId = employmentStatus.Id
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
        //public static async Task SeedReferenceDataAsync(ApplicationDbContext context)
        //{
        //    context.Database.EnsureCreated();

        //    if (
        //        context.EmploymentStatuses.Any() &&
        //        context.EmployeeLeaveStatuses.Any() &&
        //        context.EmployeeLeaveTypes.Any() &&
        //        context.EmployeeLoanStatuses.Any() &&
        //        context.EmployeeLoanTypes.Any() &&
        //        context.Sites.Any() &&
        //        context.Departments.Any()
        //        )
        //        return;

        //    if (!context.EmploymentStatuses.Any())
        //    {
        //        await SeedEmployeeStatus(context);
        //    }

        //    if (!context.EmployeeLeaveStatuses.Any())
        //    {
        //        await SeedLeaveStatuses(context);
        //    }

        //    if (!context.EmployeeLeaveTypes.Any())
        //    {
        //        await SeedLeaveTypes(context);
        //    }

        //    if (!context.EmployeeLoanTypes.Any())
        //    {
        //        await SeedLoanTypes(context);
        //    }

        //    if (!context.EmployeeLoanStatuses.Any())
        //    {
        //        await SeedLoanStatuses(context);
        //    }

        //    if (!context.Sites.Any())
        //    {
        //        await SeedSites(context);
        //    }

        //    //if (!context.Departments.Any())
        //    //{
        //    //    await SeedDepartments(context);
        //    //}

        //    using (context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            await context.SaveChangesAsync().ConfigureAwait(false);
        //            context.Database.CommitTransaction();
        //        }
        //        catch (Exception)
        //        {
        //            context.Database.RollbackTransaction();
        //        }
        //    }
        //}
        //private static async Task SeedSites(ApplicationDbContext context)
        //{
        //    if (!context.Sites.Any())
        //    {
        //        var list = new[]
        //        {
        //            new Site { Name = "Bacolod" },
        //            new Site { Name = "Legazpi" },
        //            new Site { Name = "Ormoc" },
        //            new Site { Name = "Bauang" },
        //            new Site { Name = "Poro" },
        //            new Site { Name = "Tagbilaran" },
        //            new Site { Name = "Roxas" },
        //            new Site { Name = "Jimenez" },
        //            new Site { Name = "Navotas" },
        //            new Site { Name = "Rosario" },
        //            new Site { Name = "Rosario Subcon Rios" },
        //            new Site { Name = "Rosario Subcon Tagle" },
        //            new Site { Name = "Imus Office" },
        //            new Site { Name = "Imus Fabrication" },
        //        }.OrderBy(x=>x.Name);

        //        await context.Sites.AddRangeAsync(list);
        //        await SeedDepartments(context, list);
        //    }
        //}

        //private static async Task SeedDepartments(ApplicationDbContext context, IEnumerable<Site> sites)
        //{
        //    if (!context.Departments.Any())
        //    {
        //        var jimenezSite = sites.FirstOrDefault(x => x.Name == "Jimenez").Id;
        //        var navotasSite = sites.FirstOrDefault(x => x.Name == "Navotas").Id;
        //        var tagbilaranSite = sites.FirstOrDefault(x => x.Name == "Tagbilaran").Id;
        //        var roxasSite = sites.FirstOrDefault(x => x.Name == "Roxas").Id;
        //        var ormocSite = sites.FirstOrDefault(x => x.Name == "Ormoc").Id;
        //        var legazpiSite = sites.FirstOrDefault(x => x.Name == "Legazpi").Id;
        //        var poroSite = sites.FirstOrDefault(x => x.Name == "Poro").Id;
        //        var rosarioSite = sites.FirstOrDefault(x => x.Name == "Rosario").Id;
        //        var bauangSite = sites.FirstOrDefault(x => x.Name == "Bauang").Id;
        //        var imusFabricationSite = sites.FirstOrDefault(x => x.Name == "Imus Fabrication").Id;
        //        var imusOfficeSite = sites.FirstOrDefault(x => x.Name == "Imus Office").Id;

        //        var list = new[]
        //        {
        //            // Jimenez
        //            new Department { Name = "GBM", SiteId = jimenezSite },
        //            new Department { Name = "PM", SiteId = jimenezSite },
        //            new Department { Name = "TRA", SiteId = jimenezSite },
        //            new Department { Name = "ETHANOL", SiteId = jimenezSite },
        //            new Department { Name = "WAREHOUSE", SiteId = jimenezSite },
        //            new Department { Name = "WORK ORDER", SiteId = jimenezSite },
        //            new Department { Name = "BIG PROJECT", SiteId = jimenezSite },

        //            // Navotas
        //            new Department { Name = "PM", SiteId = navotasSite },
        //            new Department { Name = "GBM", SiteId = navotasSite },
        //            new Department { Name = "TRA", SiteId = navotasSite },
        //            new Department { Name = "WORK ORDER", SiteId = navotasSite },
        //            new Department { Name = "BIG PROJECT", SiteId = navotasSite },

        //            // Tagbilaran
        //            new Department { Name = "GBM", SiteId = tagbilaranSite },

        //            // Roxas
        //            new Department { Name = "GBM", SiteId = roxasSite },
        //            new Department { Name = "TRA", SiteId = roxasSite },
        //            new Department { Name = "ETHANOL", SiteId = roxasSite },
        //            new Department { Name = "MOORING", SiteId = roxasSite },
        //            new Department { Name = "WORK ORDER", SiteId = roxasSite },
        //            new Department { Name = "BIG PROJECT", SiteId = roxasSite },

        //            // Ormoc
        //            new Department { Name = "GBM", SiteId = ormocSite },
        //            new Department { Name = "PM", SiteId = ormocSite },
        //            new Department { Name = "TRA", SiteId = ormocSite },
        //            new Department { Name = "WAREHOUSE", SiteId = ormocSite },
        //            new Department { Name = "LPG", SiteId = ormocSite },
        //            new Department { Name = "TTLR, TTIP, Ethanol Receiving, Additive & Tank Gauging Asst.", SiteId = ormocSite },
        //            new Department { Name = "WORK ORDER", SiteId = ormocSite },
        //            new Department { Name = "BIG PROJECT", SiteId = ormocSite },

        //            // Legazpi
        //            new Department { Name = "GBM", SiteId = legazpiSite },
        //            new Department { Name = "PM", SiteId = legazpiSite },
        //            new Department { Name = "LPG", SiteId = legazpiSite },
        //            new Department { Name = "WORK ORDER", SiteId = legazpiSite },
        //            new Department { Name = "BIG PROJECT", SiteId = legazpiSite },

        //            // Poro
        //            new Department { Name = "GBM", SiteId = poroSite },
        //            new Department { Name = "PM", SiteId = poroSite },
        //            new Department { Name = "LPG", SiteId = poroSite },
        //            new Department { Name = "TRA", SiteId = poroSite },
        //            new Department { Name = "WORK ORDER", SiteId = poroSite },
        //            new Department { Name = "BIG PROJECT", SiteId = poroSite },

        //            // Rosario 
        //            new Department { Name = "GBM", SiteId = rosarioSite },
        //            new Department { Name = "PM", SiteId = rosarioSite },
        //            new Department { Name = "LPG", SiteId = rosarioSite },
        //            new Department { Name = "TRA", SiteId = rosarioSite },
        //            new Department { Name = "ADMIN", SiteId = rosarioSite },
        //            new Department { Name = "CLINIC", SiteId = rosarioSite },
        //            new Department { Name = "FIESSTA", SiteId = rosarioSite },
        //            new Department { Name = "WORK ORDER", SiteId = rosarioSite },
        //            new Department { Name = "SUBCON PROJECT", SiteId = rosarioSite },

        //            // Bauang
        //            new Department { Name = "COMMERCIAL BUILDING", SiteId = bauangSite },
        //            new Department { Name = "RESORT", SiteId = bauangSite },

        //            // Imus Fabrication
        //            new Department { Name = "with deduction", SiteId = imusFabricationSite },
        //            new Department { Name = "without deduction", SiteId = imusFabricationSite },

        //            // Imus Office
        //            new Department { Name = "General Manager", SiteId = imusOfficeSite },
        //            new Department { Name = "Dela Cruz", SiteId = imusOfficeSite },
        //            new Department { Name = "Supervisor", SiteId = imusOfficeSite },
        //            new Department { Name = "OJT", SiteId = imusOfficeSite },
        //            new Department { Name = "Part-time", SiteId = imusOfficeSite },
        //            new Department { Name = "HR", SiteId = imusOfficeSite },
        //            new Department { Name = "Admin and Engineering", SiteId = imusOfficeSite },
        //        };

        //        await context.Departments.AddRangeAsync(list);
        //    }
        //}
        //private static async Task SeedEmployeeStatus(ApplicationDbContext context)
        //{
        //    if (!context.EmploymentStatuses.Any())
        //    {
        //        var list = new[]
        //        {

        //            new EmploymentStatus { Code = "R", Name = "Regular", Description = "Regular" },
        //            new EmploymentStatus { Code = "RE", Name = "Reliever", Description = "Reliever" },
        //            new EmploymentStatus { Code = "C", Name = "Contractual", Description = "Contractual" },
        //            new EmploymentStatus { Code = "PB", Name = "Project Based", Description = "Project Based" },
        //            new EmploymentStatus { Code = "P", Name = "Probationary", Description = "Probationary" },
        //            new EmploymentStatus { Code = "AL", Name = "Apprentice", Description = "Apprentice" },
        //            new EmploymentStatus { Code = "T", Name = "Terminated", Description = "Terminated" },
        //            new EmploymentStatus { Code = "RS", Name = "Resigned", Description = "Resigned" },
        //            new EmploymentStatus { Code = "RT", Name = "Retired", Description = "Retired" },
        //            new EmploymentStatus { Code = "D", Name = "Deceased", Description = "Deceased" },
        //            new EmploymentStatus { Code = "A", Name = "AWOL", Description = "AWOL" }
        //        };

        //        await context.EmploymentStatuses.AddRangeAsync(list);
        //    }
        //}
        //private static async Task SeedContractEndReasons(ApplicationDbContext context)
        //{
        //    if (!context.ContractEndReasons.Any())
        //    {
        //        var list = new[]
        //        {
        //            new ContractEndReason { Code = "T", Name = "Terminated", Description = "Terminated" },
        //            new ContractEndReason { Code = "RE", Name = "Resigned", Description = "Resigned" },
        //            new ContractEndReason { Code = "TR", Name = "Transferred", Description = "Transferred" },
        //            new ContractEndReason { Code = "R", Name = "Retirement", Description = "Retirement" },
        //            new ContractEndReason { Code = "D", Name = "Death", Description = "Death" }
        //        };

        //        await context.ContractEndReasons.AddRangeAsync(list);
        //    }
        //}

        //private static async Task SeedLeaveTypes(ApplicationDbContext context)
        //{
        //    if (!context.EmployeeLeaveTypes.Any())
        //    {
        //        var list = new[]
        //        {
        //            new EmployeeLeaveType { Code = "VL", Name = "Vacation Leave", Description = "Vacation Leave" },
        //            new EmployeeLeaveType { Code = "SL", Name = "Sick Leave", Description = "Sick Leave" },
        //            new EmployeeLeaveType { Code = "ML", Name = "Maternity Leave", Description = "Maternity Leave" },
        //            new EmployeeLeaveType { Code = "PL", Name = "Paternity Leave", Description = "Paternity Leave" },
        //        };
        //        await context.EmployeeLeaveTypes.AddRangeAsync(list);
        //    }
        //}


        //private static async Task SeedLoanTypes(ApplicationDbContext context)
        //{
        //    if (!context.EmployeeLoanTypes.Any())
        //    {
        //        var list = new[]
        //        {
        //            new EmployeeLoanType { Code = "SSL", Name = "SSS Salary Loan", Description = "SSS Salary Loan" },
        //            new EmployeeLoanType { Code = "SCL", Name = "SSS Calamity Loan", Description = "SSS Calamity Loan" },
        //            new EmployeeLoanType { Code = "PSL", Name = "Pag-IBIG Salary Loan", Description = "Pag-IBIG Salary Loan" },
        //            new EmployeeLoanType { Code = "PCL", Name = "Pag-IBIG Calamity Loan", Description = "Pag-IBIG Calamity Loan" },
        //        };
        //        await context.EmployeeLoanTypes.AddRangeAsync(list);
        //    }
        //}

        //private static async Task SeedLeaveStatuses(ApplicationDbContext context)
        //{
        //    if (!context.EmployeeLeaveStatuses.Any())
        //    {
        //        var list = new[]
        //        {
        //            new EmployeeLeaveStatus { Code = "N", Name = "New", Description = "New" },
        //            new EmployeeLeaveStatus { Code = "A", Name = "Approved", Description = "Approved" },
        //            new EmployeeLeaveStatus { Code = "D", Name = "Denied", Description = "Denied" }
        //        };
        //        await context.EmployeeLeaveStatuses.AddRangeAsync(list);
        //    }
        //}

        //private static async Task SeedLoanStatuses(ApplicationDbContext context)
        //{
        //    if (!context.EmployeeLoanStatuses.Any())
        //    {
        //        var list = new[]
        //        {
        //            new EmployeeLoanStatus { Code = "I", Name = "Inactive", Description = "Inactive" },
        //            new EmployeeLoanStatus { Code = "A", Name = "Active", Description = "Active" },
        //            new EmployeeLoanStatus { Code = "D", Name = "Done", Description = "Done" }
        //        };
        //        await context.EmployeeLoanStatuses.AddRangeAsync(list);
        //    }
        //}
    }
}
