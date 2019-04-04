using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GeneralJournalDetailsFormBAL
/// </summary>
public class GeneralJournalDetailsFormBAL
{
    GeneralJournalDetailsFormDAL generalJournalDetailsFormDAL = new GeneralJournalDetailsFormDAL();
    public GeneralJournalDetailsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetGeneralJournalListById(GeneralJournalFormUI generalJournalFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalDetailsFormDAL.GetGeneralJournalListById(generalJournalFormUI);
        return dtb;
    }
    public DataTable GetGeneralJournalDetailsListById(GeneralJournalDetailsFormUI generalJournalDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = generalJournalDetailsFormDAL.GetGeneralJournalDetailsListById(generalJournalDetailsFormUI);
        return dtb;
    }

    public int AddGeneralJournalDetails(GeneralJournalDetailsFormUI generalJournalDetailsFormUI)
    {
        int resutl = 0;
        resutl = generalJournalDetailsFormDAL.AddGeneralJournalDetails(generalJournalDetailsFormUI);
        return resutl;
    }

    public int UpdateGeneralJournalDetails(GeneralJournalDetailsFormUI generalJournalDetailsFormUI)
    {
        int resutl = 0;
        resutl = generalJournalDetailsFormDAL.UpdateGeneralJournalDetails(generalJournalDetailsFormUI);
        return resutl;
    }

    public int DeleteGeneralJournalDetails(GeneralJournalDetailsFormUI generalJournalDetailsFormUI)
    {
        int resutl = 0;
        resutl = generalJournalDetailsFormDAL.DeleteGeneralJournalDetails(generalJournalDetailsFormUI);
        return resutl;
    }
}