using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for BatchListBLL
/// </summary>
public class BatchListBAL
{
    BatchListDAL batchListDAL = new BatchListDAL();

    public BatchListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetBatchList()
    {
        DataTable dtb = new DataTable();
        dtb = batchListDAL.GetBatchList();
        return dtb;
    }

    public DataTable GetBatchListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = batchListDAL.GetBatchListForExportToExcel();
        return dtb;
    }
    public DataTable GetBatchListById(BatchListUI batchListUI)
    {
        DataTable dtb = new DataTable();
        dtb = batchListDAL.GetBatchListById(batchListUI);
        return dtb;
    }

    public DataTable GetBatchListBySearchParameters(BatchListUI batchListUI)
    {
        DataTable dtb = new DataTable();
        dtb = batchListDAL.GetBatchListBySearchParameters(batchListUI);
        return dtb;
    }

    public int DeleteBatch(BatchListUI batchListUI)
    {
        int result = 0;
        result = batchListDAL.DeleteBatch(batchListUI);
        return result;
    }
}