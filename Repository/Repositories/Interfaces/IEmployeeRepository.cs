using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        //Task<string> SearchByText(string searchText);
        Task SoftDeleteAsync(int? id);
    }
}
