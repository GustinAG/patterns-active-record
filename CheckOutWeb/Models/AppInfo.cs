using System.Reflection;
using System.Web;

namespace ActiveRecord.CheckOutWeb.Models
{
    public class AppInfo
    {
        private static readonly Assembly EntryAssembly = GetWebEntryAssembly() ?? Assembly.GetExecutingAssembly();

        public string Name { get; } = EntryAssembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
        public string Title { get; } = EntryAssembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
        public string CompanyName { get; } = EntryAssembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company;
        public string Copyright { get; } = EntryAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;

        // Based on: http://stackoverflow.com/questions/4277692/getentryassembly-for-web-applications
        private static Assembly GetWebEntryAssembly()
        {
            if (HttpContext.Current == null || HttpContext.Current.ApplicationInstance == null) return null;

            var type = HttpContext.Current.ApplicationInstance.GetType();
            while (type != null && type.Namespace == "ASP") type = type.BaseType;

            return type?.Assembly;
        }
    }
}