﻿using dotnet_code_challenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

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
                                var filePath = Path.Combine(directoryPath, filePaths.ElementAt(ItemNum - 1)).ToLower();
                                var fileData = File.ReadAllText(filePath);

                                if (filePath.EndsWith(".json") && string.IsNullOrWhiteSpace(fileData))
                                {
                                    JSONData data = JsonConvert.DeserializeObject<JSONData>(fileData);

                                }
                                else if (filePath.EndsWith(".xml") && string.IsNullOrWhiteSpace(fileData))
                                {
                                    var serializer = new XmlSerializer(typeof(XMLData));
                                    XMLData data = null;
                                    using (var reader = XmlReader.Create(filePath))
                                    {
                                        data = (XMLData)serializer.Deserialize(reader);
                                    }
                                    foreach (var item in data.Races.OrderBy(x => x.Number))
                                    {
                                        foreach (var pricing in item.Prices)
                                        {
                                            Console.WriteLine($"Race {item.Number} - {item.Name} ({pricing.PriceType}");
                                            Console.WriteLine("===================================");
                                            foreach (var horse in pricing.Horses.OrderBy(x => x.Price))
                                            {
                                                Console.WriteLine($"{item.Horses.Where(x => x.Number == horse.Number).FirstOrDefault()?.Name} @ ${horse.Price}");
                                            }
                                            Console.WriteLine("");
                                        }
                                    } 

                                }
                                else
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
