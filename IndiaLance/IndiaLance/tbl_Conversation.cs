//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndiaLance
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Conversation
    {
        public int ConID { get; set; }
        public string ConnectionIDUser { get; set; }
        public string ConnectionIDAdmin { get; set; }
        public string UserGroup { get; set; }
        public string Msg { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string MsgDate { get; set; }
        public string MsgDuration { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> AdminID { get; set; }
    }
}
