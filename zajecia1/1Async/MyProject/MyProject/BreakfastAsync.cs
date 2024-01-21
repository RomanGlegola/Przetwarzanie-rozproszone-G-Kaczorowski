using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject
{
    internal class BreakfastAsync
    {
        public delegate void MyDelegate(string message);

        private MyDelegate SendMessage;

        public void MyCallback(MyDelegate MyFunction)
        {
            SendMessage += MyFunction;
        }


        public async Task MakeBreakfast()
        {
            await Task.Run(() =>
            {
                SendMessage("making breakfast");

                var tasks = new[]
                {
                    Task.Run(() => MakeCofee() ),
                    Task.Run(() => MakeSandwich() ),
                    Task.Run(() => MakeScrambledEggs() ),
                };
                Task.WaitAll(tasks);
                SendMessage("breakfast is ready");
            });
           
        }

        private async Task MakeCofee()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(500);
                SendMessage("making cofee");
            });
            

        }
        private async Task MakeSandwich()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(800);
                SendMessage("making sandwich");
            });
            
        }

        private async Task MakeScrambledEggs()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                SendMessage("making scrambled eggs");
            });
            

        }
    }
}

