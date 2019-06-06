using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class WebServiceW
    {
        public string getMessage(string msn)
        {
            WebServiceWeb.WebServiceAegon _service = new WebServiceWeb.WebServiceAegon();
            return _service.getMessage(msn);
        }
    }
}
