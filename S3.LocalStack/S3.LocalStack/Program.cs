using S3.LocalStack;

namespace S3.LocalStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new S3Manager();
            manager.UploadFile("Teste Hugo", "Hi.json");
        }
    }
}
