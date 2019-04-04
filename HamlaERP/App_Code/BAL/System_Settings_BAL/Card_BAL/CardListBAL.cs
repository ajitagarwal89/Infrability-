using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CardList
/// </summary>
public class CardListBAL
{
    CardListDAL cardListDAL = new CardListDAL();

	public CardListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCardList()
    {
        DataTable dtb = new DataTable();
        dtb = cardListDAL.GetCardList();
        return dtb;
    }
    public DataTable GetCardListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = cardListDAL.GetCardListForExportToExcel();
        return dtb;
    }
    public DataTable GetCardListById(CardListUI cardListUI)
    {
        DataTable dtb = new DataTable();
        dtb = cardListDAL.GetCardListById(cardListUI);
        return dtb;
    }

    public DataTable GetCardListBySearchParameters(CardListUI cardListUI)
    {
        DataTable dtb = new DataTable();
        dtb = cardListDAL.GetCardListBySearchParameters(cardListUI);
        return dtb;
    }

    public int DeleteCard(CardListUI cardListUI)
    {
        int result = 0;
        result = cardListDAL.DeleteCard(cardListUI);
        return result;
    }
}