using System.IO;
using System.Threading;
using System.Web.Hosting;

namespace Acme.Feature.Promotion
{
    /// <summary>
    /// Load  xml file and create dynamic xml object
    /// </summary>
    public class ConfigHelper
    {
        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();

        public static dynamic GetModuleConfig(string moduleName)
        {
            string path = HostingEnvironment.MapPath(string.Format("~/Config_Data/{0}.xml", moduleName));
            return GetConfig(path);
        }

        /// <summary>
        /// Create dynamic xml object from xml file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static dynamic GetConfig(string path)
        {
            Lock.EnterReadLock();

            try
            {
                string content = File.ReadAllText(path);
                return new DynamicXml(content);
            }
            finally
            {
                Lock.ExitReadLock();
            }
        }
    }
}