
namespace DataReader.Core.Ports
{
    public interface IFilePort
    {
        void Process(string homePath, string fileName);
    }
}
