using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceWeb
{
    public class WebServiceAegon
    {
        public string getMessage(string msn)
        {
            ServiceReferenceTwo.ServiceOneClient _service = new ServiceReferenceTwo.ServiceOneClient();
            return _service.getMessage(msn).ToString();
        }
    }
}