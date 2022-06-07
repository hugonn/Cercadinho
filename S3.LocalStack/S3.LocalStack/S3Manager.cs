using System;
using System.Configuration;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace S3.LocalStack
{
    public class S3Manager
    {
        private string AccessKey { get; }
        private string SecretKey { get; }
        private string BucketName { get; }
        private string ServiceUrl { get; }
        private AmazonS3Config AmazonConfig { get; }
        private RegionEndpoint BucketRegion { get; }

        public S3Manager()
        {
            AccessKey = "";
            SecretKey = "";
            BucketName = "";
            ServiceUrl = "";
            BucketRegion = RegionEndpoint.SAEast1;

            AmazonConfig = new AmazonS3Config
            {
                RegionEndpoint = BucketRegion,
                ServiceURL = this.ServiceUrl,
                ForcePathStyle = true
            };
      
        }
        
        public void UploadFile(string content, string fileName)
        {
            try
            {
                using (var memoryStream = content.ToStream())
                using (var s3Client = new AmazonS3Client(AccessKey, SecretKey, AmazonConfig))
                {
                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = memoryStream,
                        Key = fileName,
                        BucketName = BucketName            
                    };
                    
                    var fileTransferUtility = new TransferUtility(s3Client);
                    fileTransferUtility.UploadAsync(uploadRequest).Wait();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
        }
    }
}