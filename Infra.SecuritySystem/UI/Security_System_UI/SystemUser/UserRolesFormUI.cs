/// <summary>
/// Summary description for UserRolesFormUI
/// </summary>
namespace Infra.SecuritySystem
{
    public class UserRolesFormUI
    {
        public UserRolesFormUI()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        int systemUser;
        int securityProfile;        

        public int SystemUser
        {
            get { return systemUser; }
            set { systemUser = value; }
        }

        public int SecurityProfile
        {
            get { return securityProfile; }
            set { securityProfile = value; }
        }        
    }
}