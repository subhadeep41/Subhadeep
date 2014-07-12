//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Travelme.Utility
//{
//    public class Resource
//    {
//// ReSharper disable UnusedMember.Global
//        public string Resourcevalues() { 
//// ReSharper restore UnusedMember.Global
//        private new List<string>  // dummy list
//        {
//            "West Bengal",
//            "Maharashtra",
//            "Kerala",
//            "Odissa",
//            "Tamilnadu",
//            "Uttar Pradesh",
//            "Madhya Pradesh",
//            "Rajasthan",
//            "Delhi",
//            "Goa",
//            "Karnataka",
//            "Assam",
//            "Jharkhand",
//            "Bihar",
//            "Uttarakhand",
//            "chatisgarh",
//            "Haryana",
//            "Jammu&Kashmir",
//            "Punjab",
//            "Sikkim",
//            "Mizoram",
//            "Manipal",
//        }

//        public IList<string> GetAllPredictions(string keywordStartsWith)
//        {
//            IList<string> output = (from c in states
//                                    where c.Contains(keywordStartsWith)
//                                    select c).ToList();
//            return output;
//        }
//    }
//}