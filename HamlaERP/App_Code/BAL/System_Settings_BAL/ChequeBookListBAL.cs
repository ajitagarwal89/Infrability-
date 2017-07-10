using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for ChequeBookListBLL
/// </summary>
public class ChequeBookListBAL
{
    ChequeBookListDAL chequeBookListDAL = new ChequeBookListDAL();

	public ChequeBookListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetChequeBookList()
    {
        DataTable dtb = new DataTable();
        dtb = chequeBookListDAL.GetChequeBookList();
        return dtb;
    }

    public DataTable GetChequeBookListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = chequeBookListDAL.GetChequeBookListForExportToExcel();
        return dtb;
    }
    public DataTable GetChequeBookListById(ChequeBookListUI chequeBookListUI)
    {
        DataTable dtb = new DataTable();
        dtb = chequeBookListDAL.GetChequeBookListById(chequeBookListUI);
        return dtb;
    }

    public DataTable GetChequeBookListBySearchParameters(ChequeBookListUI chequeBookListUI)
    {
        DataTable dtb = new DataTable();
        dtb = chequeBookListDAL.GetChequeBookListBySearchParameters(chequeBookListUI);
        return dtb;
    }

    public int DeleteChequeBook(ChequeBookListUI chequeBookListUI)
    {
        int result = 0;
        result = chequeBookListDAL.DeleteChequeBook(chequeBookListUI);
        return result;
    }
}