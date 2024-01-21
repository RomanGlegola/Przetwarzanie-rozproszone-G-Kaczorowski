using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject
{
    internal class Breakfast
    {

        public delegate void MyDelegate(string message);

        private MyDelegate SendMessage;

        public void MyCallback(MyDelegate MyFunction)
        {
            SendMessage += MyFunction;
        }


        public void MakeBreakfast()
        {
            SendMessage("making breakfast");
            MakeCofee();
            MakeSandwich();
            MakeScrambledEggs();
            SendMessage("breakfast is ready");

        }

        private void MakeCofee()
        {
            Thread.Sleep(500);
            SendMessage("making cofee");

        }
        private void MakeSandwich()
        {
            Thread.Sleep(800);
            SendMessage("making sandwich");
        }

        private void MakeScrambledEggs()
        {
            Thread.Sleep(1000);
            SendMessage("making scrambled eggs");

        }
    }
}
