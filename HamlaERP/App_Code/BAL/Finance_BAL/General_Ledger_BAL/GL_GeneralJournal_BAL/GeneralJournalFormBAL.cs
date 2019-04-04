using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GeneralJournalFormBAL
/// </summary>
public class GeneralJournalFormBAL
{
    GeneralJournalFormDAL generalJournalFormDAL = new GeneralJournalFormDAL();

	public GeneralJournalFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetSerialNoGeneralJournal()
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalFormDAL.GetSerialNoGeneralJournal();
        return dtb;
    }
    public int UpdatePostingGeneralJournal(GeneralJournalFormUI generalJournalFormUI)
    {
        int resutl = 0;
        resutl = generalJournalFormDAL.UpdatePostingGeneralJournal(generalJournalFormUI);
        return resutl;
    }


    public DataTable GetGeneralJournalListById(GeneralJournalFormUI generalJournalFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalFormDAL.GetGeneralJournalListById(generalJournalFormUI);
        return dtb;
    }

    public int AddGeneralJournal(GeneralJournalFormUI generalJournalFormUI)
    {
        int resutl = 0;
        resutl = generalJournalFormDAL.AddGeneralJournal(generalJournalFormUI);
        return resutl;
    }

    public int UpdateGeneralJournal(GeneralJournalFormUI generalJournalFormUI)
    {
        int resutl = 0;
        resutl = generalJournalFormDAL.UpdateGeneralJournal(generalJournalFormUI);
        return resutl;
    }

    public int DeleteGeneralJournal(GeneralJournalFormUI generalJournalFormUI)
    {
        int resutl = 0;
        resutl = generalJournalFormDAL.DeleteGeneralJournal(generalJournalFormUI);
        return resutl;
    }
}