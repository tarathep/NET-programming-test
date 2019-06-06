using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CalculateOparator
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList();
            using (StreamReader file = new StreamReader("file.log"))
            {
                int counter = 0;
                string ln;

                //READ LOG FILE
                while ((ln = file.ReadLine()) != null)
                {
                    int price = 0;
                    // INTO MODEL 
                    Customer customer = new Customer();
                    customer.date = ln.Split('|')[0];
                    customer.start = (ln.Split('|')[1]);
                    customer.end = (ln.Split('|')[2]);
                    customer.mobile = (ln.Split('|')[3]);
                    customer.promotion = (ln.Split('|')[4]);

                    DateTime start = DateTime.Parse(customer.date + " " + customer.start);
                    DateTime end = DateTime.Parse(customer.date + " " + customer.end);

                    // CAL USE TIME
                    TimeSpan useTime = end - start;

                    //CHECK PROMOTION TYPE
                    if (customer.promotion.Equals("P1"))
                    {
                        //CAL PRICE
                        if (useTime.Minutes > 1)
                        {
                            if (useTime.Seconds > 0)
                            {
                                price = useTime.Minutes + 3;
                            }
                            else
                            {
                                price = useTime.Minutes + 2;
                            }
                        }
                        else
                        {
                            price = 3;
                        }

                    }
                    else
                    {
                        customer.promotion = ("Others Promotion P?");
                    }

                    customer.price = (price);

                    arr.Add(customer);
                    counter++;
                }
                file.Close();

                //OUTPUT SHOW ON SCREEN
                Console.WriteLine("\n\tOPARATOR CALL CALULATOR PRICE\n---------------------------------------------");
                foreach (Customer cus in arr)
                {
                    Console.WriteLine(cus.mobile + " > " + cus.price + " Baht.");
                }
                Console.WriteLine($"Mobile has {counter} lines.");
                Console.ReadKey();

                // EXPORT JSON FILE
                string json = JsonConvert.SerializeObject(arr.ToArray());
                File.WriteAllText("log.json", json);

            }
        }
    }
    
    public class Customer
    {
        public string date { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string mobile { get; set; }
        public string promotion { get; set; }
        public int price { get; set; }
    }
}
