namespace SampleMvcApp
{
    public class ApiDetails : IApiDetails
    {
        private string api, apiKey,apivalue;
        public string Api
        {
            get
            {
                return api;

            }
            set
            {
                api = value;
            }
        }
        public string ApiValue
        {
            get
            {
                return apivalue;
            }
            set
            {
                apivalue = value;
            }
        }
        public string ApiKey
        {
            get
            {
                return apiKey;
            }

            set
            {
                apiKey = value;
            }

        }
    }
}
