

    public class Invoice {
        public string SummaryId { get; set; }

        public string CustomerName { get; set; }

        public string DueDate { get; set; }

        public string CreationDate { get; set; }

        public string ModificationDate { get; set; }

        public string ConfirmationDate { get; set; }

        public string savedAs { get; set; }

        public List<JsonPropreties> OrderItems { get; set; }

    public override string ToString()
    {

        return " SummaryId: " + SummaryId +" CustomerName: " + CustomerName + "   DueDate: " + DueDate + "   CreationDate:" + CreationDate + "   ConfirmationDate:" + ConfirmationDate;
    }
        // public int quantity { get; set; }
            // public double price { get; set; }

    }