﻿// using Newtonsoft.Json;
// public class MainClass {

//             public static int SummaryId;
//             public static String CustomerName;
//             public static String StockName;
//             public static String DueDate;
//             public static int Quantity;
//             public String VAT;


//         static void Main(string[] args){

//             List<JsonPropreties> Items = new List<JsonPropreties>();
//             Console.WriteLine("enter: your name, duedate");
//                 DueDate = Console.ReadLine();
//                 CustomerName = Console.ReadLine();
                
//             // Console.WriteLine("enter: 0 to exit, 1 to add another item");
//             bool switcher = true;
//             while (switcher)
//             {
//                 Console.WriteLine("enter: stock, quanitity");
//                 StockName = Console.ReadLine();
//                 Quantity = Convert.ToInt32(Console.ReadLine()); 

//                 JsonPropreties item = Summary.AddItem(StockName, Quantity);

//                 Items.Add(item);
//                 Console.WriteLine("enter: anything or 0 to exit, Enter to add another item");
//                 String caser = Console.ReadLine();
//             // String.IsNullOrEmpty(caser) ? "Yes" : "No";
//                 if (!String.IsNullOrEmpty(caser))
//                 {
//                     Console.WriteLine("will exit..");
//                     switcher = false;
//                 }
//                 else
//                 {
//                     Console.WriteLine("will continue..");
//                 }
//             }


//         Invoice invoice = Summary.CreateSummary(CustomerName, DueDate, Items);
//         Console.WriteLine("press 1 to print ur invoice");
//         int save = Convert.ToInt32(Console.ReadLine()); 
//         Console.WriteLine("Generating ur invoice");
//         if (save == 1){
//         Summary.PrintSummary(invoice);
//         }

//     }

// }














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
            Console.WriteLine("enter: your name, duedate");
                DueDate = Console.ReadLine();
                CustomerName = Console.ReadLine();
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