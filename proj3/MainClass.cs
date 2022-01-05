using Newtonsoft.Json;
public class MainClass {

            public static int SummaryId;
            public static String CustomerName;
            public static String StockName;
            public static String DueDate;
            public static int Quantity;
            public String VAT;


        static void Main(string[] args){

            List<JsonPropreties> Items = new List<JsonPropreties>();
                Console.WriteLine("enter your full name");
                CustomerName = Console.ReadLine();
                Console.WriteLine("enter the duedate (yyyy-mm-dd)");
                DueDate = Console.ReadLine();

                bool switcher = true;
                while (switcher)
                {
                    Console.WriteLine("enter name of item you looking for:");
                    String StockName = Console.ReadLine();
                    var Item = Summary.GetItem(StockName);
                    if (Item.name == StockName)
                    {
                        // Console.WriteLine("press 1 to add it");
                        // int add = Convert.ToInt32(Console.ReadLine()); 
                        Console.WriteLine("enter: anything to exit, Enter to add it");
                        String caser = Console.ReadLine();
                        bool switcher2 = true;

                        if (!String.IsNullOrEmpty(caser))
                        {
                            Console.WriteLine("will return to main menu..");
                            switcher2 = false;
                        }
                        else
                        {
                            Console.WriteLine("how many you need:");
                            Quantity = Convert.ToInt32(Console.ReadLine());
                            JsonPropreties item = Summary.AddItem(StockName, Quantity);
                            Items.Add(item);
                            Console.WriteLine("press 'a' to add a new item , 'p' print your invoice draft");
                            String caser2 = Console.ReadLine();
                            if (caser2 == "a")
                            {
                                switcher2 = false;
                            }
                            else if (caser2 == "p")
                            {
                                Invoice invoice = Summary.CreateSummary(CustomerName, DueDate, Items);
                                Summary.PrintSummary(invoice);
                                break;
                            }


                        }
                    }

                }
        }
}