﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1;

namespace WCFservice_diagnostic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public bool Authentication(string loginNamecrypt, string passwordcrypt)
        {
            Encrypt_decrypt authentication = new Encrypt_decrypt();
            return authentication.Authentication(loginNamecrypt, passwordcrypt);
        }

        //public CarConditionEnum hmm(Car all)
        //{

        //    return all.condition;

        //}

        public Enum fueltypeget(Enums all)
        {
            return all.fueltypeenum;
        }

        public  string getstartwork(string name)
        {
            Connection con = new Connection();
            try
            {
       
                DataSet response = con.sqldata("Select nick, datelogin From LoginTableHistory where nick ='" + name + "' and datelogin between '"+ DateTime.Now.ToString("M-d-yyyy") +" 00:00:00' and '"+ DateTime.Now.ToString("M-d-yyyy") + " 23:59:59'");
                if (response.Tables[0].Rows.Count > 0)
                {
                    string responsedataset = response.Tables[0].Rows[0][1].ToString();
                    return responsedataset.ToString();
                }
                else
                {
                    con.sqldata("INSERT INTO LoginTableHistory(nick) Values ('" + name + "')");
                    return DateTime.Now.ToString("HH:mm:ss");
                }

      
            }
            catch(Exception ex)
            {
                return ex.Message;                
            }
            
        }

      public DataSet Business_employe(string login)
        {
            DataSet ds = new DataSet();
            Connection con = new Connection();
            try
            {
                Encrypt_decrypt authentication = new Encrypt_decrypt();
                ds = con.sqldata("Select [name_business], [address_business] FROM [dbo].[WCFaccount] Where login ='"+authentication.decrypt(login)+"'");
                return ds;
            }
            catch
            {
                return ds;
            }
        }




        public DataSet ShowReviewsTable(string VIN)
        {
            DataSet ds = new DataSet();
            Connection con = new Connection();

            try
            {
                ds = con.sqldata("exec [dbo].[ShowReviews] "+VIN+"");
                return ds;
            }
            catch
            {
                return ds;
            }

        }



        public DataSet ShowRepairTable(string VIN)
        {
            DataSet ds = new DataSet();
            Connection con = new Connection();
            try
            {
                ds = con.sqldata("exec [dbo].[ShowRepair] " + VIN + "");
                return ds;
            }
            catch
            {
                return ds;
            }

        }


        public DataSet ShowOrderTable(string BusinessName)
        {
            DataSet ds = new DataSet();
            Connection con = new Connection();
            try
            {
                ds = con.sqldata("SELECT[WhoOrderBusiness] as [Order - Business name], [WhereOrder] as [Order - Business Address], [WhoOrderEmployee] as [Order - Employee], [DateOrder] as [Date order], [WhenDateNecessary] as [Date necessary], [Status], [Items], [Send], [DateSend] as [Date send], [Cost] FROM[dbo].[Order] WHERE[WhoOrderBusiness] = '"+BusinessName+"' ORDER BY ID DESC");
                return ds;
            }
            catch
            {

                return ds;

            }

        }

        public string NewReview(string WhoReviewsBusinessName, string WhereReviewsBusinessName, string Mileage, string Colour, string WhoReviewEmployee, string Brakes, string Damper, string Exhaust, string Convergence, string light, string Vin, string fuel)
        {

            return "";
        }
    }
}
