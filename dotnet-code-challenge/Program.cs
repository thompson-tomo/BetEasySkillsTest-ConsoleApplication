using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Please enter directory path to scan. Leaving it empty will default to current directory.");
                string directoryPath = "";
                do
                {
                    directoryPath = Console.ReadLine();
                    if (directoryPath.ToLower() == "exit") return; ;
                    if (Directory.Exists(directoryPath))
                    {
                        break;
                    }
                    Console.WriteLine("Sorry but that directory can not be found");
                    List<string> filePaths = Directory.GetFiles(directoryPath, "*.json OR *.xml", SearchOption.TopDirectoryOnly).ToList();
                    if (filePaths.Count > 0)
                    {
                        int page = 1;
                        int size = 10;
                        while (true)
                        {
                            int i = 1;
                            foreach (var item in filePaths.Skip((page - 1)*size).Take(size))
                            {
                                Console.WriteLine($"{(page - 1) * size + i} - {item.ToString()}");
                                i++;
                            }
                            Console.WriteLine("Please enter number corresponding to file, or the page number or next or prev.");
                            do
                            {
                                string cmd = Console.ReadLine();
                                if (cmd.ToLower() == "next")
                                {
                                    if (filePaths.Count <= size * page)
                                    {
                                        Console.WriteLine("Unable to move to next page");
                                        continue;
                                    }
                                    else
                                    {
                                        page++;
                                        break;
                                    }   
                                }
                                else if (cmd.ToLower() == "prev")
                                {
                                    if (page <= 1)
                                    {
                                        Console.WriteLine("Unable to move to prev page");
                                        continue;
                                    }
                                    else
                                    {
                                        page--;
                                        break;
                                    }
                                }
                                else if (cmd.ToLower().StartsWith("page ") && cmd.Split(' ').Count() == 2)
                                {
                                    Int32.TryParse(cmd.Split(' ')[1], out int pageNumb);
                                    if (filePaths.Count < size * (pageNumb - 1))
                                    {
                                        Console.WriteLine($"Unable to move to page {pageNumb}");
                                        continue;
                                    }
                                    else
                                    {
                                        page = pageNumb;
                                        break;
                                    }
                                }
                                Int32.TryParse(cmd, out int ItemNum);
                                if (ItemNum <= (page -1) * size || ItemNum > page* size)
                                {
                                    Console.WriteLine("Non Valid file selected");
                                    continue;
                                }
                            } while (true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry but no supported files found in that diretory.");
                    }
                } while (true);
            }
        }
    }
}
