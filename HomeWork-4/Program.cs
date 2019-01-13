using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Plane[] planes = new Plane[5];

            int companyMoney = 1000000;             //условный счет компании в 1 лям зеленых

            Console.WriteLine(companyMoney);

            planes[0] = new Plane();

            planes[0].SetTicketPrice(350);          //задаем стоимость билета
            planes[0].SetPassengersNow(3);          //билет купило 3 человека
            planes[0].ChangeReadyStatus();          //самолет готов к вылету

            planes[0].LaunchPassengerFlight(ref companyMoney);  //отправляем самолет, получаем деньги на счет

            Console.WriteLine(companyMoney);

            Console.ReadLine();
        }
    }
    partial class Plane
    {
        public string CoolCompany()
        {          
            return GetCompanyName() + " is cool company";
        }    
    }
}
