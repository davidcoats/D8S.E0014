using System;
using System.Threading.Tasks;


namespace D8S.E0014
{
    class Program
    {
        static async Task Main()
        {
            await Explorations.Instance.Try_Generating_AppSettingsFile();
        }
    }
}