using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccountConfigurationSettingsListUI
/// </summary>
public class GLAccountConfigurationSettingsListUI
{
    public GLAccountConfigurationSettingsListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_GLAccountConfigurationSettingsId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_GLAccountId_RetainedEarning { get; set; }

    public Boolean PostingToHistory { get; set; }

    public Boolean DeletionOfSavedTransaction { get; set; }

    public string Search { get; set; }
}