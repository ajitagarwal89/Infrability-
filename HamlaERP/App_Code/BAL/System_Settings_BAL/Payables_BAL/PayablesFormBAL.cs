using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PayablesFormBLL
/// </summary>
public class PayablesFormBAL
{
    PayablesFormDAL payablesFormDAL = new PayablesFormDAL();

	public PayablesFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetPayablesListById(PayablesFormUI payablesFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = payablesFormDAL.GetPayablesListById(payablesFormUI);
        return dtb;
    }

    public int AddPayables(PayablesFormUI payablesFormUI)
    {
        int resutl = 0;
        resutl = payablesFormDAL.AddPayables(payablesFormUI);
        return resutl;
    }

    public int UpdatePayables(PayablesFormUI payablesFormUI)
    {
        int resutl = 0;
        resutl = payablesFormDAL.UpdatePayables(payablesFormUI);
        return resutl;
    }

    public int DeletePayables(PayablesFormUI payablesFormUI)
    {
        int resutl = 0;
        resutl = payablesFormDAL.DeletePayables(payablesFormUI);
        return resutl;
    }
}