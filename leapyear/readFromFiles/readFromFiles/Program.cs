using System;
using System.Data.Common;
using System.IO;

namespace readFromFiles

{
    class Program
    {
        const string _separator = ",";
        static void Main(string[] args)
        {
            //las in en fils innehall
            //lasa filens innehall som bytes fran start till slut
            using (FileStream stream = File.Open("maxfritid.csv", FileMode.Open))
            //streamreader for att konvertera bytes till tecken
            using (StreamReader reader = new StreamReader(stream))
            {
                //om man vill fa ut all text pa en gang
                string fileContent = reader.ReadToEnd();
                                
            }
            // gar att skriva sa har istallet
            //string simpleReadFileContent = File.ReadAllText("maxfritid.csv");

            //Definera en lista som vi kan lagra produktdata i 

            List<Product> products = new List<Product>();

            using (FileStream stream = File.Open("maxfritid.csv", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        //logik for raden
                        string[] columns = line.Split(_separator);
                        try
                        {

                            Product product = new Product
                            {
                                Id = convertToInt(columns[0]),
                                ProductNumber = columns[2],
                                ProductName = columns[3],
                                ProductBrand = ConvertToNullableInt(columns[4]),
                                ProductSupplier = columns[5],
                                ProductSynonyms = ConvertToArray(columns[6])


                            };
                            //Placera behandling av produktion efter inalsning i samma try-sats
                            // for att undvika behandling 
                            products.Add(product);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        line = reader.ReadLine();
                    }
                }
            }

        }
        static int convertToInt(string input)
        {
            int.TryParse(input, out int result);

            return result;
        }

        static int? ConvertToNullableInt(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                return null;
            }
            static string[] ConvertToArray(string input)
            {
                if (input == null)
                    return new string[0];

                return input.Split(new char[]) { ' '; ','} StringSplitOptions.RemoveEmptyEntries);
            }

        }
    }
}
