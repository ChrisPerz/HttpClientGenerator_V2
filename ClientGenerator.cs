using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using NSwag;
using NSwag.CodeGeneration.CSharp;

public class SwaggerClientGenerator
{
    public async Task GenerateClient()
    {
        var httpClient = new HttpClient();
        var swaggerJson = await httpClient.GetStringAsync("http://localhost:5000/swagger/v1/swagger.json");
        var document = await OpenApiDocument.FromJsonAsync(swaggerJson);

        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = "InformationApiClient",
            CSharpGeneratorSettings =
            {
                Namespace = "MyClientNamespace",
            }
        };

        var generator = new CSharpClientGenerator(document, settings);
        var code = generator.GenerateFile();
        await File.WriteAllTextAsync("GeneratedApiClient.cs", code);
    }

}