using Newtonsoft.Json;

    public class Summary {

            public static int SummaryId;


        public static String GenerateID(){
                
            String Date = DateTime.Now.ToString("yymmddhhmmss");
            Console.WriteLine(Date);
            return Date;
            }

        public static Invoice CreateSummary(String CustomerName, String DueDate, List<JsonPropreties> Item){

            String CreationDate = DateTime.Now.ToString("yy/mm/dd-hh:mm");
            String InvoiceID = GenerateID();
            String ModificationDate = CreationDate;
            String ConfirmationDate = CreationDate;
            String savedAs = InvoiceID+".json";

            // List<JsonPropreties> Items = new List<JsonPropreties>();
            // Items.Add(Item);

            Console.WriteLine("your Summary, '{0}', '{1}'", CustomerName, DueDate);
            Invoice invoice = new Invoice(){SummaryId=InvoiceID, CustomerName=CustomerName, DueDate=DueDate, CreationDate=CreationDate, ModificationDate=ModificationDate, ConfirmationDate=ConfirmationDate, savedAs=savedAs, OrderItems=Item};

            Console.WriteLine();
            SaveSummary(invoice);
            return invoice; 
        }

        public static List<JsonPropreties> AddItdem(String StockName){
            
            JsonPropreties Item =  GetItem(StockName);
            List<JsonPropreties> Items = new List<JsonPropreties>();
            Items.Add(Item);
            return Items;
        }

        public static JsonPropreties AddItem(String StockName, int Quantity){
            
            JsonPropreties FoundItem =  GetItem(StockName);
            double ItemsPrice = (FoundItem.price* (double) Quantity);
            string ItemsMaterial = FoundItem.material;
            JsonPropreties AddedItem = new JsonPropreties(){name=StockName, material=ItemsMaterial, quantity=Quantity, price=ItemsPrice};

            return AddedItem;
        }


        public static void SaveSummary(Invoice invoice){

            String fileName = invoice.SummaryId;
            using (StreamWriter file = File.CreateText(@"./jsons/"+fileName+".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, invoice);
                }
            }

        public static JsonPropreties GetItem(String StockName){

            var myJsonString = File.ReadAllText("file.json");
            var myJsonObject = JsonConvert.DeserializeObject<ReadJson>(myJsonString);
            List<JsonPropreties>ListOfItems = myJsonObject.Item;
            JsonPropreties FoundItems = ListOfItems.Find(x => x.name.Contains(StockName));
            Console.WriteLine("Item details, '{0}', '{1}', '{2}', '{3}'", FoundItems.name, FoundItems.material, FoundItems.quantity, FoundItems.price);

            return FoundItems;

            }




        









    }

public class Matrix {

}




