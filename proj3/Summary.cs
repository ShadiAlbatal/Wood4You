using Newtonsoft.Json;

    public class Summary {

        private static int SummaryId;
        private static int ItemId= 0;
        public static String GenerateID(){
                
            String Date = DateTime.Now.ToString("yymmddhhmmss");
            return Date;
            }

        public static Invoice CreateSummary(String CustomerName, String DueDate, List<JsonPropreties> Item){

            String CreationDate = DateTime.Now.ToString("yy/mm/dd-hh:mm:ss");
            String InvoiceID = GenerateID();
            String ModificationDate = null;
            String ConfirmationDate = null;
            String savedAs = InvoiceID+".json";
            Invoice invoice = new Invoice(){SummaryId=InvoiceID, CustomerName=CustomerName, DueDate=DueDate, CreationDate=CreationDate, ModificationDate=ModificationDate, ConfirmationDate=ConfirmationDate, savedAs=savedAs, OrderItems=Item};
            Console.WriteLine();
            SaveSummary(invoice);
            return invoice; 
        }

            public static JsonPropreties AddItem(String StockName){
            try
            {
            Console.WriteLine("from addITem");
            Console.WriteLine("how many you need:");
            int Quantity = Convert.ToInt32(Console.ReadLine());
            JsonPropreties FoundItem =  GetItem(StockName);
            JsonPropreties AddedItem = new JsonPropreties();
            if (FoundItem.quantity > Quantity)
            {
                ItemId = ItemId + 1;
                double ItemsPrice = (FoundItem.price* (double) Quantity);
                string ItemsMaterial = FoundItem.material;
                AddedItem = new JsonPropreties(){id=ItemId, name=StockName, material=ItemsMaterial, quantity=Quantity, price=ItemsPrice};
                Console.WriteLine("Items in your card : '{0}', '{1}', '{2}', '{3}'", AddedItem.name, AddedItem.material, AddedItem.quantity, AddedItem.price);
            }
            else
            {
                Console.WriteLine("you can add up to '{0}' of '{1}'", FoundItem.quantity ,FoundItem.name);
            }
            return AddedItem;
            }
            catch (System.FormatException)
            {
                JsonPropreties noItem = new JsonPropreties();
                Console.WriteLine("Enter a valid number");
                return noItem;
            }    

        }

        // public static JsonPropreties AddItem(String StockName, int Quantity){
        //     Console.WriteLine("from addITem");
        //     Console.WriteLine("how many you need:");
        //     Quantity = Convert.ToInt32(Console.ReadLine());
        //     JsonPropreties FoundItem =  GetItem(StockName);
        //     JsonPropreties AddedItem = new JsonPropreties();
        //     try
        //     {
        //         if (FoundItem.quantity > Quantity)
        //         {
        //             ItemId = ItemId + 1;
        //             double ItemsPrice = (FoundItem.price* (double) Quantity);
        //             string ItemsMaterial = FoundItem.material;
        //             AddedItem = new JsonPropreties(){id=ItemId, name=StockName, material=ItemsMaterial, quantity=Quantity, price=ItemsPrice};
        //             Console.WriteLine("Items in your card : '{0}', '{1}', '{2}', '{3}'", AddedItem.name, AddedItem.material, AddedItem.quantity, AddedItem.price);
        //         }
        //         else
        //         {
        //             Console.WriteLine("you can add up to '{0}' of '{1}'", FoundItem.quantity ,FoundItem.name);
        //         }
        //         return AddedItem;
        //     }
        //     catch (System.FormatException)
        //     {
        //         Console.WriteLine("-------s---------------");
        //         JsonPropreties noItem = new JsonPropreties();
        //         Console.WriteLine("---------e-------------");
        //         return noItem;
                
        //     }
 
        // }


        public static void SaveSummary(Invoice invoice){

            String fileName = invoice.SummaryId;
            using (StreamWriter file = File.CreateText(@"./jsons/"+fileName+".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, invoice);
                }
            }

        public static List<JsonPropreties> FindItem(){

            var myJsonString = File.ReadAllText("file.json");
            var myJsonObject = JsonConvert.DeserializeObject<ReadJson>(myJsonString);
            List<JsonPropreties>ListOfItems = myJsonObject.Item;
            return ListOfItems;

        }

        // public static JsonPropreties GetItem(String StockName){
        //     List<JsonPropreties>ListOfItems = FindItem();
        //     JsonPropreties FoundItems = null;
        //     try
        //     {
        //         FoundItems = ListOfItems.Find(x => x.name.Contains(StockName));
        //         Console.WriteLine("Item in Stock: '{0}', '{1}', '{2}', '{3}'", FoundItems.name, FoundItems.material, FoundItems.quantity, FoundItems.price);
        //         return FoundItems;
        //     }
        //     catch(System.NullReferenceException)
        //     {
        //         Console.Write("Cannot divide by zero. Please try again.");
        //         return null;
        //     }
        // }

        public static JsonPropreties GetItem(String StockName){
            List<JsonPropreties>ListOfItems = FindItem();
            JsonPropreties FoundItems = new JsonPropreties {};
            try
            {
                FoundItems = ListOfItems.Find(x => x.name.Contains(StockName));
                Console.WriteLine("Item in Stock: '{0}', '{1}', '{2}', '{3}'", FoundItems.name, FoundItems.material, FoundItems.quantity, FoundItems.price);
                return FoundItems;
            }
            catch (System.NullReferenceException)
            {
                JsonPropreties noItem = new JsonPropreties {};
                Console.WriteLine("We did not find this Item, try again");
                return noItem;
            }

        }

        public static void PrintSummary(Invoice invoice){
            var InvoicePath =  "./jsons/" + invoice.SummaryId + ".json";
            var myJsonString = File.ReadAllText(InvoicePath);
            var myJsonObject = JsonConvert.DeserializeObject<Invoice>(myJsonString);
            var Items = myJsonObject.OrderItems;
            double Total = 0;
            Console.WriteLine(invoice);
            foreach(var Item in Items){
                Total = Total + Item.price;
                Console.WriteLine(Item);
            }
            Console.WriteLine("Total Price:" + Total);
            Console.WriteLine();
            Console.WriteLine("press 1 to confirm your order");
            int save = Convert.ToInt32(Console.ReadLine()); 
            if (save == 1){
                Console.WriteLine("Generating your Invoice....");
                invoice.ModificationDate = DateTime.Now.ToString("yy/mm/dd-hh:mm:ss");
                invoice.ConfirmationDate = DateTime.Now.ToString("yy/mm/dd-hh:mm:ss");

                Console.WriteLine("======================Invoice===============================");
                Console.WriteLine(invoice);
                Console.WriteLine("----------------------");
                foreach(var Item in Items){
                    Total = Total + Item.price;
                    Console.WriteLine(Item);
                }
                Console.WriteLine("----------------------");
                Console.WriteLine("Total Price:" + Total);
                Console.WriteLine("======================End===============================");
            }
            Console.WriteLine("Your order has been sent, we will contact you soon, thank you...");
        }










    }



