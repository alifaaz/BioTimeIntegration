using BioTimeIntegration.Back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioTimeIntegration
{
    internal class App
    {
        public async static Task Main()
        {
           var res =  await RestApi.GetSomthin();
            Console.WriteLine(res.FirstOrDefault().title);
        }
    }
}
