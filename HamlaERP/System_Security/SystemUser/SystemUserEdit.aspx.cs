using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Infra.SecuritySystem;

namespace Finware
{
    public partial class SystemUserEdit : PageBase
    {
        EncryptDecrypt ED = new EncryptDecrypt();
        UserProfileFormBAL objUserProfileFormBAL = new UserProfileFormBAL();
        SystemUserListBAL objSystemUserListBAL = new SystemUserListBAL();
        UserRolesBAL objUserRolesBAL = new UserRolesBAL();
        UserProfileFormUI objUserProfileFormUI = new UserProfileFormUI();

        protected DataSet ds = new DataSet();
        string Password = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            PageCode = "SystemUser";
            PageName = "System User";
            msgcool.Visible = false;
            msgalert.Visible = false;
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
                    default:
                        PrepCreate();
                        break;
                }
            }
        }
        private void FillRoles() //new and edit
        {
            DataTable dtb = objUserRolesBAL.GetRoles();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                grdPage.DataSource = dtb;
                grdPage.DataBind();
            }
            else
            {
                divNoRolesFound.Visible = true;
            }
        }

        private void PrepCreate()
        {
            lbHeaderText.Text = "Add New User";
            GetOrgInfo();
            txtPassword.Visible = true;
            lblPassword.Visible = true;
            lblLastLogin.Visible = false;
            lblLastLoginResult.Visible = false;
            btSave.Visible = true;
            btnClear.Visible = true;
            btDelete.Visible = false;
            btRoles.Visible = false;
            btUpdate.Visible = false;
            txtFailedLoginCount.Text = "0";
        }
        public void GetOrgInfo()
        {
            DataTable dtb = objUserProfileFormBAL.GetOrganisation();
            if (dtb.Rows.Count > 0 && dtb != null)
            {
                drpOrgCode.DataSource = dtb;
                drpOrgCode.DataValueField = "tbl_OrganizationId";
                drpOrgCode.DataTextField = "Name";
                drpOrgCode.DataBind();
                drpOrgCode.Items.Insert(0, new ListItem("Select", "-1"));
            }
            else
            {
                drpOrgCode.Enabled = false;
            }
        }

        protected void btAddUser_Click(object sender, EventArgs e)
        {

            if (chkIsActive.Checked == true)
            {
                objUserProfileFormUI.IsActive = 0;
            }
            else
            {
                objUserProfileFormUI.IsActive = 1;
            }
            objUserProfileFormUI.IsLocked = 0;
            objUserProfileFormUI.IsDeleted = 0;
            objUserProfileFormUI.FailedLoginCount = Convert.ToInt32(txtFailedLoginCount.Text.Trim());
            objUserProfileFormUI.UserId = txtUserId.Text.Trim();
            objUserProfileFormUI.Password = ED.base64Encode(txtPassword.Text);
            objUserProfileFormUI.Email = txtEmailAddress.Text.Trim();
            objUserProfileFormUI.FirstName = txtFirstName.Text.Trim();
            objUserProfileFormUI.LastName = txtLastName.Text.Trim();
            objUserProfileFormUI.Phone = txtCellPhone.Text.Trim();
            objUserProfileFormUI.OrganizationCode = drpOrgCode.SelectedValue;
            objUserProfileFormUI.Department = 1;
            objUserProfileFormUI.DateofBirth = txtDateOfBirth.Text.Trim();
            objUserProfileFormUI.DateofJoining = DateTime.Now;
            objUserProfileFormUI.PermanentAddress = txtPermanentAddress.Text.Trim();
            objUserProfileFormUI.CorrespondenceAddress = txtCoAddress.Text.Trim();
            objUserProfileFormUI.EducationQualification = txtEduQualification.Text.Trim();
            objUserProfileFormUI.Designation = 1;
            objUserProfileFormUI.CreatedBySystemUser = 1;
            objUserProfileFormUI.CreatedOn = DateTime.Now;
            objUserProfileFormUI.UpdatedOn = DateTime.Now;

            int newUserId = 0;

            if (objUserProfileFormBAL.AddUser(objUserProfileFormUI, ref newUserId) == -1)
            {
                SystemUserId.Value = newUserId.ToString();
                msgcool.Visible = true;
                lblConfirmation.Text = "A New User has been added";
                btUpdate.Visible = true;
                btSave.Visible = false;
                btDelete.Visible = true;
                btRoles.Visible = true;
                txtUserId.Enabled = false;
                txtPassword.Enabled = false;
                lbHeaderText.Text = "Edit System User";
            }
            else
            {
                valDuplicatePassword.Text = "Could not process the request, Please try again";
                msgalert.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        protected void btUpdateUser_Click(object sender, EventArgs e)
        {


            if (chkIsActive.Checked == true)
            {
                objUserProfileFormUI.IsActive = 1;
            }
            else
            {
                objUserProfileFormUI.IsActive = 0;
            }
            objUserProfileFormUI.FailedLoginCount = Convert.ToInt32(txtFailedLoginCount.Text.Trim());
            objUserProfileFormUI.Email = txtEmailAddress.Text.Trim();
            objUserProfileFormUI.FirstName = txtFirstName.Text.Trim();
            objUserProfileFormUI.LastName = txtLastName.Text.Trim();
            objUserProfileFormUI.Phone = txtCellPhone.Text.Trim();
            objUserProfileFormUI.OrganizationCode = drpOrgCode.SelectedValue;
            objUserProfileFormUI.Department = 1;
            objUserProfileFormUI.DateofBirth = txtDateOfBirth.Text.Trim();
            objUserProfileFormUI.DateofJoining = DateTime.Now;
            objUserProfileFormUI.PermanentAddress = txtPermanentAddress.Text.Trim();
            objUserProfileFormUI.CorrespondenceAddress = txtCoAddress.Text.Trim();
            objUserProfileFormUI.EducationQualification = txtEduQualification.Text.Trim();
            objUserProfileFormUI.Designation = 1;
            objUserProfileFormUI.UpdatedOn = DateTime.Now;

            if (objUserProfileFormBAL.UpdateUser(objUserProfileFormUI, Convert.ToInt32(SystemUserId.Value)) == 1)
            {
                msgcool.Visible = true;
                lblConfirmation.Text = "User Details have been Updated";
                btUpdate.Visible = true;
                btSave.Visible = false;
                btDelete.Visible = true;
                btRoles.Visible = true;
                lbHeaderText.Text = "Edit System User";
                GetRoles("update");
            }
            else
            {
                valDuplicatePassword.Text = "Could not process the request, Please try again";
                msgalert.Visible = true;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "clearform", "ClearForm();", true);
            }
        }
        protected void btDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                objUserProfileFormUI.IsDeleted = 1;
                objUserProfileFormUI.DeletedOn = DateTime.Now;


                if (objUserProfileFormBAL.DeleteUser(objUserProfileFormUI, Convert.ToInt32(SystemUserId.Value)) == 1)
                {
                    msgcool.Visible = true;
                    lblConfirmation.Text = "User has been deleted";
                    PrepCreate();
                }
                else
                {
                    valDuplicatePassword.Text = "Could not process the request, Please try again";
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
        protected void btnSaveRole_Click(object sender, EventArgs e)
        {
            UserRolesFormUI objUserRolesFormUI = new UserRolesFormUI();
            objUserRolesBAL.RemoveRoles(Convert.ToInt32(SystemUserId.Value));

            HtmlInputText txt;
            for (int k = 0; k < grdPage.Items.Count; k++)
            {
                txt = (HtmlInputText)grdPage.Items[k].Cells[0].FindControl("chkpro");
                if (txt.Value == "1")
                {
                    string SecurityProfileID = grdPage.Items[k].Cells[0].Text;

                    objUserRolesFormUI.SystemUser = Convert.ToInt32(SystemUserId.Value);
                    objUserRolesFormUI.SecurityProfile = Convert.ToInt32(SecurityProfileID);

                    if (objUserRolesBAL.AddRoles(objUserRolesFormUI) == 1)
                    {
                        msgcool.Visible = true;
                        lblConfirmation.Text = "Role(s) added successfully";
                    }
                    else
                    {
                        msgalert.Visible = true;
                        valDuplicatePassword.Text = "Could not process your request, Please try again";

                    }
                }
            }
            GetRoles("new");
        }
        protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindDesignation();
        }
        private void PrepUpdate()
        {
            SystemUserId.Value = URLMessage.GetParam("SystemUser", 0).ToString();

            btSave.Visible = false;
            btnClear.Visible = false;
            txtUserId.Enabled = false;
            divPassword.Visible = false;
            GetOrgInfo();
            FillRoles();

            DataTable dtb = objSystemUserListBAL.GetUser(Convert.ToInt32(SystemUserId.Value));

            if (dtb.Rows.Count > 0 && dtb != null)
            {
                txtFirstName.Text = dtb.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dtb.Rows[0]["LastName"].ToString();
                txtEmailAddress.Text = dtb.Rows[0]["EmailAddress"].ToString();
                txtCellPhone.Text = dtb.Rows[0]["Phone"].ToString();
                txtEduQualification.Text = dtb.Rows[0]["EducationQaulification"].ToString();
                txtDateOfBirth.Text = dtb.Rows[0]["DateOfBirth"].ToString();
                txtPermanentAddress.Text = dtb.Rows[0]["PermanentAddress"].ToString();
                txtCoAddress.Text = dtb.Rows[0]["CorrespondanceAddress"].ToString();
                txtUserId.Text = dtb.Rows[0]["UserId"].ToString();
                txtPassword.Text = dtb.Rows[0]["Password"].ToString();
                drpOrgCode.SelectedValue = dtb.Rows[0]["OrgCode"].ToString();
                txtFailedLoginCount.Text = dtb.Rows[0]["FailedLoginCount"].ToString();
                if (dtb.Rows[0]["IsActive"].ToString() == "1")
                {
                    chkIsActive.Checked = true;
                }
                GetRoles("exist");
            }
        }

        private void GetRoles(string chk)
        {
            DataTable dtp = objSystemUserListBAL.GetRoles(Convert.ToInt32(SystemUserId.Value));
            if (dtp.Rows.Count > 0 && dtp != null)
            {
                for (int i = 0; i < dtp.Rows.Count; i++)
                {
                    if (chk == "exist")
                    {
                        string jfunc = "selprofile_" + dtp.Rows[i]["SecurityProfile"].ToString() + "(" + dtp.Rows[i]["SecurityProfile"].ToString() + ");";
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "secrole" + i, jfunc, true);
                    }
                    if (chk == "new")
                    {
                        string jfunc = "selprofile_" + dtp.Rows[i]["SecurityProfile"].ToString() + "(" + dtp.Rows[i]["SecurityProfile"].ToString() + ",'new');";
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "secrole" + i, jfunc, true);
                    }
                }
            }
        }
    }
}