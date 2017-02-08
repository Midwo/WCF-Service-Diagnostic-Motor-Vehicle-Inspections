using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFservice_diagnostic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool Authentication(string loginNamecrypt, string passwordcrypt);

        [OperationContract]
        Enum Fueltypeget(Enums all);


        [OperationContract]
        string getstartwork(string name);


        [OperationContract]
        DataSet Business_employe(string login);


        [OperationContract]
        DataSet ShowReviewsTable(string VIN);


        [OperationContract]
        DataSet ShowRepairTable(string VIN);

        [OperationContract]
        DataSet ShowOrderTable(string BusinessName);

        [OperationContract]
        bool NewReview(string WhoReviewsBusinessName, string WhereReviewsBusinessName, string Mileage, string Colour, string WhoReviewEmployee, string Brakes, string Damper, string Exhaust, string Convergence, string light, string Vin, string fuel);

        [OperationContract]
        DataSet ShowEditReview(string VIN, string BusinessName);

        [OperationContract]
        string SaveEditReview(Review Save);

        [OperationContract]
        bool NewRepair(Repair composite);

        [OperationContract]
        bool EditRepair(Repair composite);

        [OperationContract]
        DataSet ShowEditRepair(string VIN, string BusinessName);

        [OperationContract]
        bool NewOrder(Order composite);

        [OperationContract]
        DataSet ClientOptionStatus();

        [OperationContract]
        int BillSave(Bill component);

        [OperationContract]
        bool SendOrderEmial(ContractIServiceSendEmailOrder option);

        [OperationContract]
        string CheckVinClient_NewAccount(CheckVinClient_Account component);

        [OperationContract]
        bool CheckVinClient_SingIn(CheckVinClient_Account component);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operation

     [DataContract]
     public class CheckVinClient_Account
    {
        string adressEmail;
        string name;
        string surname;
        string phone;
        string password;

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [DataMember]
        public string AdressEmail
        {
            get { return adressEmail; }
            set { adressEmail = value; }
        } 

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        [DataMember]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }

    [DataContract]
    public class Bill
    {
        DateTime date;
        string whoBill;
        float  cost;
        string employee;
        string typePayment;
        float rest;
        float receivedCash;
        string whereBusiness;
        string whoBusiness;
        string informationClient;
        string what;         

        [DataMember]
        public string What
        {
            get { return what; }
            set { what = value; }
        }

        [DataMember]
        public string InformationClient
        {
            get { return informationClient; }
            set { informationClient = value; }
        }

        [DataMember]
        public string WhoBusiness
        {
            get { return whoBusiness; }
            set { whoBusiness = value; }
        }

        [DataMember]
        public string WhereBusiness
        {
            get { return whereBusiness; }
            set { whereBusiness = value; }
        }

        [DataMember]
        public float ReceivedCash
        {
            get { return receivedCash; }
            set { receivedCash = value; }
        }

        [DataMember]
        public float Rest
        {
            get { return rest; }
            set { rest = value; }

        }

        [DataMember]
        public string TypePayment
        {
            get { return typePayment; }
            set { typePayment = value; }
        }

        [DataMember]
        public string Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        [DataMember]
        public float Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        [DataMember]
        public string WhoBill
        {
            get { return whoBill; }
            set { whoBill = value; }
        }
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }


    [DataContract]
    public class Order
    {
        int id;
        string whoOrderBusiness;
        string whereOrder;
        string whoOrderEmployee;
        DateTime whenDateNecessary;
        string status;
        string items;
        string send;
        DateTime dateSend;
        float cost;

        [DataMember]
        public float Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        [DataMember]
        public DateTime DateSend
        {
            get { return dateSend; }
            set { dateSend = value; }
        }

        [DataMember]
        public string Send
        {
            get { return send; }
            set { send = value; }
        }

        [DataMember]
        public string Items
        {
            get { return items; }
            set { items = value; }
        }

        [DataMember]
        public DateTime WhenDateNecessary
        {
            get { return whenDateNecessary; }
            set { whenDateNecessary = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string WhoOrderBusiness
        {
            get { return whoOrderBusiness; }
            set { whoOrderBusiness = value; }
        }

        [DataMember]
        public string WhereOrder
        {
            get { return whereOrder; }
            set { whereOrder = value; }

        }

        [DataMember]
        public string WhoOrderEmployee
        {
            get { return whoOrderEmployee; }
            set { whoOrderEmployee = value; }
        }

    }


    [DataContract]
    public class Repair
    {
        int id;
        string vin;
        string mileage;
        string repairDescription;
        string replacedParts;
        string cost;
        string whoRepairBusiness;
        string whereRepairBusiness;
        string whoRepairEmployee;

        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string VIN
        {
            get { return vin;  }
            set { vin = value; }
        }

        [DataMember]
        public string RepairDescrition
        {
            get { return repairDescription; }
            set { repairDescription = value; }
        }
        [DataMember]
        public string ReplacedParts
        {
            get { return replacedParts; }
            set { replacedParts = value; }

        }
  
        [DataMember]
        public string Cost
        {
            get { return cost;}
            set { cost = value; }
        }
        [DataMember]
        public string WhoRepairbusiness
        {
            get { return whoRepairBusiness; }
            set { whoRepairBusiness = value; }

        }
        [DataMember]
        public string WhereRepairbusiness
        {
            get { return whereRepairBusiness; }
            set { whereRepairBusiness = value; }
        }
        [DataMember]
        public string WhoRepairEmployee
        {
            get { return whoRepairEmployee; }
            set { whoRepairEmployee = value; }
        }
        [DataMember]
        public string Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
    }


    [DataContract]
    public class Review
    {
        string id;
        string whoReviews;
        string whereReviews;
        DateTime dateReviews;
        string vin;
        string light;
        string convergence;
        string exhaust;
        string damper;
        string brakes;
        string whoReviewEnployee;
        string colour;
        string fuel;
        string mileage;

     [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string WhoReviews
        {
            get { return whoReviews; }
            set { whoReviews = value; }
        }
        [DataMember]
        public string WhereReviews
        {
            get { return whereReviews; }
            set { whereReviews = value; }
        }
        [DataMember]
        public DateTime DateReviews
        {
            get { return dateReviews; }
            set { dateReviews = value; }
        }
        [DataMember]
        public string Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        [DataMember]
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }
        [DataMember]
        public string Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }
        [DataMember]
        public string WhoReviewEnployee
        {
            get { return whoReviewEnployee; }
            set { whoReviewEnployee = value; }
        }
        [DataMember]
        public string Brakes
        {
            get { return brakes; }
            set { brakes = value; }
        }
        [DataMember]
        public string Damper
        {
            get { return damper; }
            set { damper = value; }
        }
        [DataMember]
        public string Exhaust
        {
            get { return exhaust; }
            set { exhaust = value; }
        }
        [DataMember]
        public string Convergence
        {
            get { return convergence; }
            set { convergence = value; }
        }
        [DataMember]
        public string Light
        {
            get { return light; }
            set { light = value; }
        }
        [DataMember]
        public string Vin
        {
            get { return vin; }
            set { vin = value; }
        }
    }

    [DataContract]
    public class Enums
    {
        [DataMember]
        public string All;
        [DataMember]
        public fueltypeenum Fueltypeenum;
    }
    [DataContract(Name = "Fueltypeenum")]
    public enum fueltypeenum
    {
        [EnumMember]
        PB,
        [EnumMember]
        LPG,
        [EnumMember]
        Diesel
    }
}
