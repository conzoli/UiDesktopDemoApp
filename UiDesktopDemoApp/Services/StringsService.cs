using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace UiDesktopDemoApp.Services
{
    public class StringsService : IStringsService
    {

        private readonly ResourceManager _rm;

        public StringsService()
        {
            _rm = new ResourceManager("UiDesktopDemoApp.Resources.Strings", Assembly.GetExecutingAssembly());
        }

        public string GetString(string key)
        {
             
            if( _rm != null)
            {

                var result = _rm.GetString(key);

                if( result != null )
                {
                    return result;
                }

            }

            return string.Empty;

        }
    }
}
