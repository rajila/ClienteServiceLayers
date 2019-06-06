using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class WebServiceL
    {
        public string getMessage(string msn)
        {
            WebServiceLibrary.WebServiceAegon _service = new WebServiceLibrary.WebServiceAegon();
            return _service.getMessage(msn);
        }

        public int suma(int x, int y)
        {
            WebServiceLibrary.WebServiceAegon _service = new WebServiceLibrary.WebServiceAegon();
            return _service.suma(x,y);
        }
    }
}