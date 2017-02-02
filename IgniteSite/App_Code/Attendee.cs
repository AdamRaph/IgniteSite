using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

/// <summary>
/// Summary description for Attendees
/// </summary>

public class Attendee : TableEntity
{
    public Attendee()
    {
    }
    public Attendee(string id)
    {
        this.PartitionKey = "Attendee";
        this.RowKey = id;
    }
    public int memberID { get; set; }
    public string name { get; set; }
    public string company { get; set; }
    public string jobTitle { get; set; }
    public string ticketType { get; set; }
    public int ticketQuantity { get; set; }
}
