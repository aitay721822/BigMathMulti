using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigS
{
    public class BigMath
    {
        public string BigMulti(string Multiplicative, long Multiplier)
        {
            List<string> Str = ToStringArray(Multiplicative).ToList<string>();
            Str.Reverse();
            for (int i = 0; i < Str.Count; i++)
                Str[i] = (Convert.ToInt64(Str[i].ToString()) * Multiplier).ToString();
            while (!CheckIsAllFine(Str))
                for (int j = 0; j < Str.Count; j++)
                {
                    if (Str[Str.Count - 1].Length > 1) Str.Add("0");
                    if (j + 1 < Str.Count)
                        Str[j + 1] = (Convert.ToInt64(Str[j + 1]) + Convert.ToInt64(Str[j]) / 10).ToString();
                    Str[j] = (Convert.ToInt64(Str[j]) % 10).ToString();
                    if (CheckIsAllFine(Str)) break;
                }
            string result = string.Empty;
            for (int i = Str.Count - 1; i >= 0; i--)
                result += Str[i];
            return result;
        }

        public string[] ToStringArray(string Str)
        {
            String[] Array = new String[Str.Length];
            for (int i = 0; i < Array.Length; i++)
                Array[i] = Str[i].ToString();
            return Array;
        }

        private bool CheckIsAllFine(List<string> Str)
        {
            for (int i = 0; i < Str.Count; i++)
                if (Str[i].Length != 1) return false;
            return true;
        }
    }
}
