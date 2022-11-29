using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiJuniorProject
{
    internal class Karyawan : Item
    {
        private int _departemenID;
        private string _departemen;

        public string Departemen
        {
            get { return _departemen; }
        }

        public int DepartemenID
        {
            get { return _departemenID; }
        }

        public Karyawan(int id, string name, string departemen, int departemenID) : base(id, name)
        {
            _departemen = departemen;
            _departemenID = departemenID;
        }
    }
}
