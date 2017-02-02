using System;
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
    public class Service1 : IService1
    {
     
        public bool Authentication(string loginNamecrypt, string passwordcrypt)
        {
            Encrypt_decrypt authentication = new Encrypt_decrypt();
            return authentication.Authentication(loginNamecrypt, passwordcrypt);
        }

        //public CarConditionEnum hmm(Car all)
        //{

        //    return all.condition;

        //}

        public bool BillSave(Bill component)
        {
            try
            {
                Connection con = new Connection();
                con.sqlcommand("INSERT INTO [dbo].[Bill] ([WhoBill], [Cost], [Employee], [TypePayment], [Rest], [ReceivedCash], [WhereBusiness], [WhoBusiness], [InformationClient]) VALUES ('" + component.WhoBill + "','" + component.Cost.ToString().Replace(',','.') + "','" + component.Employee + "','" + component.TypePayment + "','" + component.Rest.ToString().Replace(',', '.') + "','" + component.ReceivedCash.ToString().Replace(',', '.') + "','" + component.WhereBusiness + "','" + component.WhoBusiness+"','"+component.InformationClient+"')");
                return true;
            }
            catch
            {
                return false;
            }
        }


        public DataSet ClientOptionStatus()
        {
            DataSet responseds = new DataSet();
            Connection con = new Connection();
            try
            {
                responseds = con.sqldata("exec ShowStatusOption");
                return responseds;
            }
            catch
            {
                return responseds;
            }
        }
        public bool NewOrder(Order composite)
        {
            try
            {
                composite.Send = "Processing";
                Connection con = new Connection();
                con.sqlcommand("INSERT INTO [dbo].[Order] ([WhoOrderBusiness], [WhereOrder], [WhoOrderEmployee], [WhenDateNecessary], [Status], [Items], [Send], [Cost]) VALUES ('"+composite.WhoOrderBusiness+ "','" + composite.WhereOrder+ "','" + composite.WhoOrderEmployee+ "','" + composite.WhenDateNecessary.ToString("yyyy-MM-dd hh:mm:ss") + "','" + composite.Status+ "','" + composite.Items+ "','" + composite.Send+ "','" + composite.Cost.ToString().Replace(",",".")+ "')");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string SaveEditReview(Review Save)
        {      
            try
            {

                Connection con = new Connection();
                con.sqlcommand("UPDATE[dbo].[Reviews] SET[Mileage] = '" + Save.Mileage + "',[Colour] = '" + Save.Colour + "',[Fuel] = '" + Save.Fuel + "',[Brakes] = '" + Save.Brakes + "',[Damper] = '" + Save.Damper + "',[ExHaust] = '" + Save.Exhaust + "',[Convergence] = '" + Save.Convergence + "',[Light] = '" + Save.Light + "' WHERE ID = '" + Save.Id + "'");


                return "Success - changed review car";
            }
            catch
            {
                return "Failed - don't changed review car";
            }
        }

        public bool NewRepair(Repair composite)
        {

            try
            {
                Connection con = new Connection();
                con.sqlcommand("INSERT INTO [dbo].[Repair] ([VIN],[Mileage],[RepairDescription],[ReplacedParts],[Cost], [WhoRepairBusiness],  [WhereRepairBusiness], [WhoRepairEmployee]) VALUES ('" + composite.VIN + "','" + composite.Mileage + "','" + composite.RepairDescrition + "','" + composite.ReplacedParts + "','" + composite.Cost + "', '" + composite.WhoRepairbusiness + "', '" + composite.WhereRepairbusiness + "','" + composite.WhoRepairEmployee + "')");
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool EditRepair(Repair composite)
        {
            try
            {

                Connection con = new Connection();
                con.sqlcommand("UPDATE[dbo].[Repair] SET [Mileage] = '" + composite.Mileage + "',[RepairDescription] = '" + composite.RepairDescrition + "',[ReplacedParts] = '" + composite.ReplacedParts + "',[Cost] = '" + composite.Cost + "' WHERE ID = '" + composite.ID + "'");


                return true;
            }
            catch
            {
                return false;
            }
        }


      public  DataSet ShowEditRepair(string VIN, string BusinessName)
        {
            DataSet responseds = new DataSet();
            Connection con = new Connection();
            try
            {
                #region procedure code
                //                CREATE PROCEDURE[dbo].[ShowEditRepair]
                //        @VIN nvarchar(max),
                //@BusinessName nvarchar(max)
                //AS
                //    SELECT[Id], [VIN], [Mileage], [RepairDescription], [ReplacedParts], [Cost], [WhoRepairBusiness], [WhereRepairBusiness], [DateRepair], [WhoRepairEmployee]

                //     FROM[dbo].[Repair]
                //        WHERE ID = (SELECT MAX(ID) FROM[dbo].[Repair]
                //        WHERE VIN = @VIN) and[WhoRepairBusiness] = @BusinessName
                //RETURN 0
                #endregion

                responseds = con.sqldata("exec ShowEditRepair '" + VIN + "', '" + BusinessName + "' ");
                return responseds;
            }
            catch
            {
                return responseds;
            }
        }


        public DataSet ShowEditReview(string VIN, string BusinessName)
        {
            DataSet responseds = new DataSet();
            Connection con = new Connection();
            try
            {
                #region procedure code
                //                CREATE PROCEDURE[dbo].[ShowEditReview]
                //        @VIN nvarchar(max),
                //@BusinessName nvarchar(max)
                //AS
                //    SELECT[ID], [WhoReviews], [WhereReviews], [DateReviews], [Mileage], [Colour], [Fuel],[WhoReviewEmployee], [Brakes], [Damper], [ExHaust], [Convergence], [Light], [VIN] FROM[dbo].[Reviews]
                //        WHERE ID = (SELECT MAX(ID) FROM[dbo].[Reviews]
                //        WHERE VIN = @VIN) and[WhoReviews] = @BusinessName
                //RETURN 0
                #endregion

                responseds = con.sqldata("exec ShowEditReview '" + VIN + "', '" + BusinessName + "' ");
                return responseds;
            }
            catch
            {
                return responseds;
            }
        }
    




    public Enum Fueltypeget(Enums all)
        {
            return all.Fueltypeenum;
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

        public bool NewReview(string WhoReviewsBusinessName, string WhereReviewsBusinessName, string Mileage, string Colour, string WhoReviewEmployee, string Brakes, string Damper, string Exhaust, string Convergence, string light, string Vin, string fuel)
        {
            try
            {
                Connection con = new Connection();
                con.sqlcommand("INSERT INTO [dbo].[Reviews] ([VIN],[WhoReviews],[WhereReviews],[Mileage],[Colour], [Fuel],  [WhoReviewEmployee], [Brakes], [Damper],[ExHaust],[Convergence], [Light]) VALUES('" + Vin + "','" + WhoReviewsBusinessName + "','" + WhereReviewsBusinessName + "','" + Mileage + "','" + Colour + "', '" + fuel + "', '" + WhoReviewEmployee + "','" + Brakes + "','" + Damper + "','" + Exhaust + "','" + Convergence + "','" + light + "')");
                return true;
            }
            catch
            {
                return false;
            }
           
        }
    }
}
