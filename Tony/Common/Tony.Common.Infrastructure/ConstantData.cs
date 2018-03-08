using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tony.Common.Infrastructure
{
    public static class ConstantData
    {
        static ConstantData()
        {
            Months = new Dictionary<int, string>
            {
                {1, "JANUARY"},
                {2, "FEBRUARY"},
                {3, "MARCH"},
                {4, "APRIAL"},
                {5, "MAY"},
                {6, "JUNE"},
                {7, "JULY"},
                {8, "AUGUST"},
                {9, "SEPTEMBER"},
                {10, "OCTOBER"},
                {11, "NOVEMBER"},
                {12, "DECEMBER"}
            };

            MonthsShort = new Dictionary<int, string>
            {
                {1, "JAN"},
                {2, "FEB"},
                {3, "MAR"},
                {4, "APR"},
                {5, "MAY"},
                {6, "JUN"},
                {7, "JUY"},
                {8, "AUG"},
                {9, "SEP"},
                {10, "OCT"},
                {11, "NOV"},
                {12, "DEC"}
            };

            MonthsString = new Dictionary<string, int>
            {
                {"JANUARY", 1 },
                {"FEBRUARY", 2 },
                {"MARCH", 3 },
                {"APRIAL", 4 },
                {"MAY", 5 },
                {"JUNE", 6 },
                {"JULY", 7 },
                {"AUGUST", 8 },
                {"SEPTEMBER", 9 },
                {"OCTOBER", 10 },
                {"NOVEMBER", 11 },
                {"DECEMBER", 12 }
            };

            MonthsShortString = new Dictionary<string, int>
            {
                {"JAN", 1 },
                {"FEB", 2 },
                {"MAR", 3 },
                {"APR", 4 },
                {"MAY", 5 },
                {"JUN", 6 },
                {"JUL", 7 },
                {"AUG", 8 },
                {"SEP", 9 },
                {"OCT", 10 },
                {"NOV", 11 },
                {"DEC", 12 }
            };

            MonthColors = new Dictionary<int, string>
            {
                {1, "#A20D13"},
                {2, "#A349A3"},
                {3, "#9AD9EA"},
                {4, "#DBDBE3"},
                {5, "#187936"},
                {6, "#D6BFE9"},
                {7, "#ED1B24"},
                {8, "#AAD917"},
                {9, "#0100FC"},
                {10, "#FE5189"},
                {11, "#FFC90D"},
                {12, "#00A3E8"}
            };

        }

        public const string PARAM_SUITE_ID = "PARAM_SUITE_ID";
        public const string PARAM_DISH_CATEGORY_ID = "PARAM_DISH_CATEGORY_ID";
        public const string PARAM_DEPARTMENT_ID = "PARAM_DEPARTMENT_ID";

        #region ui ass
        public static ObservableCollection<string> GetHours()
        {
            return new ObservableCollection<string> { "00","01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11",
            "12","13", "14","15", "16", "17", "18", "19", "20", "21", "22", "23"};
        }

        public static ObservableCollection<string> GetMunites()
        {
            return new ObservableCollection<string> { "00","01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11",
            "12","13", "14","15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
            "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48",
            "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59"};
        }

        public const string ALL = "ALL";

        public const string NAME = "NAME";

        public const string PHONE = "PHONE NO";

        public const string TAGNO = "TAG NO";

        public const string AROUND = "AROUND";

        public const string GONE = "GONE";
        #endregion

        #region netcom

        #region settings

        #region profile
        public const string SAVE_PROFILE_REQUEST = "SAVE_PROFILE_REQUEST";
        public const string SAVE_PROFILE_REPLY = "SAVE_PROFILE_REPLY";
        
        public const string GET_PROFILE_REQUEST = "GET_PROFILE_REQUEST";
        public const string GET_PROFILE_REPLY = "GET_PROFILE_REPLY";
        #endregion

        #region suite
        public const string ADD_SUITE_REQUEST = "ADD_SUITE_REQUEST";
        public const string ADD_SUITE_REPLY = "ADD_SUITE_REPLY";

        public const string GET_SUITE_REQUEST = "GET_SUITE_REQUEST";
        public const string GET_SUITE_REPLY = "GET_SUITE_REPLY";


        public const string ADD_ROOM_REPLY = "ADD_ROOM_REPLY";
        public const string ADD_ROOM_REQUEST = "ADD_ROOM_REQUEST";

        public const string GET_ROOM_REQUEST = "GET_ROOM_REQUEST";
        public const string GET_ROOM_REPLY = "GET_ROOM_REPLY";
        #endregion

        #region invetory
        public const string SAVE_INVENTORY_REQUEST = "THE_SAVE_INVENTORY_REQUEST";
        public const string SAVE_INVENTORY_REPLY = "THE_SAVE_INVENTORY_REPLY";

        public const string DELETE_INVENTORY_REQUEST = "DELETE_INVENTORY_REQUEST";
        public const string DELETE_INVENTORY_REPLY = "DELETE_INVENTORY_REPLY";

        public const string GET_INVENTORIES_REQUEST = "GET_INVENTORIES_REQUEST";
        public const string GET_INVENTORIES_REPLY = "GET_INVENTORIES_REPLY";
        #endregion

        #region dishes
        public const string SAVE_DISH_CATEGORY_REQUEST = "SAVE_DISH_CATEGORY_REQUEST";
        public const string SAVE_DISH_CATEGORY_REPLY = "SAVE_DISH_CATEGORY_REPLY";

        public const string DELETE_DISH_CATEGORY_REQUEST = "DELETE_DISH_CATEGORY_REQUEST";
        public const string DELETE_DISH_CATEGORY_REPLY = "DELETE_DISH_CATEGORY_REPLY";

        public const string GET_DISH_CATEGORY_REQUEST = "GET_DISH_CATEGORY_REQUEST";
        public const string GET_DISH_CATEGORY_REPLY = "GET_DISH_CATEGORY_REPLY";


        public const string SAVE_DISH_REQUEST = "SAVE_DISH_REQUEST";
        public const string SAVE_DISH_REPLY = "SAVE_DISH_REPLY";

        public const string DELETE_DISH_REQUEST = "DELETE_DISH_REQUEST";
        public const string DELETE_DISH_REPLY = "DELETE_DISH_REPLY";

        public const string GET_DISH_REQUEST = "GET_DISH_REQUEST";
        public const string GET_DISH_REPLY = "GET_DISH_REPLY";
        #endregion

        #region staff
        public const string SAVE_DEPARTMENT_REQUEST = "T_SAVE_DEPT_REQUEST";
        public const string SAVE_DEPARTMENT_REPLY = "T_SAVE_DEPT_REPLY";

        public const string DELETE_DEPARTMENT_REQUEST = "THE_DELETE_DEPARTMENT_REQUEST";
        public const string DELETE_DEPARTMENT_REPLY = "THE_DELETE_DEPARTMENT_REPLY";

        public const string GET_DEPARTMENT_REQUEST = "THE_GET_DEPARTMENT_REQUEST";
        public const string GET_DEPARTMENT_REPLY = "THE_GET_DEPARTMENT_REPLY";


        public const string SAVE_STAFF_REQUEST = "THE_SAVE_STAFF_REQUEST";
        public const string SAVE_STAFF_REPLY = "THE_SAVE_STAFF_REPLY";

        public const string DELETE_STAFF_REQUEST = "THE_DELETE_STAFF_REQUEST";
        public const string DELETE_STAFF_REPLY = "THE_DELETE_STAFF_REPLY";

        public const string GET_STAFF_REQUEST = "THE_GET_STAFF_REQUEST";
        public const string GET_STAFF_REPLY = "THE_GET_STAFF_REPLY";


        #endregion

        #endregion




        #endregion

        #region utilities  
        public static Dictionary<int, string> Months { get; set; }
        public static Dictionary<int, string> MonthsShort { get; set; }
        public static Dictionary<string, int> MonthsString { get; set; }
        public static Dictionary<string, int> MonthsShortString { get; set; }
        public static Dictionary<int, string> MonthColors { get; set; } 
        #endregion
    }
}
