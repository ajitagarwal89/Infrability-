using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CommentsListBAL
/// </summary>
public class CommentsListBAL
{
    CommentsListDAL commentsListDAL = new CommentsListDAL();

    public CommentsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetCommentsList()
    {
        DataTable dtb = new DataTable();
        dtb = commentsListDAL.GetCommentsList();
        return dtb;
    }
    public DataTable GetCommentsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = commentsListDAL.GetCommentsListForExportToExcel();
        return dtb;
    }
    public DataTable GetCommentsListById(CommentsListUI commentsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = commentsListDAL.GetCommentsListById(commentsListUI);
        return dtb;
    }

    public DataTable GetCommentsListBySearchParameters(CommentsListUI commentsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = commentsListDAL.GetCommentsListBySearchParameters(commentsListUI);
        return dtb;
    }

    public int DeleteComments(CommentsListUI commentsListUI)
    {
        int result = 0;
        result = commentsListDAL.DeleteComments(commentsListUI);
        return result;
    }
}