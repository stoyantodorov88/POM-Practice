using AutoFixture;


namespace AutomatedTesting
{
    public static class UserFactory
    {
        public static UserRegProp CreateUser() 
        {
            var fixture = new Fixture();

            return new UserRegProp
            {
                FirstName = fixture.Create<string>().Substring(0, 7),
                Password = fixture.Create<string>(),
                Email = fixture.Create<string>()
            };
        }
        
    }
}
