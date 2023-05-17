using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context) 
        {
        }

        //public Task<string> SearchByText(string searchText)
        //{
        //    if (string.IsNullOrWhiteSpace(searchText))
        //    {
        //        throw new ArgumentNullException("Please,enter correct expression");
        //    }
        //}

       
    }
}

