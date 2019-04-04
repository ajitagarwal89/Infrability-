using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CardForm
/// </summary>
public class CardFormBAL
{
    CardFormDAL cardFormDAL = new CardFormDAL();

	public CardFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCardListById(CardFormUI cardFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = cardFormDAL.GetCardListById(cardFormUI);
        return dtb;
    }

    public int AddCard(CardFormUI cardFormUI)
    {
        int resutl = 0;
        resutl = cardFormDAL.AddCard(cardFormUI);
        return resutl;
    }

    public int UpdateCard(CardFormUI cardFormUI)
    {
        int resutl = 0;
        resutl = cardFormDAL.UpdateCard(cardFormUI);
        return resutl;
    }

    public int DeleteCard(CardFormUI cardFormUI)
    {
        int resutl = 0;
        resutl = cardFormDAL.DeleteCard(cardFormUI);
        return resutl;
    }
}