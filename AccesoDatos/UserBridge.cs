using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class UserBridge : IBridge<Entidades.Entidades.User>
    {
        public List<Entidades.Entidades.User> getAllElements()
        {
            string[] _dataName = new string[6] { "Ronald", "Mary", "Veronica", "Jorge", "Mafer", "Abrahan"};
            string[] _dataSurname = new string[6] { "Ajila", "Conde", "Ortiz", "Cid", "Macías", "Ortega" };
            string[] _dataCountry = new string[6] { "Ecuador", "Spain", "France", "UK", "Italy", "Mexico" };

            List<Entidades.Entidades.User> _dataL = new List<Entidades.Entidades.User>();
            var _seed = Environment.TickCount;
            Random _rnd = new Random(_seed);

            for (int i = 0; i < 500; i++)
            {
                int _numName = _rnd.Next(0, _dataName.Length);
                int _numSurname = _rnd.Next(0, _dataName.Length);
                int _numCountry = _rnd.Next(0, _dataName.Length);
                _dataL.Add(new Entidades.Entidades.User(i, _dataName[_numName], _dataSurname[_numSurname], _dataCountry[_numCountry]));
            }

            return _dataL;
        }
    }
}