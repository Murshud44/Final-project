using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp63;

    public class Company
    {
        private static int lastId = 0;

        public int Id { get; }
        public string Name { get; set; }

        private List<Department> departments = new List<Department>();

        public Company(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name must be provided for creating a company.");
            }

            this.Id = Interlocked.Increment(ref lastId);
            this.Name = name;
        }

        public List<Department> GetAll;
};
