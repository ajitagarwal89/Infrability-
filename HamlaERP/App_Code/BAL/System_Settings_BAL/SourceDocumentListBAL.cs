using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SourceDocumentListBLL
/// </summary>
public class SourceDocumentListBAL
{
    SourceDocumentListDAL sourceDocumentListDAL = new SourceDocumentListDAL();

	public SourceDocumentListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSourceDocumentList()
    {
        DataTable dtb = new DataTable();
        dtb = sourceDocumentListDAL.GetSourceDocumentList();
        return dtb;
    }
    public DataTable GetSourceDocumentListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = sourceDocumentListDAL.GetSourceDocumentListForExportToExcel();
        return dtb;
    }

    public DataTable GetSourceDocumentListById(SourceDocumentListUI sourceDocumentListUI)
    {
        DataTable dtb = new DataTable();
        dtb = sourceDocumentListDAL.GetSourceDocumentListById(sourceDocumentListUI);
        return dtb;
    }

    public DataTable GetSourceDocumentListBySearchParameters(SourceDocumentListUI sourceDocumentListUI)
    {
        DataTable dtb = new DataTable();
        dtb = sourceDocumentListDAL.GetSourceDocumentListBySearchParameters(sourceDocumentListUI);
        return dtb;
    }

    public int DeleteSourceDocument(SourceDocumentListUI sourceDocumentListUI)
    {
        int result = 0;
        result = sourceDocumentListDAL.DeleteSourceDocument(sourceDocumentListUI);
        return result;
    }
}