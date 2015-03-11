using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinSelfHosted
{
    class StartPageMiddleware
    {
        private Func<IDictionary<string, object>, Task> next;

        public StartPageMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            if (environment["owin.RequestPath"] as string == "/")
            {
                var body = environment["owin.ResponseBody"] as Stream;
                var writer = new StreamWriter(body);
                writer.WriteLine(@"
<HTML>
  <HEAD>
    <TITLE>
      Hello OWIN!
    </TITLE>
  </HEAD>
  <BODY>
    <H1>Hello OWIN!</H1>
  </BODY>
</HTML>"
                );

                writer.Flush();
            }
            else
            {
                await next(environment);
            }
        }
    }
}
