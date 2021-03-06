﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class FizzbuzzController : Controller
    {
        // GET: api/fizzbuzz?number=
        [HttpGet]
        public IEnumerable<string> Get()
  
        {
            string number = HttpContext.Request.Query["number"].ToString();
            int num=0;
            string g="";

            if ( !string.IsNullOrEmpty(HttpContext.Request.Query["number"] ) )
                {
                try
                {
                    num = int.Parse(number);
                }
                catch (Exception) 
                {
                    return new string[] { "Niepoprawny format wejsciowy. Podaj liczbe 1-1000" };
                }


                if (num >= 0 && num <= 1000)
                {
                    g = num % 6 == 0 ? "Fizz Buzz" : (num % 2 == 0 ? "Fizz" : (num % 3 == 0 ? "Buzz" : num.ToString()));
                    return new string[] { g };
                }

                else
                {
                    return new string[] { "Niepoprawny zakres. Podaj liczbe 1-1000" };
                }

            }
        
            else
            {
                return new string[] { "Podaj liczbe dodajac do URL ' ?number=x ', gdzie x to liczba do sprawdzenia przez FizzBuzz" };
            }
           
        }

    }
}
