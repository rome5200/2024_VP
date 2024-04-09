using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double weight, height;

            Console.Write("체중(kg)을 입력하세요 : ");
            weight = double.Parse(Console.ReadLine());

            Console.Write("키(cm)를 입력하세요 : ");
            height = double.Parse(Console.ReadLine());

            double bmi = weight / ((height / 100) * (height / 100));

            Console.WriteLine("BMI = " + bmi);
        }
    }
}