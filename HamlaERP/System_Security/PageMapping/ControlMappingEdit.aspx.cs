using System;
using System.Data;
using System.Web.UI;
using Infra.SecuritySystem;

namespace Finware.PageMapping
{
    public partial class ControlMappingEdit : PageBase
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl divContent;
        protected DataSet ds = new DataSet();
        PageControlFormBAL objPageControlFormBAL = new PageControlFormBAL();
        PageControlListBAL objPageControlListBAL = new PageControlListBAL();

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "ControlMapping";
            PageName = "Control Mapping";
            Confirm(btDelete, "Are you sure to delete selected mapping?");
            if (!Page.IsPostBack)
            {
                // ((MasterPage)(Page.Master)).PageTitle(SessionContext.SiteX + " - " + PageName);

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
        protected void btcontrolSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                PageControlFormUI objPageControlFormUI = new PageControlFormUI();
                ParentId = URLMessage.GetParam("PageMapping", -1);
                objPageControlFormUI.PageMapping = ParentId;
                objPageControlFormUI.ControlMappingX = txtControlMappingX.Text.Trim();
                objPageControlFormUI.ControlMappingCode = txtControlMappingCode.Text.Trim();
                objPageControlFormUI.CreatedOn = DateTime.Now;
                //objControlMappingFormUI.updatedOnDate = DateTime.Now;
                //objsecurityProfileFormUI.createdBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";
                //objsecurityProfileFormUI.updatedBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";

                if (objPageControlFormBAL.AddControl(objPageControlFormUI) == -1)
                {
                    //Response.Redirect("OrganizationList.aspx");
                    msgcool.Visible = true;
                    lbsuccess.Text = "A New Control has been added";
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
                //logExcpUIobj.MethodName = "btprofileSave_Click()";
                //logExcpUIobj.ResourceName = "System_Security_SecurityProfileEdit.CS";
                //logExcpUIobj.RecordId = "";
                //logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                //logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                //log.Error("[System_Security_SecurityProfileEditForm : btprofileSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
        protected void btcontrolUpdate_Click(object sender, System.EventArgs e)
        {
            try
            {
                PageControlFormUI objPageControlFormUI = new PageControlFormUI();
                objPageControlFormUI.ControlMappingX = txtControlMappingX.Text.Trim();
                //objControlMappingFormUI.controlMappingCode = txtControlMappingCode.Text.Trim();
                //objControlMappingFormUI.createdOnDate = DateTime.Now;
                objPageControlFormUI.UpdatedOn = DateTime.Now;
                //objsecurityProfileFormUI.createdBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";
                //objsecurityProfileFormUI.updatedBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";

                if (objPageControlFormBAL.UpdateControl(objPageControlFormUI, RowId = URLMessage.GetParam(PageCode, 0)) == -1)
                {
                    //Response.Redirect("OrganizationList.aspx");
                    msgcool.Visible = true;
                    lbsuccess.Text = "Control has been updated";
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
                //logExcpUIobj.MethodName = "btprofileSave_Click()";
                //logExcpUIobj.ResourceName = "System_Security_SecurityProfileEdit.CS";
                //logExcpUIobj.RecordId = "";
                //logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                //logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                //log.Error("[System_Security_SecurityProfileEditForm : btprofileSave_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
        protected void btdeleteControl_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (objPageControlFormBAL.DeleteControl(RowId = URLMessage.GetParam(PageCode, 0)) == -1)
                {
                    //Response.Redirect("OrganizationList.aspx");
                    msgcool.Visible = true;
                    lbsuccess.Text = "Control has been deleted";
                    txtControlMappingCode.Visible = false;
                    txtControlMappingX.Visible = false;
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
                //logExcpUIobj.MethodName = "btprofileUpdate_Click()";
                //logExcpUIobj.ResourceName = "System_Security_SecurityProfileEdit.CS";
                //logExcpUIobj.RecordId = "";
                //logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                //logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                //log.Error("[System_Security_SecurityProfileEditForm : btprofileUpdate_Click] An error occured in the processing of Record Details : [" + exp.ToString() + "]");
            }
        }
        private void PrepCreate()
        {
            lblPageName.Text = "Add New Control";
            btDelete.Visible = false;
            btUpdate.Visible = false;
            txtControlMappingCode.Enabled = true;
            RowId = int.MinValue;
            ParentId = URLMessage.GetParam("PageMapping", -1);
        }

        private void PrepUpdate()
        {
            btDelete.Visible = true;
            btnclear.Visible = false;
            btSave.Visible = false;

            DataTable dtb = new DataTable();
            RowId = URLMessage.GetParam("ControlMapping", 0);

            dtb = objPageControlListBAL.getPageControl(RowId);

            if (dtb.Rows.Count > 0)
            {
                ParentId = (int)dtb.Rows[0]["PageMapping"];
                txtControlMappingX.Text = dtb.Rows[0]["ControlMappingX"].ToString();
                txtControlMappingCode.Text = dtb.Rows[0]["ControlMappingCode"].ToString();
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
            Response.Redirect("PageMappingView.aspx?" + URLMessage.Encrypt("PageMapping=" + ParentId));
        }
    }
}
