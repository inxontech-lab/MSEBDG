using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public static class ConfigClass
    {
        public static string ConnectionString = "Server=localhost;Database=MSEBDGCamps;Trusted_Connection=True;Integrated Security=false;User Id=sa;Password=123;TrustServerCertificate=True";
        //public static string ConnectionString = "Server=phcawsprodmssql1.cqpw79y6zq7h.me-south-1.rds.amazonaws.com;Database=PHCServices;Trusted_Connection=True;Integrated Security=false;User Id=admin;Password=VjdO9pnljHQvEfmHzoIo;TrustServerCertificate=True";
        //Scaffold-DbContext "Server=localhost;Database=MSEBDGCamps;Trusted_Connection=True;Integrated Security=false;User Id=sa;Password=123;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir GroupingCampModels/DBModels -Force

        public const string MESSAGE_TYPE_SUCCESS = "SUCCESS";
        public const string MESSAGE_TYPE_WARNING = "WARNING";
        public const string MESSAGE_TYPE_ERROR = "ERROR";

        public const string SUCCESS = "001";
        public const string SUCCESS_MESSAGE = "Success";

        public const string FAILURE = "002";
        public const string FAILURE_MESSAGE = "Failure";

        public const string DATA_NOT_FOUND = "003";
        public const string DATA_NOT_FOUND_MESSAGE = "No data found";

        public const string WARNING = "004";
        public const string WARNING_MESSAGE = "Warning";

        public const string DATE_NOT_AVAILABLE = "005";
        public const string DATE_NOT_AVAILABLE_MESSAGE = "Dates not available";

        public const string SLOT_NOT_AVAILABLE = "006";
        public const string SLOT_NOT_AVAILABLE_MESSAGE = "Slot not available. Select another date";

        public const string UPCOMING_APPOINTMENT = "007";
        public const string UPCOMING_APPOINTMENT_MESSAGE = "Upcoming appointment";

        public const string NO_APPOINTMENT = "008";
        public const string No_APPOINTMENT_MESSAGE = "No appointment";

        public const string APPOINTMENT_DETAILS_RETRIEVE_FAILURE = "009";
        public const string APPOINTMENT_DETAILS_RETRIEVE_FAILURE_MESSAGE = "Error while getting appointment detials";

        public const string APPT_BOOKING_FAILURE = "011";
        public const string APPT_BOOKING_FAILURE_MESSAGE = "Error while booking appointment";

        public const string INVALID_FILE_NAME = "012";
        public const string INVALID_FILE_NAME_MESSAGE = "Invalid file name";

        public const string MANDATORY_ATTACHMENT_MISSING = "014";
        public const string MANDATORY_ATTACHMENT_MISSING_MESSAGE = "Mandatory attachment file missing";

        public const string ATTACHMENT_UPLOADING_ERROR = "015";
        public const string ATTACHMENT_UPLOADING_ERROR_MESSAGE = "Error while uploading attachment";

        public const string REQUESTOR_DATA_MISSING = "016";
        public const string REQUESTOR_DATA_MISSING_MESSAGE = "Requestor information missing";

        public const string MANDATORY_FIELD_MISSING = "017";
        public const string MANDATORY_FIELD_MISSING_MESSAGE = "Mandatory field missing";

        public const string INVALID_REQUEST = "018";
        public const string INVALID_REQUEST_MESSAGE = "Invalid request!";

        public const string NOTHING_FOUND_TO_UPDATE = "019";
        public const string NOTHING_FOUND_TO_UPDATE_MESSAGE = "No record found to update";
    }
}
