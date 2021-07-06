using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestEx2
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                ReadAndComparison();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        private static void ReadingFileAddToList(ICollection<HashFile> list, string path)
        {
            using (var fileStream = new StreamReader(path))//читаем файл с файлами и др. информацией и получаем лист файлов
            {
                while (!fileStream.EndOfStream)
                {
                    var s = fileStream.ReadLine();//считываем строку и нужно со строкой s что-нибудь делать
                    var arrStrings = s.Split(' ');//в массиве имя файл[0], алгоритм[1], hash сумма[2]

                    list.Add(new HashFile()
                    {
                        FileName = arrStrings[0],
                        HashAlgorithm = arrStrings[1].ToLower(),
                        HashSumm = Encoding.Default.GetBytes(arrStrings[2])
                    });
                }
            }
        }

        private static bool ComparisonTwoHash(IReadOnlyList<byte> arr1Bytes, IReadOnlyList<byte> arr2Bytes)
        {
            var bEqual = false;

            if (arr1Bytes.Count == arr2Bytes.Count)
            {
                var i = 0;
                while ((i < arr1Bytes.Count) && (arr1Bytes[i] == arr2Bytes[i]))
                {
                    i++;
                }

                if (i == arr1Bytes.Count)
                    bEqual = true;
            }

            return bEqual;
        }

        private static void CheckingEqual(bool equal, string filename)
        {
            if (equal)
                Console.WriteLine(filename + "OK");
            else
                Console.WriteLine(filename + "FAIL");
        }

        private static void ReadAndComparison()
        {
            Console.WriteLine("Введите путь к файлу сумм:");
            var pathInputFile = Console.ReadLine();

            if (File.Exists(pathInputFile))
            {

            }

            Console.WriteLine("Введите путь к папке, где лежат файлы:");
            var pathFilesToChek = Console.ReadLine();

            var listFiles = new List<HashFile>();

            ReadingFileAddToList(listFiles, pathInputFile);

            foreach (var file in listFiles)//провереям хэш суммы
            {
                var path = Path.Combine(pathFilesToChek, file.FileName);

                if (File.Exists(path))
                {
                    var tmpSource = File.ReadAllBytes(path);

                    switch (file.HashAlgorithm)
                    {
                        case "md5":
                            {
                                var tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

                                CheckingEqual(
                                    ComparisonTwoHash(file.HashSumm, tmpHash),
                                    file.FileName);
                                break;
                            }
                        case "sha1":
                            {
                                var tmpHash = new SHA1CryptoServiceProvider().ComputeHash(tmpSource);
                                CheckingEqual(
                                    ComparisonTwoHash(file.HashSumm, tmpHash),
                                    file.FileName);
                                break;
                            }
                        case "sha256":
                            {
                                var tmpHash = new SHA256CryptoServiceProvider().ComputeHash(tmpSource);
                                CheckingEqual(
                                    ComparisonTwoHash(file.HashSumm, tmpHash),
                                    file.FileName);
                                break;
                            }
                    }
                }

                else
                {
                    Console.WriteLine(file.FileName + "NOT FOUND");
                }
            }
        }
    }
}
