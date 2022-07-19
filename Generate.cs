using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Generate
    {
        public static Guid GetGuid()
        {
            //Global Unique Identifier: GUID, UUID
            return Guid.NewGuid();
        }

        
    }
}
