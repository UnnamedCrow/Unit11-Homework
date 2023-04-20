using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit11_Homework.Services
{
    internal class Length
    {
        private string _message;

        public Length(string message)
        {
            _message= message;
        }

        public int GetLength()
        {
            return _message.Length;
        }
    }
}
