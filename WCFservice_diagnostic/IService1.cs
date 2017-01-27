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
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

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
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
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
