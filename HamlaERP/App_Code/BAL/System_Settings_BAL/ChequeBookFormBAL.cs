using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ChequeBookFormBLL
/// </summary>
public class ChequeBookFormBAL
{
    ChequeBookFormDAL chequeBookFormDAL = new ChequeBookFormDAL();
    
	public ChequeBookFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetChequeBookListById(ChequeBookFormUI chequeBookFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = chequeBookFormDAL.GetChequeBookListById(chequeBookFormUI);
        return dtb;
    }

    public int AddChequeBook(ChequeBookFormUI chequeBookFormUI)
    {
        int resutl = 0;
        resutl = chequeBookFormDAL.AddChequeBook(chequeBookFormUI);
        return resutl;
    }

    public int UpdateChequeBook(ChequeBookFormUI chequeBookFormUI)
    {
        int resutl = 0;
        resutl = chequeBookFormDAL.UpdateChequeBook(chequeBookFormUI);
        return resutl;
    }

    public int DeleteChequeBook(ChequeBookFormUI chequeBookFormUI)
    {
        int resutl = 0;
        resutl = chequeBookFormDAL.DeleteChequeBook(chequeBookFormUI);
        return resutl;
    }
}