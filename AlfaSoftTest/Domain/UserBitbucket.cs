using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AlfaSoftTest.Domain
{
    public class UserBitbucket
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty("is_staff")]
        public bool IsStaff { get; set; }

        [JsonProperty("location")]
        public object Location { get; set; }

        [JsonProperty("account_status")]
        public string AccountStatus { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }
    }
}
