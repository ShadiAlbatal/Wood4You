

    public class Invoice {
        public string SummaryId { get; set; }

        public string CustomerName { get; set; }

        public DateTime DueDate { get; set; }

        public string CreationDate { get; set; }

        public string ModificationDate { get; set; }

        public string ConfirmationDate { get; set; }

        public string savedAs { get; set; }

        public List<JsonPropreties> OrderItems { get; set; }

    public override string ToString()
    {

        return " Summary Id: " + SummaryId +"   Customer Name: " + CustomerName + "\n"
        + "   DueDate: " + DueDate + "   Creation Date:" + CreationDate + "\n"
        + "   Confirmation Date:" + ConfirmationDate+ "   Updated Date:" + "\n"
        + ModificationDate + "   Saved As:" + savedAs ;
    }

    }