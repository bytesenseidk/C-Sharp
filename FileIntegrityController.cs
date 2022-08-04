using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace FileIntegrityController
{
    class Validator
    {
        private string fileName;
        private string checkSum;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value.Trim('"') ?? throw new ArgumentNullException("No file given");
                Directory.SetCurrentDirectory(System.IO.Path.GetDirectoryName(fileName));
                fileName = Path.GetFileName(fileName);
            }
        }
        public string CheckSum
        {
            get { return checkSum; }
            set
            {
                checkSum = value ?? throw new ArgumentNullException("No checksum given");
            }
        }
        public virtual string ChecksumCalculator()
        {
            using (SHA256 SHA256 = SHA256.Create())
            {
                using FileStream fileStream = File.OpenRead(FileName);
                return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
            }
        }
        public bool Validate()
        {
            return ChecksumCalculator() == CheckSum;
        }
        public virtual string Result()
        {
            return $"Generated: \t{ChecksumCalculator()}\nGiven: \t\t{CheckSum}\nMatch: \t\t{Validate()}";
        }
    }

    internal class SHA256Validation : Validator
    {
        public SHA256Validation(string filename, string checksum)
        {
            FileName = filename;
            CheckSum = checksum;
        }
        public override string ChecksumCalculator()
        {
            using (SHA256 SHA256 = SHA256.Create())
            {
                using FileStream fileStream = File.OpenRead(FileName);
                return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
            }
        }
        public override string Result()
        {
            return "Checksum match: SHA256\n" + base.Result();
        }
    }

    internal class SHA512Validation : Validator
    {
        public SHA512Validation(string filename, string checksum)
        {
            FileName = filename;
            CheckSum = checksum;
        }
        public override string ChecksumCalculator()
        {
            using (SHA512 SHA512 = SHA512.Create())
            {
                using FileStream fileStream = File.OpenRead(FileName);
                return Convert.ToBase64String(SHA512.ComputeHash(fileStream));
            }
        }
        public override string Result()
        {
            return "Checksum match: SHA512\n" + base.Result();
        }
    }

    internal class MD5Validation : Validator
    {
        public MD5Validation(string filename, string checksum)
        {
            FileName = filename;
            CheckSum = checksum;
        }
        public override string ChecksumCalculator()
        {
            using (MD5 MD5 = MD5.Create())
            {
                using FileStream fileStream = File.OpenRead(FileName);
                return Convert.ToBase64String(MD5.ComputeHash(fileStream));
            }
        }
        public override string Result()
        {
            return "Checksum match: MD5\n" + base.Result();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path to file: ");
            string file = Console.ReadLine();
            Console.Write("Enter checksum: ");
            string checksum = Console.ReadLine();
            
            SHA256Validation sha256 = new(file, checksum);
            SHA512Validation sha512 = new(file, checksum);
            MD5Validation md5 = new(file, checksum);

            List<bool> checks = new()
            {
                sha256.Validate(), sha512.Validate(), md5.Validate()
            };

            List<string> results = new()
            {
                sha256.Result(), sha512.Result(), md5.Result()
            };
            
            int index = 0;
            foreach (bool check in checks)
            {
                if (check == true)
                {
                    Console.Clear();
                    Console.WriteLine("[ MATCH! ]\n");
                    Console.WriteLine(results[index]);
                    break;
                }
                index++;
                if (index == checks.Count) 
                {
                    Console.Clear();
                    Console.WriteLine("[ NO MATCH! ]"); 
                }
            }
        }
    }
}
