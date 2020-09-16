using Newtonsoft.Json;
using System;

namespace TrashBox.Helpers
{
    public static class ShellQueryParametersHelper
    {
        public static string GetStringFromPayload<T>(T payload)
        {
            var payloadString = string.Empty;

            try
            {
                payloadString = JsonConvert.SerializeObject(payload);
            }
            catch (JsonSerializationException)
            {
                // Track error
            }
            catch (JsonException)
            {
                // Track error
            }

            return payloadString;
        }

        public static T GetPayloadFromString<T>(string payloadString) where T : new()
        {
            var payload = new T();

            try
            {
                if (string.IsNullOrEmpty(payloadString))
                {
                    return default;
                }

                payload = JsonConvert.DeserializeObject<T>(Uri.UnescapeDataString(payloadString));
            }
            catch (JsonSerializationException)
            {
                // Track error
            }
            catch (JsonException)
            {
                // Track error
            }

            return payload;
        }
    }
}