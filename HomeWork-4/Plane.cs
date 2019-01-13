using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4
{
    public partial class Plane
    {
        private static string _companyName;         //Название компании
        private static int _wings;                  //количество крыльев у самолета
        private string _tipe;                       //тип самолета (грузовой, пассажирский)
        private int _loadCapacity;                  //грузоподъемность
        private int _quantitiesCrewMembers;         //количество членов экипажа
        private int _passengerCapacity;             //вместимость пассажиров
        private DateTime _manufactureDate;          //дата сборки самолета
        private bool _isDepartureReady;             //статус готовности самолета к вылету
        private int _ticketPrice;                   //цена билета (для пассажирских самолетов)
        private int _kilogramCargoPrice;            //цена груза за кило (для грузовых)
        private int _passengersNow;                 //пассажиров на борту
        private int _cargoNow;                      //груза на борту


        static Plane()                              //статический конструктор
        {
            _companyName = "Plane Company";         //одна компания
            _wings = 2;                             //2 крыла у всех самолетов
        }

        public Plane()                              //конструктор по умолчанию
        {
            _manufactureDate = DateTime.Now;        //компания занесла в базу новенький самолет прямиком с завода
            _isDepartureReady = false;              //пока к вылету не готов
        }

        public Plane(string tipe, int quantitiesCrewMembers)    //конструктор с параметрами
        {                                                       
            SetTipe(tipe);                                      //задается тип самолета и количество членов экипажа
            SetQuantitiesCrewMembers(quantitiesCrewMembers);
        }

        public Plane(int kilogramCargoPrice, int ticketPrice)   //конструктор с параметрами
        {
            SetKilogramCargoPrice(kilogramCargoPrice);           //задается цена за билет и кг груза
            SetTicketPrice(ticketPrice);
        }

     
        ///////////////////////////////////
        //методы доступа к закрытым полям//
        ///////////////////////////////////
        
        public int GetCompanyName()
        {
            return _wings;
        }

        public int GetWings()
        {
            return _wings;
        }

        public void SetTipe(string tipe)
        {
            _tipe = tipe;
        }
        public string GetTipe()
        {
            return _tipe;
        }

        public void SetLoadCapacity(int loadCapacity)
        {
            _loadCapacity = loadCapacity;
        }
        public int GetLoadCapacity()
        {
            return _loadCapacity;
        }

        public void SetQuantitiesCrewMembers(int quantitiesCrewMembers)
        {
            _quantitiesCrewMembers = quantitiesCrewMembers;
        }
        public int GetquantitiesCrewMembers()
        {
            return _quantitiesCrewMembers;
        }

        public void SetPassengerCapacity(int passengerCapacity)
        {
            _passengerCapacity = passengerCapacity;
        }
        public int GetPassengerCapacity()
        {
            return _passengerCapacity;
        }

        public void SetManufactureDate(DateTime manufactureDate)
        {
            _manufactureDate = manufactureDate;
        }
        public DateTime GetManufactureDate()
        {
            return _manufactureDate;
        }

        public void SetIsDepartureReady(bool isDepartureReady)
        {
            _isDepartureReady = isDepartureReady;
        }
        public bool GetIsDepartureReady()
        {
            return _isDepartureReady;
        }

        public void SetTicketPrice(int ticketPrice)
        {
            _ticketPrice = ticketPrice;
        }
        public int GetTicketPrice()
        {
            return _ticketPrice;
        }

        public void SetKilogramCargoPrice(int kilogramCargoPrice)
        {
            _kilogramCargoPrice = kilogramCargoPrice;
        }
        public int GetKilogramCargoPrice()
        {
            return _kilogramCargoPrice;
        }

        public void SetPassengersNow(int passengersNow)
        {
            _passengersNow = passengersNow;
        }
        public int GetPassengersNow()
        {
            return _passengersNow;
        }

        public void SetCargoNow(int cargoNow)
        {
            _cargoNow = cargoNow;
        }
        public int GetCargoNow()
        {
            return _cargoNow;
        }



        public void ChangeReadyStatus()                     //переключает статус готовности к вылету
        {
            if (_isDepartureReady)
                _isDepartureReady = false;
            else _isDepartureReady = true;
        }

        public int MaximumPassengerProfit()                 //возвращает максимально возможную выручку с пассажирского самолета
        {
            return _ticketPrice * _passengerCapacity;
        }

        public int MaximumCargoProfit()                     //возвращает максимально возможную выручку с грузового самолета
        {
            return _kilogramCargoPrice * _loadCapacity;
        }

        public int NowPassengerProfit()                     //выручка исходя от пассажиров на борту
        {
            return _ticketPrice * _passengersNow;
        }

        public int NowCargoProfit()                         //выручка исходя от груза на борту
        {
            return _kilogramCargoPrice * _cargoNow;
        }

        public void LaunchPassengerFlight(ref int companyMoney)     //отправляет пассажирский самолет если статус готовности true
        {                                                           
            if (GetIsDepartureReady())                             
            {
                companyMoney += NowPassengerProfit();               //деньги зачисляются на счет компании companyMoney
                _passengersNow = 0;                                 //пассажиры улетели
                ChangeReadyStatus();                                //статус переключился на false
            }
        }

        public void LaunchCargoFlight(ref int companyMoney)         //отправляет грузовой самолет если статус готовности true
        {
            if (GetIsDepartureReady())
            {
                companyMoney += NowCargoProfit();                   //деньги зачисляются на счет компании companyMoney
                _cargoNow = 0;                                      //груз улетел
                ChangeReadyStatus();                                //статус переключился на false
            }
        }
    }
}
