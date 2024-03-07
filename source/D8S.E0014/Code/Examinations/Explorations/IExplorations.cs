using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using R5T.T0141;


namespace D8S.E0014
{
    [ExplorationsMarker]
    public partial interface IExplorations : IExplorationsMarker
    {
        /// <summary>
        /// Every ASP.NET Core web application project has an appsettings.json file.
        /// This is an effort to generate an appsettings.json file using types from the <see cref="System.Text.Json"/> namespace.
        /// </summary>
        public async Task Try_Generating_AppSettingsFile()
        {
            var outputJsonFilePath = Instances.FilePaths.OutputJsonFilePath;

            // Source: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/use-dom#create-a-jsonnode-dom-with-object-initializers-and-make-changes
            //var jsonObject = new JsonObject
            //{
            //    ["Logging"] = new JsonObject
            //    {
            //        ["LogLevel"] = new JsonObject
            //        {
            //            ["Default"] = "Information",
            //            ["Microsoft.AspNetCore"] = "Warning"
            //        }
            //    },
            //    ["AllowedHosts"] = "*"
            //};

            var jsonObject = new JsonObject();

            var loggingJsonObject = new JsonObject();

            var logLevelJsonObject = new JsonObject();

            //logLevelJsonObject.Add("Default", "Information");
            //logLevelJsonObject.Add("Microsoft.AspNetCore", "Warning");

            var information = JsonValue.Create("Information");
            logLevelJsonObject.Add("Default", information);

            var warning = JsonValue.Create("Warning");
            logLevelJsonObject.Add("Microsoft.AspNetCore", warning);

            loggingJsonObject.Add("LogLevel", logLevelJsonObject);

            jsonObject.Add("Logging", loggingJsonObject);

            var allowedHostsAll = JsonValue.Create("*");
            jsonObject.Add("AllowedHosts", allowedHostsAll);

#pragma warning disable CA1869 // Cache and reuse 'JsonSerializerOptions' instances
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
#pragma warning restore CA1869 // Cache and reuse 'JsonSerializerOptions' instances

            await using var fileStream = File.Create(outputJsonFilePath);
            await JsonSerializer.SerializeAsync(
                fileStream,
                jsonObject,
                options);

            Instances.NotepadPlusPlusOperator.Open(outputJsonFilePath);
        }
    }
}
