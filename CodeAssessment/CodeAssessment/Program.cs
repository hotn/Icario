namespace CodeAssessment
{
    class Program
    {
        // TODO: in real app, move this to a config file, environment variable, db record, etc.
        private const string WeatherDataApiUrl = "http://api.openweathermap.org/data/2.5/forecast?q=minneapolis,us&units=imperial&APPID=09110e603c1d5c272f94f64305c09436";

        static void Main(string[] args)
        {
            // TODO: retrieve weather

            // TODO: separate weather details out into days

            // TODO: process each day to find optimal contact method

            // TODO: handle non-match cases where weather conditions don't match a contact method

            // TODO: print out contact method and weather description, or warning if no match
        }
    }
}
