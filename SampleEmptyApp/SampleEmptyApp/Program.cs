using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (HttpContext context) =>
    {
        context.Response.Headers.ContentType = "text/plain";
        using (FileStream stream = File.Open(@"./Program.cs", FileMode.Open))
        {
            int num = (int)stream.Length;
            byte[] bytes = new byte[num];
            stream.Read(bytes, 0, num);
            string result = System.Text.Encoding.UTF8.GetString(bytes);
            await context.Response.WriteAsync(result);
        }

        //return "<html>" +
        //"<title>Hello</title>" +
        //"</head>" +
        //"<body>" +
        //"<h1>Hello!</h1>" +
        //"<p>This is sample page.</p>" +
        //"</body>" +
        //"</html>";
    }
);

//app.UseWelcomePage();
app.Run();