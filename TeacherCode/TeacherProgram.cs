﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Eloi.IID;
using XboxClientQA.TeacherCode.CoordinateWow;
using XboxClientQA.UtilityCode;

namespace XboxClientQA.TeacherCode
{
    public class TeacherProgram
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        public static void TeacherMain(params string[] args)
        {

          

            string address = "127.0.0.1";
            //address = "10.64.22.20";
            ChampionThread champion = new ChampionThread(address, 7073, 0);

            float xLeftRightRatioOfMap = 4f / 50f;//percent meter
            float yTopBottomRatioOfMap = 4.2f / 50f;//percent meter

            WowCoord center = new WowCoord(50,50, 0);
            WowCoord top = new WowCoord(50, 0, 0);
            WowCoord topLeft= new WowCoord(0, 0, 0);
            WowCoord left = new WowCoord(0, 50, 0);
            WowCoord bottomLeft = new WowCoord(0, 100, 0);
            WowCoord bottom = new WowCoord(50, 100, 0);
            WowCoord bottomRight = new WowCoord(100, 100, 0);
            WowCoord right = new WowCoord(100, 50, 0);
            WowCoord topRight = new WowCoord(100, 0, 0);


            center.GetCountClockwiseAngle(top, out float angleCenter);
            WowCoord.GetCountClockwiseAngle(center, top, out float angleTop);
            WowCoord.GetCountClockwiseAngle(center, topLeft, out float angleTopLeft);
            WowCoord.GetCountClockwiseAngle(center, left, out float angleLeft);
            WowCoord.GetCountClockwiseAngle(center, bottomLeft, out float angleBottomLeft);
            WowCoord.GetCountClockwiseAngle(center, bottom, out float angleBottom);
            WowCoord.GetCountClockwiseAngle(center, bottomRight, out float angleBottomRight);
            WowCoord.GetCountClockwiseAngle(center, right, out float angleRight);
            WowCoord.GetCountClockwiseAngle(center, topRight, out float angleTopRight);



            Print("Angle Top: " + angleTop);
            Print("Angle Top Left: " + angleTopLeft);
            Print("Angle Left: " + angleLeft);
            Print("Angle Bottom Left: " + angleBottomLeft);
            Print("Angle Bottom: " + angleBottom);
            Print("Angle Bottom Right: " + angleBottomRight);
            Print("Angle Right: " + angleRight);
            Print("Angle Top Right: " + angleTopRight);


           // champion.MoveForDistance(50);

            while (true) { 
                ConsoleWowCoord.AskForDirectionInfo(
                out WowCoord origin,
                out WowCoord target,
                out float distance,
                out bool isLeftDirection,
                out float angleToRotate,
                out float rotationTime);

                if (isLeftDirection) 
                    champion.RotationToLeftAngle(angleToRotate);
                else
                    champion.RotationToRightAngle(angleToRotate);

                bool useFly = false;
                if (useFly)
                {
                    Thread.Sleep(100);
                    champion.TapMS(WowIntegerKeyboard.Alpha0, 1000);
                    Thread.Sleep(100);
                }
                else {

                    champion.MoveForDistance( distance/ (4f/50f) );
                }

            }





            // WowCoord player = new WowCoord(43, 16, 0);
            // WowCoord target = new WowCoord(80, 35, 0);

            //bool isRight= player.IsAtRight(target);

            // isRight= WowCoord.IsAtRight(
            //     player, 
            //     target);

            //float currentAngle = 320;
            //float targetAngle = 150;

            //WowSetToDirectionAngle.GetTimeToRotateFromTo(currentAngle, targetAngle, out bool goLeft, out float angleToRotate);


            //Console.WriteLine("Go left: " + goLeft + " Angle to rotate: " + angleToRotate);
            //if (goLeft)
            //    angleToRotate = -angleToRotate;
            //champion.RotationForLeftRightAngle(angleToRotate);

            //WowCoord d = new WowCoord(69,43,60);


            //d.GetAngleCounterClockwise360(out float angle);
            //Print("Angle: " + angle);

            //Print("Test"+ d.GetAngleCounterClockwise360());

            //d.Angle = 60;
            //Print("Get a la c# " + d.Angle);


            //bool isRight = d.IsAngleBetween
            //    (d.Angle, 300, 200);
            //Print("Is right: " + isRight);







            ////champion.TapKey(WowIntegerKeyboard.Tab);
            ////champion.TapKey(WowIntegerKeyboard.KeyF);


            //Console.WriteLine("Hello World");
            //while (true)
            //{
            //    Console.WriteLine("Enter a command:");
            //    string command = Console.ReadLine();
            //    Console.WriteLine("You entered: " + command);
            //    string[] items =command.Split(' ');
            //    for (int i = 0; i < items.Length; i=i+1) {

            //        Console.WriteLine("Item " + i + " is " + items[i]);
            //        if (int.TryParse(items[i], out int value))
            //        {

            //            Console.WriteLine("This is a \n \r number");
            //            Thread.Sleep(value);
            //        }
            //        else if (items[i] == "ping") {
            //            for (int j = 0; j < 10; j++)
            //            {
            //                champion.TapKey(WowIntegerKeyboard.Jump);
            //                champion.WaitSomeMilliseconds(500);
            //            }

            //        }
            //        else if (items[i] == "L")
            //        {
            //            champion.StartRotateLeft();
            //            Console.WriteLine("Press Left");
            //        }
            //        else if (items[i] == "l")
            //        {
            //            champion.StopRotateLeft();
            //            Console.WriteLine("Release Left");
            //        }
            //        else if (items[i] == "J")
            //        {
            //            champion.StartJump();
            //            Console.WriteLine("Press Jump");
            //        }
            //        else if (items[i] == "j")
            //        {
            //            champion.StopJump();
            //            Console.WriteLine("Release jump");
            //        }
            //    }
            //    Thread.Sleep(1000);

            //}

        }
    }
}
