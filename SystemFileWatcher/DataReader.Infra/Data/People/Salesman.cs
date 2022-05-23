using DataReader.Infra.Data.Sell;

namespace DataReader.Infra.Data.People
{
    public class Salesman
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public List<Sale> Sales { get; set; }

        public Salesman(string cpf, string name, double salary)
        {
            Cpf = cpf;
            Name = name;
            Salary = salary;
            Sales = new List<Sale>();
        }
    }
}
