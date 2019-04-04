using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SourceDocumentFormBLL
/// </summary>
public class SourceDocumentFormBAL
{
    SourceDocumentFormDAL sourceDocumentFormDAL = new SourceDocumentFormDAL();

	public SourceDocumentFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSourceDocumentListById(SourceDocumentFormUI sourceDocumentFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = sourceDocumentFormDAL.GetSourceDocumentListById(sourceDocumentFormUI);
        return dtb;
    }

    public int AddSourceDocument(SourceDocumentFormUI sourceDocumentFormUI)
    {
        int resutl = 0;
        resutl = sourceDocumentFormDAL.AddSourceDocument(sourceDocumentFormUI);
        return resutl;
    }

    public int UpdateSourceDocument(SourceDocumentFormUI sourceDocumentFormUI)
    {
        int resutl = 0;
        resutl = sourceDocumentFormDAL.UpdateSourceDocument(sourceDocumentFormUI);
        return resutl;
    }

    public int DeleteSourceDocument(SourceDocumentFormUI sourceDocumentFormUI)
    {
        int resutl = 0;
        resutl = sourceDocumentFormDAL.DeleteSourceDocument(sourceDocumentFormUI);
        return resutl;
    }
}