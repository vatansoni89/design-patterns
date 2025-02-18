﻿using System;
using System.IO;
using MdfManufacturers;
using Microsoft.Extensions.Configuration;
using WonderTools.MyCar;
using WonderTools.VendorContract;

namespace MyCarBootstrap
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var carType = configuration.GetSection("carType").Value;
            Console.WriteLine("The car type is :" + carType);

            Console.WriteLine("Please press the option");
            Console.WriteLine("i/I for increase car speed");
            Console.WriteLine("d/D for decrease car speed");
            Console.WriteLine("u/U for unlock car");
            Console.WriteLine("l/L for lock car");
            Console.WriteLine("e/E for exit the application");

            var simulator = new CarSpeedSimulator();
            var speedometer = new Speedometer(simulator);

            IAlarm alarm = carType == "normal1" ? (IAlarm)new Alarm() : new FreecolAlarm();
            var speedAlarm = new SpeedAlarm(alarm, speedometer);
            var seatBelt = new SeatBelt(alarm, speedometer);

            while (true)
            {
                var key = Console.ReadKey();
                Console.WriteLine();
                var keyChar = key.KeyChar;
                var optionString = keyChar.ToString().ToLower();

                if (optionString == "i") simulator.Increase();
                else if (optionString == "d") simulator.Decrease();
                else if (optionString == "l") seatBelt.Lock();
                else if (optionString == "u") seatBelt.UnLock();
                else if (optionString == "e") break;
                else Console.WriteLine("unknown option");
            }
        }
    }
}