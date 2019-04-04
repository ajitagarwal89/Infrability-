using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for BatchFormBLL
/// </summary>
public class BatchFormBAL
{
    BatchFormDAL batchFormDAL = new BatchFormDAL();

	public BatchFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetBatchListById(BatchFormUI batchFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = batchFormDAL.GetBatchListById(batchFormUI);
        return dtb;
    }

    public int AddBatch(BatchFormUI batchFormUI)
    {
        int resutl = 0;
        resutl = batchFormDAL.AddBatch(batchFormUI);
        return resutl;
    }

    public int UpdateBatch(BatchFormUI batchFormUI)
    {
        int resutl = 0;
        resutl = batchFormDAL.UpdateBatch(batchFormUI);
        return resutl;
    }

    public int DeleteBatch(BatchFormUI batchFormUI)
    {
        int resutl = 0;
        resutl = batchFormDAL.DeleteBatch(batchFormUI);
        return resutl;
    }
    public int UpdatePostingBatch(BatchFormUI batchFormUI)
    {
        int resutl = 0;
        resutl = batchFormDAL.UpdatePostingBatch(batchFormUI);
        return resutl;
    }
}