using System;
using Microsoft.SharePoint.Administration;

namespace ULS_Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            SPDiagnosticsService.Local.WriteTrace(1234, 
                            new SPDiagnosticsCategory("CSU-Dev", TraceSeverity.High, EventSeverity.Error), 
                            TraceSeverity.High, 
                            "This is an example of a custom ULS log, created at {0}", DateTime.Now.ToShortTimeString());
        }
    }
}
