using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace WebAPI.Models
{
    public class Mytest
    {
        public string id { set; get; }

        private string Generate_CheckBit(string ID)
        {
            StringBuilder str = new StringBuilder("");
            string idx = ID;
            int add_odd = 0;
            int add_digitIn_3 = 0;
            int result_odd_plus_even = 0;
            int length = idx.Length;
            string element = "";

            for (int i = 0; i < ID.Length; i++)
            {
                if (i % 2 == 0)
                {
                    element = ID.ElementAt(i).ToString();
                    add_odd += Convert.ToInt32(element);
                }
                else
                    str.Append(ID.ElementAt(i));
            }

            int even_position = Convert.ToInt32(str.ToString()) * 2;
            string even_postion_s3 = "" + even_position;

            for (int j = 0; j < even_postion_s3.Length; j++)
            {
                add_digitIn_3 += Convert.ToInt16(even_postion_s3.ElementAt(j).ToString());
            }

            result_odd_plus_even = add_digitIn_3 + add_odd;
            string result_to_string = "" + result_odd_plus_even;

            int final_result = 10 - Convert.ToInt16(result_to_string.ElementAt(result_to_string.Length - 1).ToString());



            return lastPart(final_result.ToString());
        }

        public bool Validate(string ID)
        {

            string bit = ID.ElementAt(ID.Length - 1).ToString(); 
            string rest = ID.Substring(0, ID.Length - 1);

            if (bit.Equals(Generate_CheckBit(rest)))
            {
                return true;
            }
            else
                return false;

        }
        private string lastPart(string result)
        {
            string ffn = result;

            if (ffn.Length >= 2)
            {
                return ffn.ElementAt(1).ToString();
            }
            else
                return ffn;




        }

    }
}