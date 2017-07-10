using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CommentsFormBAL
/// </summary>
public class CommentsFormBAL
{
    CommentsFormDAL commentsFormDAL = new CommentsFormDAL();
    public CommentsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCommentsListById(CommentsFormUI commentsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = commentsFormDAL.GetCommentsListById(commentsFormUI);
        return dtb;
    }

    public int AddComments(CommentsFormUI commentsFormUI)
    {
        int resutl = 0;
        resutl = commentsFormDAL.AddComments(commentsFormUI);
        return resutl;
    }

    public int UpdateComments(CommentsFormUI commentsFormUI)
    {
        int resutl = 0;
        resutl = commentsFormDAL.UpdateComments(commentsFormUI);
        return resutl;
    }

    public int DeleteComments(CommentsFormUI commentsFormUI)
    {
        int resutl = 0;
        resutl = commentsFormDAL.DeleteComments(commentsFormUI);
        return resutl;
    }

}