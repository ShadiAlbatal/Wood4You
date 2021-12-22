using Newtonsoft.Json;
public class MainClass {

            public static int SummaryId;
            public static String CustomerName;
            public static String StockName;
            public static String DueDate;
            public static int Quantity;
            public String VAT;



    // static void Main(string[] args){

    //     Console.WriteLine("enter name, stock, quanitity, duedate");
    //     CustomerName = Console.ReadLine();
    //     StockName = Console.ReadLine();
    //     DueDate = Console.ReadLine();
    //     Quantity = Convert.ToInt32(Console.ReadLine());

    //     Summary.GetItem(StockName);
    //     Summary.CreateSummary(CustomerName ,StockName, Quantity, DueDate);

    //     Console.WriteLine("0, 1, 2");
    //     int Switcher = Convert.ToInt32(Console.ReadLine());

    //     // switch (Switcher)
    //     // {
    //     //     String NewItem = Console.ReadLine();
    //     //     Summary.AddItem(NewItem);
    //     // }

    // }
 //            Console.WriteLine("enter name, quanitity, duedate");

        static void Main(string[] args){

            List<JsonPropreties> Items = new List<JsonPropreties>();
            Console.WriteLine("enter: your name, duedate");
                DueDate = Console.ReadLine();
                CustomerName = Console.ReadLine();
                
            // Console.WriteLine("enter: 0 to exit, 1 to add another item");
            bool switcher = true;
            while (switcher)
            {
                Console.WriteLine("enter: stock, quanitity");
                StockName = Console.ReadLine();
                Quantity = Convert.ToInt32(Console.ReadLine()); 

                JsonPropreties item = Summary.AddItem(StockName, Quantity);

                Items.Add(item);
                Console.WriteLine("enter: anything or 0 to exit, Enter to add another item");
                String caser = Console.ReadLine();
            // String.IsNullOrEmpty(caser) ? "Yes" : "No";
                if (!String.IsNullOrEmpty(caser))
                {
                    Console.WriteLine("will exit..");
                    switcher = false;
                }
                else
                {
                    Console.WriteLine("will continue..");
                }
        }


            Summary.CreateSummary(CustomerName, DueDate, Items);

            


    }

}
