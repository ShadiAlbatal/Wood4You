using Newtonsoft.Json;
public class MainClass {

            private static int SummaryId;
            private static String CustomerName;
            private static String StockName;
            private static DateTime DueDate;
            private String VAT;


        static void Main(string[] args){

            List<JsonPropreties> Items = new List<JsonPropreties>();
                Console.WriteLine("Enter your full name");
                CustomerName = Console.ReadLine();
                Console.WriteLine("enter the duedate ");
                bool dateFormat = true;
                while (dateFormat){
                try
                    {
                        string pattern = "dd-mm-yyyy";
                        DueDate = DateTime.ParseExact(Console.ReadLine(), pattern, null);
                        dateFormat = false;
                    }
                    catch
                    {
                        Console.WriteLine("Enter due date in corrent format, example: 02-11-2021");
                    }
                }



                bool switcher = true;
                while (switcher)
                {
                    Console.WriteLine("Enter name of item you looking for:");
                    String StockName = Console.ReadLine();
                    var Item = Summary.GetItem(StockName);
                    if (Item.name == StockName)
                    {
                        Console.WriteLine(" Press 'Enter' to add it or Press 'any key' to exit");
                        String caser = Console.ReadLine();
                        bool switcher2 = true;

                        if (!String.IsNullOrEmpty(caser))
                        {
                            Console.WriteLine("will return to main menu..");
                            switcher2 = false;
                        }
                        else
                        {
                            JsonPropreties item = Summary.AddItem(StockName);
                            Items.Add(item);
                            Console.WriteLine("Press 'a' or 'any key' to add a new item or Press 'p' print your invoice draft ");
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