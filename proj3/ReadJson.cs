public class ReadJson {

    public List<JsonPropreties> Item { get; set; }

}



public class JsonPropreties {

    public string name { get; set; }
    public string material { get; set; }
    public int quantity { get; set; }
    public double price { get; set; }


    // public override string ToString()
    // {
    //     return "name: " + name + "   material: " + material + "   price:" + price;
        
    // }


}