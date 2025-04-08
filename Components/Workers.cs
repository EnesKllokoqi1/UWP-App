using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class Workers
    {
        public ObservableCollection<WorkersViewModel> GetWorkers()
        {
            var workers = new ObservableCollection<WorkersViewModel>();
            workers.Add(new WorkersViewModel
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Gender = 'M',
                AnnualSalary = 55000,
                IsManager = true
            });

            workers.Add(new WorkersViewModel
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Gender = 'F',
                AnnualSalary = 48000,
                IsManager = false
            });

            workers.Add(new WorkersViewModel
            {
                Id = 3,
                FirstName = "Alice",
                LastName = "Brown",
                Gender = 'F',
                AnnualSalary = 62000,
                IsManager = true
            });

            workers.Add(new WorkersViewModel
            {
                Id = 4,
                FirstName = "Bob",
                LastName = "Johnson",
                Gender = 'M',
                AnnualSalary = 43000,
                IsManager = false
            });
            workers.Add(new WorkersViewModel
            {
                Id = 5,
                FirstName = "Charlie",
                LastName = "Davis",
                Gender = 'M',
                AnnualSalary = 52000,
                IsManager = false
            });

            workers.Add(new WorkersViewModel
            {
                Id = 6,
                FirstName = "Eve",
                LastName = "Wilson",
                Gender = 'F',
                AnnualSalary = 47000,
                IsManager = true
            });
            return workers;
        }
    }
}
