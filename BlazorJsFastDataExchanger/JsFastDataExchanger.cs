using Mono.WebAssembly.Interop;


namespace BlazorJsFastDataExchanger
{
    public static class JsFastDataExchanger 
    {

        private static MonoWebAssemblyJSRuntime mono = new MonoWebAssemblyJSRuntime();


        public static void SetStringData(string variableName, string data)
        {

            mono.InvokeUnmarshalled<string, string, bool>(
                    "FastInterop.SetStringData", variableName, data);
        }


        public static void SetBinaryData(string variableName, byte[] data)
        {

            mono.InvokeUnmarshalled<string, byte[], bool>(
                    "FastInterop.SetBinaryData", variableName, data);
        }


        public static string GetStringData(string variableName)
        {
            return mono.InvokeUnmarshalled<string, string>(
                    "FastInterop.GetStringData", variableName);

        }


        public static bool GetBinaryData(string variableName, byte[] destination)
        {
            return mono.InvokeUnmarshalled<string, byte[], bool>(
                    "FastInterop.GetBinaryData", variableName, destination);

        }

        public static int GetBinaryDataLength(string variableName)
        {

            return mono.InvokeUnmarshalled<string, int>(
                    "FastInterop.GetBinaryDataLength", variableName);

        }


    }
}
