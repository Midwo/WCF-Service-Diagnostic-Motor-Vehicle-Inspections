using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Web;

namespace WCFservice_diagnostic
{

    [DataContract]
    public class ContractIServiceSendEmailOrder
    {
        string body;
        string priority;
        DateTime dateNecessary;
        string who;

        [DataMember]
        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        [DataMember]
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        [DataMember]
        public DateTime DateNecessary
        {
            get { return dateNecessary; }
            set { dateNecessary = value; }
        }
        [DataMember]
        public string Who
        {
            get { return who; }
            set { who = value; }
        }

    }
}