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
        Enum fueltypeget(Enums all);


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
        string NewReview(string WhoReviewsBusinessName, string WhereReviewsBusinessName, string Mileage, string Colour, string WhoReviewEmployee, string Brakes, string Damper, string Exhaust, string Convergence, string light, string Vin, string fuel);

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
    public class Enums
    {
        [DataMember]
        public string all;
        [DataMember]
        public fueltypeenum fueltypeenum;
    }
    [DataContract(Name = "fueltypeenum")]
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
