using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GeneralJournalListBAL
/// </summary>
public class GeneralJournalListBAL
{
    GeneralJournalListDAL generalJournalListDAL = new GeneralJournalListDAL();

	public GeneralJournalListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGeneralJournalList()
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalListDAL.GetGeneralJournalList();
        return dtb;
    }
    public DataTable GetGeneralJournalListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalListDAL.GetGeneralJournalListForExportToExcel();
        return dtb;
    }
    public DataTable GetGeneralJournalListById(GeneralJournalListUI generalJournalListUI)
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalListDAL.GetGeneralJournalListById(generalJournalListUI);
        return dtb;
    }

    public DataTable GetGeneralJournalListBySearchParameters(GeneralJournalListUI generalJournalListUI)
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalListDAL.GetGeneralJournalListBySearchParameters(generalJournalListUI);
        return dtb;
    }

    public int DeleteGeneralJournal(GeneralJournalListUI generalJournalListUI)
    {
        int result = 0;
        result = generalJournalListDAL.DeleteGeneralJournal(generalJournalListUI);
        return result;
    }
}