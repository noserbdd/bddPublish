using System.Collections.Generic;

namespace Driver_AutoTests.Resources
{
    public enum Users
    {
        TestE2E
    }

    public class UserData
    {
        public string Password { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }

    public static class UserRegistry
    {
        private static Dictionary<Users, UserData> userDatas = new Dictionary<Users, UserData> { {Users.TestE2E, new UserData
        {
            Name = "Test User",
            Password = "password",
            Address = "street"
        } } };

        public static UserData GetUserData(Users user)
        {
            return userDatas[user];
        }
    }
}
