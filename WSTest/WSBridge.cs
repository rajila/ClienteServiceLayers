using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSTest
{
    public class WSBridge
    {
        public string getMessage(string msn)
        {
            // Llamar al servicio One
            ServiceReferenceGeneral.ServiceGeneralClient _service = new ServiceReferenceGeneral.ServiceGeneralClient();
            return _service.GetData(1);
        }
    }
}
