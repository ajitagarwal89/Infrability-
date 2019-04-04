using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfraWebServices
{
    public class LogExceptionUI
    {
        string resourceNameUI = string.Empty;
        string methodNameUI = string.Empty;
        string exceptionDetailsUI = string.Empty;
        string systemUserUI = string.Empty;
        string recordId = string.Empty;


        public string ResourceName
        {
            get { return resourceNameUI; }
            set { resourceNameUI = value; }
        }

        public string MethodName
        {
            get { return methodNameUI; }
            set { methodNameUI = value; }
        }

        public string RecordId
        {
            get { return recordId; }
            set { recordId = value; }
        }

        public string ExceptionDetails
        {
            get { return exceptionDetailsUI; }
            set { exceptionDetailsUI = value; }
        }

        public string SystemUser
        {
            get { return systemUserUI; }
            set { systemUserUI = value; }
        }
    }
}