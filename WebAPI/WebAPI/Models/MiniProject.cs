using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace WebAPI.Models
{
    public class MiniProject
    {
        public string id { set; get; }
        public string Generate_ID()
        {
            StringBuilder SaId = new StringBuilder("");
            string race = ReturnCountry_Race_Gender(8, 10).ToString();
            //this var holds a random number 8 or 9 
            string gender = Verify_Gender(ReturnCountry_Race_Gender(0, 10000).ToString());
            // this var holds a random int between [0-10000[
            string countryId = ReturnCountry_Race_Gender(0, 2).ToString();
            //this var holds a random number 0 or 1 
            Random r = new Random();

            int randomYear = r.Next(1900, 2015); // random year between 1900 and 2015    
            int randomMonthNr = r.Next(1, 13); // randome month betweeb 1 and 12 
            int maxDayNr = DateTime.DaysInMonth(randomYear, randomMonthNr);
            int randomDayNr = r.Next(1, (maxDayNr + 1));
            // generates the day after passing the year and the month

                SaId.Append(randomYear.ToString().ElementAt(2) + "" + randomYear.ToString().ElementAt(3));
                SaId.Append(Make_DayAndMonth_2Char(randomMonthNr.ToString()));
                SaId.Append(Make_DayAndMonth_2Char(randomDayNr.ToString()));
                SaId.Append(gender);
                SaId.Append(countryId);
                SaId.Append(race);
                SaId.Append(Generate_CheckBit(SaId.ToString())); // here i am generating the check bit and append it to the builder 
                //here I am appending the year, the month, the day, gender, countryId, race and the checkbit 


            if (Validate(SaId.ToString()))
                return SaId.ToString();
            else
                return "Invalid SA Id: " + SaId.ToString();


            
        }

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

            int final_result = 10 - Convert.ToInt16(result_to_string.ElementAt(result_to_string.Length-1).ToString());
            


                return lastPart(final_result.ToString());
        }

        public bool Validate(string ID)
        {

            string bit = ID.ElementAt(ID.Length-1).ToString();
            string rest = ID.Substring(0, ID.Length - 1);

            if (bit.Equals(Generate_CheckBit(rest)))
            {
                return true;
            }else
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

        private string Verify_Gender(string gender)
        {
            string t;
            if (gender.Length == 1)
            {
                t = "000";
                t += gender;
            }
            else if (gender.Length == 2)
            {
                t = "00";
                t += gender;
            } if (gender.Length == 3)
            {
                t = "0";
                t += gender;
            }
            else
            {
                t = gender;
            }

            return t;
        }

        private string Make_DayAndMonth_2Char(string value)
        {
            string t = "0";
            if (value.Length == 1)
                t += value;
            else
                t = value;

                return t;
        }

        private int ReturnCountry_Race_Gender(int start, int end){
            Random rand = new Random();
            int x = rand.Next(start, end);
            return x;
        }
    }
}