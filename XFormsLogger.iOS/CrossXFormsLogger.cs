using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFormsLogger.Abstractions;

namespace XFormsLogger
{
   public class CrossXFormsLogger
    {
        static Lazy<IXFormsLogger> Implementation = new Lazy<IXFormsLogger>(() => CreateSimpleLogger(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Logged instance
        /// </summary>
        public static IXFormsLogger Current
        {
            get
            {
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        static IXFormsLogger CreateSimpleLogger()
        {
#if PORTABLE
        return null;
#else
            return new XFormsLogger();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
