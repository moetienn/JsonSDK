using JsonSDK;

namespace JsonSDK
{
    public static class JsonSDK
    {
        public static string MinifyJson(string json, bool validate)
            => Minify.MinifyJson(json, validate);

        public static void ValidatorJson(string json)
            => Validator.ValidatorJson(json);
    }
}