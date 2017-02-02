using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for TableConn
/// </summary>
/// 


public class TableConn
{
    public TableConn()
    {
        storageAcc = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=adamdevstorage;AccountKey=ni7ZRTfgiaCuWbOqrSVoIZADMDoOi1/riCvbdu/76NmGbOI5M0jN1i2w/Q84xhRsAQgjti9Vwrmgh6JU9Nlxiw==;");
        tableClient = storageAcc.CreateCloudTableClient();
        table = tableClient.GetTableReference("IgniteAttendees");
    }

    public IEnumerable<Attendee> retrieve(string name)
    {
        var query = new TableQuery<Attendee>().Where(TableQuery.GenerateFilterCondition(nameof(Attendee.name), QueryComparisons.Equal, name));
        IEnumerable<Attendee> result = table.ExecuteQuery(query);
        if (result.Count() == 0)
        {
            return null;
        }
        //need some logic for people w/ same name
        else
            return result;
    }

    private CloudStorageAccount storageAcc;
    private CloudTableClient tableClient;
    private CloudTable table;
}
