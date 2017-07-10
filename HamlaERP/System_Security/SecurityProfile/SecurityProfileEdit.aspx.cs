using System;
using System.Data;
using System.Web.UI;
using Infra.SecuritySystem;

namespace Finware.SecurityProfile
{
    public partial class SecurityProfileEdit : PageBase
    {
        protected DataSet ds = new DataSet();
        SecurityProfileFormBAL objSecurityProfileFormBAL = new SecurityProfileFormBAL();
        SecurityProfileListBAL objSecurityProfileListBAL = new SecurityProfileListBAL();

        protected new void Page_Load(object sender, System.EventArgs e)
        {

            PageCode = "SecurityProfile";
            PageName = "Security Profile";
            Confirm(btDelete, "Are you sure you want to delete this Security Profile?");
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
        protected void btprofileSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                SecurityProfileFormUI objsecurityProfileFormUI = new SecurityProfileFormUI();
                objsecurityProfileFormUI.SecurityProfileX = txtSecurityProfileX.Text.Trim();
                objsecurityProfileFormUI.CreatedOn = DateTime.Now;
                objsecurityProfileFormUI.UpdatedOn = DateTime.Now;
                //objsecurityProfileFormUI.createdBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";
                //objsecurityProfileFormUI.updatedBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";
                int newProfileId = 0;

                if (objSecurityProfileFormBAL.AddSecurityProfile(objsecurityProfileFormUI, ref newProfileId) == -1)
                {
                    ProfileId.Value = newProfileId.ToString();
                    ProfileName.Value = txtSecurityProfileX.Text;
                    msgcool.Visible = true;
                    lbsuccess.Text = "A New Profile has been added";
                    btnManageProfile.Visible = true;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                }
                else
                {
                    lbmsg.Text = "Could not process the request, Please try again";
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
        protected void btprofileUpdate_Click(object sender, System.EventArgs e)
        {
            try
            {
                SecurityProfileFormUI objsecurityProfileFormUI = new SecurityProfileFormUI();
                objsecurityProfileFormUI.SecurityProfileX = txtSecurityProfileX.Text.Trim();
                objsecurityProfileFormUI.UpdatedOn = DateTime.Now;
                //objsecurityProfileFormUI.createdBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";
                //objsecurityProfileFormUI.updatedBySystemUser = "C7DB2836-2853-47F3-964F-52E4F4852CA6";

                if (objSecurityProfileFormBAL.UpdateSecurityProfile(objsecurityProfileFormUI, RowId = URLMessage.GetParam(PageCode, 0)) == -1)
                {
                    //Response.Redirect("Organisation.aspx");
                    msgcool.Visible = true;
                    lbsuccess.Text = "Profile name has been updated";
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
                }
                else
                {
                    lbmsg.Text = "Could not process the request, Please try again";
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
            lblSearchHeaderText.Text = "Add New Security Profile";
            btDelete.Visible = false;
            btnclear.Visible = true;
            btUpdate.Visible = false;
        }

        private void PrepUpdate()
        {
            btDelete.Visible = true;
            btnclear.Visible = false;
            btSave.Visible = false;

            DataTable dtb = new DataTable();
            RowId = URLMessage.GetParam(PageCode, 0);
            dtb = objSecurityProfileListBAL.GetSecurityProfile(RowId);

            if (dtb.Rows.Count > 0)
            {
                txtSecurityProfileX.Text = dtb.Rows[0]["SecurityProfileX"].ToString();
            }
            else
            {
                msgalert.Visible = true;
                lbmsg.Text = "Could not process the request, Please try again";
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


        protected void btnManageProfile_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../PageMapping/RolePageMappingList.aspx?" + URLMessage.Encrypt("SecurityProfile = " + ProfileId.Value + " & Name = " + ProfileName.Value));
        }
        protected void btnProfileList_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../SecurityProfile/SecurityProfileList.aspx");
        }
        protected void btprofileDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (objSecurityProfileFormBAL.DeleteSecurityProfile(RowId = URLMessage.GetParam(PageCode, 0)) == -1)
                {
                    //Response.Redirect("Organisation.aspx");
                    msgcool.Visible = true;
                    lbsuccess.Text = "Profile name has been deleted";
                    txtSecurityProfileX.Visible = false;
                }
                else
                {
                    lbmsg.Text = "Could not process the request, Please try again";
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
    }
}
