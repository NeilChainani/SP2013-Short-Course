using System;
using Microsoft.SharePoint;

namespace Reading_SharePoint_site_data
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = null;
            try
            {
                site = new SPSite("http://intranet.csu.local");
                Console.WriteLine("Site url: {0}", site.Url);
                Console.WriteLine("Site ID: {0}", site.ID);
                Console.WriteLine("Content database: {0}", site.ContentDatabase.Name);

                Console.WriteLine("");
                Console.WriteLine("List of all webs in the site");
                foreach (SPWeb web in site.AllWebs)
                {
                    Console.WriteLine("{0} ({1})", web.Title, web.Url);
                    web.Dispose();
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.ReadKey();
                if (site != null) site.Dispose();
            }
        }
    }
}
