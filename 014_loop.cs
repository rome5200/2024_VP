namespace _014_loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            int sum = 0, oSum = 0;
            double rSum = 0;
            
            //(1)
            Console.WriteLine("Q1. 값을 입력받고 합 구하기");
            Console.Write("x를 입력하세요 : ");
            x = int.Parse(Console.ReadLine());
            Console.Write("y를 입력하세요 : ");
            y = int.Parse(Console.ReadLine());

            //x~y
            for (int i = x; i <= y; i++)
            {
                sum += i;
            }
            Console.WriteLine("X부터 Y까지의 합 : {0}", sum);

            //홀수
            for (int i = x; i <= y; i++)
            {
                if (i % 2 == 1)
                    oSum += i;
            }
            Console.WriteLine("X부터 Y까지의 홀수의 합 : {0}", oSum);

            //역수
            for (int i = x; i <= y; i++)
            {
                rSum += 1.0 / i;
            }
            Console.WriteLine("X부터 Y까지의 역수의 합 : {0}", rSum);
            Console.WriteLine();

            //2
            Console.WriteLine("Q2. 구구단");
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 2; j <= 9; j++)
                    Console.Write("{0}*{1}={2}\t", j, i, i * j);
                Console.WriteLine();
            }
            Console.WriteLine();

            //3
            Console.WriteLine("Q3. 지수");
            int Base, Index, pow = 1;

            Console.Write("밑을 입력하세요 : ");
            Base = int.Parse(Console.ReadLine());
            Console.Write("지수를 입력하세요 : ");
            Index = int.Parse(Console.ReadLine());
            for (int i = 1; i <= Index; i++)
                pow *= Base;
            Console.WriteLine(pow);
            Console.WriteLine();

            //4
            Console.WriteLine("Q4. 팩토리얼");
            int n, fact = 1;
            Console.Write("정수를 입력하세요 : ");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
                fact *= i;
            Console.WriteLine(fact);

            Console.WriteLine();
            //foreach 쓸 때 주의할 점
            int[] arr = { 10, 20, 30, 40, 50 };
            for (int i = 0; i < 5; i++)
                Console.WriteLine(arr[i]);

            foreach (var i in arr)
                Console.WriteLine(i);
        }
    }
}