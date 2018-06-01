using System;
using Newtonsoft.Json;

namespace KGKRegister
{
    public class Member
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber
        {
            get;
            set;
        }
        public string Departmant
        {
            get;
            set;
        }
        public string Faculty
        {
            get;
            set;
        }
        public string EmailAddress
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public bool IsPaid
        {
            get;
            set;
        }
        public DateTime CreatedOn
        {
            get;
            set;
        }
    }
}
