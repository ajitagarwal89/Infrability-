using System;
using System.Data;
using System.Web.UI;
using Infra.SecuritySystem;

namespace Finware.PageMapping
{
    public partial class PageMappingEdit : PageBase
    {
        PageFormBAL objPageFormBAL = new PageFormBAL();
        PageListBAL objPageListBAL = new PageListBAL();
        protected DataSet ds = new DataSet();
        LogExceptionUI logExcpUIobj = new LogExceptionUI();
        LogException logExcpDALobj = new LogException();

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "PageMapping";
            PageName = "Page Mapping";
            Confirm(btDelete, "Are you sure to delete the page mapping?");
            if (!Page.IsPostBack)
            {
                switch (URLMessage.URLAction)
                {

                    case URLAction.create:
                        PrepCreate();
                        break;
                    case URLAction.update:
                        PrepUpdate();
                        break;
                    case URLAction.delete:
                        break;
                }
            }
        }
        protected void btpageSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                PageFormUI objPageFormUI = new PageFormUI();
                objPageFormUI.PageMappingX = txtPageMappingX.Text.Trim();
                //objPageMappingFormUI.PageMappingXX = txtPageMappingXX.Text.Trim();
                objPageFormUI.CreatedOn = DateTime.Now;
                objPageFormUI.UpdatedOn = DateTime.Now;
                //objsecurityProfileFormUI.createdBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";
                //objsecurityProfileFormUI.updatedBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";

                if (objPageFormBAL.AddPage(objPageFormUI) == -1)
                {
                    //Response.Redirect("OrganizationList.aspx");
                    msgcool.Visible = true;
                    lbsuccess.Text = "A New Page has been added";
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                }
                else
                {
                    lblMsg.Text = "Could not process the request, Please try again";
                    msgalert.Visible = true;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "btprofileSave_Click()";
                logExcpUIobj.ResourceName = "System_Security_SecurityProfileEdit.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                //log.Error("[System_Security_SecurityProfileEditForm : btprofileSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }

        protected void btpageUpdate_Click(object sender, System.EventArgs e)
        {
            try
            {
                PageFormUI objPageFormUI = new PageFormUI();
                objPageFormUI.PageMappingX = txtPageMappingX.Text.Trim();
                objPageFormUI.UpdatedOn = DateTime.Now;
                //objsecurityProfileFormUI.createdBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";
                //objsecurityProfileFormUI.updatedBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";

                if (objPageFormBAL.UpdatePage(objPageFormUI, RowId = URLMessage.GetParam(PageCode, 0)) == -1)
                {
                    //Response.Redirect("OrganizationList.aspx");
                    msgcool.Visible = true;
                    lbsuccess.Text = "Profile name has been updated";
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                }
                else
                {
                    lblMsg.Text = "Could not process the request, Please try again";
                    msgalert.Visible = true;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "btprofileUpdate_Click()";
                logExcpUIobj.ResourceName = "System_Security_SecurityProfileEdit.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                //log.Error("[System_Security_SecurityProfileEditForm : btprofileUpdate_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }

        private void PrepCreate()
        {
            lblSearchHeaderText.Text = "Add New Page";
            btUpdate.Visible = false;
            btDelete.Visible = false;
            RowId = int.MinValue;
        }

        private void PrepUpdate()
        {
            lblSearchHeaderText.Text = "Edit Page";
            btnclear.Visible = false;
            btSave.Visible = false;
            RowId = URLMessage.GetParam(PageCode, 0);
            DataTable dtb = new DataTable();
            RowId = URLMessage.GetParam(PageCode, 0);
            dtb = objPageListBAL.GetPage(RowId);

            if (dtb.Rows.Count > 0)
            {
                txtPageMappingX.Text = dtb.Rows[0]["PageName"].ToString();
            }
            else
            {
                msgalert.Visible = true;
                lblMsg.Text = "Could not process the request, Please try again";
            }
        }


        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        protected void btnBack_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(PageCode + "List.aspx");
        }

        protected void btpageDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (objPageFormBAL.DeletePage(RowId) == -1)
                {
                    //Response.Redirect("Organisation.aspx");
                    msgcool.Visible = true;
                    lbsuccess.Text = "Page name has been deleted";
                    txtPageMappingX.Visible = false;
                }
                else
                {
                    lblMsg.Text = "Could not process the request, Please try again";
                    msgalert.Visible = true;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "btprofileUpdate_Click()";
                logExcpUIobj.ResourceName = "System_Security_SecurityProfileEdit.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                //log.Error("[System_Security_SecurityProfileEditForm : btprofileUpdate_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
    }
}
