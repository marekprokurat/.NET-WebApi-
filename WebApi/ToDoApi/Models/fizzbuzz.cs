using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TodoApi.Models
{
    public class fizzbuzz
    {   
       [Key]
        public string i { get; set; }
        public string ans(string i)
        {
            int ii = int.Parse(i);
           
            
                string g = ii % 6 == 0 ? "Fizz Buzz" : (ii % 2 == 0 ? "Fizz" : (ii % 3 == 0 ? "Buzz" : ii.ToString())); 
                return (g);  
            
           

          /*  if (i >= 0 & i < 1001)
            {
                string g = i % 6 == 0 ? "Fizz Buzz" : (i % 2 == 0 ? "Fizz" : (i % 3 == 0 ? "Buzz" : i.ToString()));
                return (g);
            }
            else
                return ("Numbers out of range. Please input number in range 0-1000\n");*/
        }
    }
}
