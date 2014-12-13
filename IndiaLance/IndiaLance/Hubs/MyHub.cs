using System;
using System.Collections.Generic;
using System.Linq;
using IndiaLance.Models;
using Microsoft.AspNet.SignalR;

namespace IndiaLance
{
    public class MyHub : Hub
    {
        static List<UserInfo> UsersList = new List<UserInfo>();
        static List<MessageInfo> MessageList = new List<MessageInfo>();

        public void Register(string userName, string password, string email)
        {
            try
            {
                var ctx = new MyDatabase1Entities1();
                Random rnd = new Random();
                int userid = rnd.Next(1000, 100000000);
                tbl_User objtable = new tbl_User();
                objtable.UserID = userid;
                objtable.UserName = userName;
                objtable.Password = password;
                objtable.EmailID = email;
                objtable.AdminCode = 0;
                ctx.tbl_User.Add(objtable);
                ctx.SaveChanges();

                Clients.Caller.register(userName);
            }
            catch(Exception e)
            {
                Clients.Caller.servererror();
            }
        }

        //-->>>>> ***** Receive Request From Client [  Connect  ] *****
        public void Connect(string userName, string password)
        {
            var id = Context.ConnectionId;
            //Manage Hub Class
            //if freeflag==0 ==> Busy
            //if freeflag==1 ==> Free

            //if tpflag==0 ==> User
            //if tpflag==1 ==> Admin
            var ctx = new MyDatabase1Entities1();
            var userInfo =
                 (from m in ctx.tbl_User
                  where m.UserName == userName && m.Password == password
                  select new { m.UserID, m.UserName, m.AdminCode }).FirstOrDefault();
            try
            {
                //now add USER to UsersList
                UsersList.Add(new UserInfo
                {
                    ConnectionId = id,
                    UserID = userInfo.UserID,
                    UserName = userName,
                    UserGroup = "1",
                    freeflag = "0",
                    tpflag = "0",
                });
                //whether it is Admin or User now both of them has userGroup and I Join this user or admin to specific group 
                Groups.Add(Context.ConnectionId, "1");
                Clients.Caller.onConnected(id, userName, userInfo.UserID, "1");
            }
            catch
            {
                Clients.Caller.NoExistAdmin();
            }
        }
        // <<<<<-- ***** Return to Client [  NoExist  ] *****
        //--group ***** Receive Request From Client [  SendMessageToGroup  ] *****
        public void SendMessageToGroup(string userName, string message)
        {
            if (UsersList.Count != 0)
            {
                var strg = (from s in UsersList where (s.UserName == userName) select s).First();
                MessageList.Add(new MessageInfo { UserName = userName, Message = message, UserGroup = strg.UserGroup });
                string strgroup = strg.UserGroup;
                // If you want to Broadcast message to all UsersList use below line
                // Clients.All.getMessages(userName, message);

                //If you want to establish peer to peer connection use below line 
                //so message will be send just for user and admin who are in same group
                //***** Return to Client *****
                Clients.Group(strgroup).getMessages(userName, message);
            }
        }
        // <<<<<-- ***** Return to Client [  getMessages  ] *****

        //--group ***** Receive Request From Client ***** 
        //{ Whenever User close session then OnDisconneced will be occurs }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = UsersList.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                UsersList.Remove(item);

                var id = Context.ConnectionId;

                if (item.tpflag == "0")
                {
                    //user logged off == user
                    try
                    {
                        var stradmin = (from s in UsersList
                                        where
                                            (s.UserGroup == item.UserGroup) && (s.tpflag == "1")
                                        select s).First();
                        //become free
                        stradmin.freeflag = "1";
                    }
                    catch
                    {
                        //***** Return to Client *****
                        Clients.Caller.NoExistAdmin();
                    }
                }

                //save conversation to dat abase
            }

            return base.OnDisconnected(stopCalled);
        }

    }
}