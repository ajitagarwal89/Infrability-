using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for SerializeInputParameters
/// </summary>
public class SerializeInputParameters
{
    public SerializeInputParameters()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string GetSerializedString(object obj)
    {     

        return new JavaScriptSerializer().Serialize(obj);

    }
}