using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GeneralJournalDetailsListBAL
/// </summary>
public class GeneralJournalDetailsListBAL
{
    GeneralJournalDetailsListDAL generalJournalDetailsListDAL = new GeneralJournalDetailsListDAL();

	public GeneralJournalDetailsListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
  
    public DataTable GetGeneralJournalDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalDetailsListDAL.GetGeneralJournalDetailsList();
        return dtb;
    }

    public DataTable GetGeneralJournalDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalDetailsListDAL.GetGeneralJournalDetailsListForExportToExcel();
        return dtb;
    }
    public DataTable GetGeneralJournalDetailsListById(GeneralJournalDetailsListUI generalJournalDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalDetailsListDAL.GetGeneralJournalDetailsListById(generalJournalDetailsListUI);
        return dtb;
    }

    public DataTable GetGeneralJournalDetailsListBySearchParameters(GeneralJournalDetailsListUI generalJournalDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalDetailsListDAL.GetGeneralJournalDetailsListBySearchParameters(generalJournalDetailsListUI);
        return dtb;
    }

    public int DeleteGeneralJournalDetails(GeneralJournalDetailsListUI generalJournalDetailsListUI)
    {
        int result = 0;
        result = generalJournalDetailsListDAL.DeleteGeneralJournalDetails(generalJournalDetailsListUI);
        return result;
    }
}