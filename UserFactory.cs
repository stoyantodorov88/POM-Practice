using AutoFixture;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice
{
    public static class UserFactory
    {

        public static UserRegProp GetValidUser() 
        {
            var fixture = new Fixture();
            var dateTime = fixture.Create<DateTime>();

            return new UserRegProp
            {
                
                FirstName = fixture.Create<string>(),
                LastName = fixture.Create<string>(),
                Email = fixture.Create<string>(),
<<<<<<< HEAD
                Gender = "Female again",
=======
                Gender = "Neutral",
>>>>>>> 88c176efe76301da7bdbb288fea2bf15a40fce72
                Phone = fixture.Create<int>(),
                Day = dateTime.Date.ToString(),
                Month = dateTime.Month.ToString(),
                Year = dateTime.Year.ToString(),
            };
        }
       
    }
}
