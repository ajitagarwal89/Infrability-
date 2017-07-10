using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Finware;
using log4net;

public partial class System_Settings_CardForm : PageBase
{
    #region Data Members
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();

    CardFormBAL cardFormBAL = new CardFormBAL();
    CardFormUI cardFormUI = new CardFormUI();
     
    #endregion Data Members

    #region Events
    protected override void Page_Load(object sender, EventArgs e)
    {
         CardFormUI cardFormUI = new CardFormUI();

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CardId"] != null)
            {
              
                cardFormUI.Tbl_CardId = Request.QueryString["CardId"];           
                FillForm(cardFormUI);
                btnSave.Visible = false;
                btnClear.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                lblHeading.Text = "Update Card";
                txtCode.ReadOnly = true;
            }
            else
            {

                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblHeading.Text = "Add New Card";
            }
        }
    }

  

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            cardFormUI.CreatedBy = SessionContext.UserGuid;
            cardFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            cardFormUI.CardCode = txtCode.Text.Trim();
            cardFormUI.CardName = txtCardName.Text.Trim();                  
                       
            if(cardFormBAL.AddCard(cardFormUI)==1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordInsertedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
             
            }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotInsertRecord;
                divError.Visible = true;
                divSuccess.Visible = false;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnSave_Click()";
            logExcpUIobj.ResourceName = "System_Settings_CardForm.CS";
            logExcpUIobj.RecordId = "New Record";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CardForm : btnSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            cardFormUI.ModifiedBy = SessionContext.UserGuid;
            cardFormUI.Tbl_OrganizationId = SessionContext.OrganizationId;
            cardFormUI.Tbl_CardId = Request.QueryString["CardId"];
            cardFormUI.CardCode = txtCode.Text.Trim();
            cardFormUI.CardName = txtCardName.Text.Trim();
            
            if (cardFormBAL.UpdateCard(cardFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordUpdatedSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;
                lblError.Text = Resources.GlobalResource.msgCouldNotUpdateRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnUpdate_Click()";
            logExcpUIobj.ResourceName = "System_Settings_CardForm.CS";
            logExcpUIobj.RecordId = cardFormUI.Tbl_CardId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[System_Settings_CardForm : btnUpdate_Click] An error occured in the processing of Record Id : " + cardFormUI.Tbl_CardId + ".  Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        { cardFormUI.Tbl_CardId = Request.QueryString["CardId"];

            if (cardFormBAL.DeleteCard(cardFormUI) == 1)
            {
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = Resources.GlobalResource.msgRecordDeleteSuccessfully;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
            else
            {
                divError.Visible = true;
                divSuccess.Visible = false;

                lblError.Text = Resources.GlobalResource.msgCouldNotDeleteRecord;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "btnDelete_Click()";
            logExcpUIobj.ResourceName = "System_Settings_CardForm.CS";
            logExcpUIobj.RecordId = cardFormUI.Tbl_CardId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CardForm  : btnDelete_Click] An error occured in the processing of Record Id : " + cardFormUI.Tbl_CardId + ". Details : [" + exp.ToString() + "]");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CardList.aspx");
     
    }
    #endregion Events

    #region Methods

   
    
private void FillForm(CardFormUI cardFormUI)
    {
        try
        {

            DataTable dtb = cardFormBAL.GetCardListById(cardFormUI);

            if (dtb.Rows.Count > 0)
            {
                txtCode.Text = dtb.Rows[0]["CardCode"].ToString();
                txtCardName.Text = dtb.Rows[0]["CardName"].ToString();
                           }
            else
            {
                lblError.Text = Resources.GlobalResource.msgCouldNotLoadData;
                divError.Visible = true;
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "FillForm()";
            logExcpUIobj.ResourceName = "System_Settings_CardForm.CS";
            logExcpUIobj.RecordId = cardFormUI.Tbl_CardId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[System_Settings_CardForm : FillForm] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
        }
    }
    #endregion Methods
}