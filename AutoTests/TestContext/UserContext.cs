using System;
using System.Collections.Generic;
using Driver_AutoTests.Resources;

namespace Driver_AutoTests.TestContext
{
    public class UserContext
    {
        private readonly Dictionary<object, Dictionary<object, object>> _userDataDictionary = new Dictionary<object, Dictionary<object, object>>();

        private Users _currentUser;

        public void SetCurrentUser(Users userName)
        {
            _currentUser = userName;
        }

        public void AddUserData(object userKey, object newUserKeyData)
        {
            AddUserData(userKey, GetDataKey(newUserKeyData.GetType()), newUserKeyData);
        }

        public void AddUserData(object userKey, object dataKey, object newUserKeyData)
        {
            if (!_userDataDictionary.TryGetValue(userKey, out var userData))
            {
                userData = new Dictionary<object, object>();
                _userDataDictionary[userKey] = userData;
            }

            userData[dataKey] = newUserKeyData;
        }

        public T GetCurrentUserData<T>(object dataKey = null)
        {
            return GetUserData<T>(_currentUser, dataKey);
        }

        public T GetUserData<T>(object userKey, object dataKey = null)
        {
            dataKey = dataKey ?? GetDataKey(typeof(T));

            if (!_userDataDictionary.TryGetValue(userKey, out var userData))
            {
                return default;
            }

            if (userData.TryGetValue(dataKey, out var data))
                return (T)data;

            return default;
        }

        private static string GetDataKey(Type dataType)
        {
            return dataType.FullName;
        }
    }
}
