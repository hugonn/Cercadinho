using DataReader.Core.Ports;
using DataReader.Infra.Data.People;
using DataReader.Infra.Data.Sell;
using DataReader.Infra.Storage.DataManager;

namespace DataReader.Infra.Storage
{
    public class FileAdapter : IFilePort
    {
        public string _homePath;
        private string _fileName;
        public Processor processor;

        public void Process(string homePath, string fileName)
        {
            processor = new Processor();
            _homePath = homePath; 
            _fileName = fileName;

            ProcessInFile();
            CreateOutDirectoryIfNotExists();
            CreateOutFile();
        }
        private void ProcessInFile()
        {
            var lines = File.ReadAllLines(_homePath + $@"\in\{_fileName}.dat");

            foreach (var line in lines)
                ProcessLine(line);
        }
        private void ProcessLine(string line)
        {
            var items = line.Split('ç');

            if (items[0].Equals("001"))
            {
                var seller = new Salesman
                (
                    items[1],
                    items[2],
                    Convert.ToDouble(items[3])
                );

                processor.ListManager.Salesmen.Add(seller);
            }

            if (items[0].Equals("002"))
            {
                var client = new Client
                (
                    items[1],
                    items[2],
                    items[3]
                );

                processor.ListManager.Clients.Add(client);
            }

            if (items[0].Equals("003"))
            {
                var sellItems = items[2].Substring(1, items[2].Length - 2);
                var processedItems = processor.ProcessItems(sellItems);

                var sale = new Sale
                            (
                                Convert.ToInt32(items[1]),
                                processedItems,
                                items[3]
                            );

                var salesman = processor.ListManager.Salesmen.FirstOrDefault(x => x.Name.Equals(items[3]));
                salesman.Sales.Add(sale);
            }
        }
        private void CreateOutDirectoryIfNotExists()
        {
            if (!Directory.Exists(_homePath + @"\out"))
                Directory.CreateDirectory(_homePath + @"\out");
        }
        private void CreateOutFile()
        {
            var data = "Clients: " + processor.TotalOfClients()
                 + "\n" + "Salesmen: " + processor.TotalOfSalesman()
                 + "\n" + "ID of Expansive Sell: " + processor.GetIdOfExpansiveSell()
                 + "\n" + "Worst Salesman: " + processor.GetWorstSeller();
            var streamWriter = File.CreateText(_homePath + $@"\out\{_fileName}.done.dat");
            streamWriter.WriteLine(data);

            streamWriter.Close();
        }
    }
}
