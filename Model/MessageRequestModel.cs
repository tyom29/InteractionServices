namespace InteractionService.Model
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
   

    public partial class MessageRequestModel
    {
        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }
    }


    // Message Types
    public partial class Message
    {
        [JsonProperty("recipient")]
        public string recipient { get; set; }

        [JsonProperty("priority")]
        public string priority { get; set; }

        [JsonProperty("message-id")]
        public string messageId { get; set; }

        [JsonProperty("sms")]
        public Sms sms { get; set; }
    }



    #region SMS
    public partial class Sms
    {
        [JsonProperty("originator")]
        public string originator { get; set; }

        [JsonProperty("content")]
        public SmsContent content { get; set; }
    }

    public partial class SmsContent
    {
        [JsonProperty("text")]
        public string text { get; set; }
    }

    #endregion

    #region Push

    public partial class Push
    {
        [JsonProperty("application")]
        public string Application { get; set; }

        [JsonProperty("ttl")]
        public string Ttl { get; set; }

        [JsonProperty("content")]
        public PushContent Content { get; set; }
    }

    public partial class PushContent
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    #endregion

    #region Viber
    public partial class Viber
    {
        [JsonProperty("originator")]
        public string Originator { get; set; }

        [JsonProperty("ttl")]
        public string Ttl { get; set; }

        [JsonProperty("content")]
        public ViberContent Content { get; set; }
    }

    public partial class ViberContent
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("image-url")]
        public string ImageUrl { get; set; }

        [JsonProperty("button-name")]
        public string ButtonName { get; set; }

        [JsonProperty("button-url")]
        public string ButtonUrl { get; set; }
    }

    #endregion
}
