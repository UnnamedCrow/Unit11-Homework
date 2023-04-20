using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit11_Homework.Services
{
    public  class Sum
    {
        private string _message;
        public Sum(string message)
        {
            _message = message;
        }
        public int GetSum()
        {
            int result = 0;
            char[] separtors = " \r\n\"'".ToCharArray(); // Строка сепараторов
            string[] strarr = _message.Split(separtors);
            string[] resultarr = strarr.Where(x => int.TryParse(x, out int _tmp)).ToArray();
            int[] intarr = resultarr.Select(int.Parse).ToArray();
            foreach (int i in intarr)
            {
                result += i;
            }
            return result;
        }
    }
}
