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
                Gender = "Neutral",
                Phone = fixture.Create<int>(),
                Day = dateTime.Date.ToString(),
                Month = dateTime.Month.ToString(),
                Year = dateTime.Year.ToString(),
            };
        }
       
    }
}
