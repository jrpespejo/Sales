﻿
namespace Sales.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string tokenType = "TokenType";
        private const string accesToken = "AccesToken";
        private const string isRemembered = "IsRemembered";
        private const string userASP = "UserASP";
        private static readonly string stringDefault = string.Empty;
        private static readonly bool booleanDefault = false;
        #endregion

        public static string UserASP
        {
            get
            {
                return AppSettings.GetValueOrDefault(userASP, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(userASP, value);
            }
        }
        public static string TokenType
        {
            get
            {
                return AppSettings.GetValueOrDefault(tokenType, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(tokenType, value);
            }
        }

        public static string AccesToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(accesToken, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(accesToken, value);
            }
        }
        public static bool IsRemembered
        {
            get
            {
                return AppSettings.GetValueOrDefault(isRemembered, booleanDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(isRemembered, value);
            }
        }


    }
}
