using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceLibrary
{
    public class WebServiceAegon
    {
        public string getMessage(string msn)
        {
            ServiceReferenceOne.ServiceOneClient _service = new ServiceReferenceOne.ServiceOneClient();
            return _service.getMessage(msn).ToString();
        }

        public int suma(int x, int y)
        {
            ServiceReferenceOne.ServiceOneClient _service = new ServiceReferenceOne.ServiceOneClient();
            return _service.add(x,y);
        }
    }
}