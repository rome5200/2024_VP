namespace _015_Random
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //Random 클래스의 객체 r을 만든다.
           Random r = new Random();

            //Console.WriteLine(r.Next()); // 0 ~ 2억 사이의 값
            //Console.WriteLine(r.Next(100)); // 0 ~ 99 사이의 값
            //Console.WriteLine(r.Next(1, 7)); // 1 ~ 6 사이의 값
            //Console.WriteLine(r.NextDouble()); // 0 ~ 1.0 미만의 값

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(r.Next());
            }
            Console.WriteLine();

            //주사위 
            Console.WriteLine("주사위를 굴려보자");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(r.Next(1, 7) + " ");
            }

            Console.WriteLine();

            //20개의 random 숫자를 배열하여 저장한 후, 최소 최대 평균값 계산
            int[] arr = new int[20];

            Console.Write("배열 출력하기 : ");
            for(int i = 0; i < 20; i++)
            {
                arr[i] = r.Next(1, 11);
                Console.Write(arr[i] + " ");
            } Console.WriteLine();
            Console.WriteLine();

            int min = arr[0], max = arr[0];

            for (int i = 0; i< 20; i++)
            {
                if (min > arr[i])
                    min = arr[i];
                else if (max < arr[i])
                    max = arr[i];
            }
            Console.WriteLine("최소값 : {0} 최대값 : {1}", min, max);

            int sum = 0;
            double avg = 0;

            for (int i = 0; i < 20; i++)
            {
                sum += arr[i];
                avg = sum / 20.0;
            } Console.WriteLine("평균값 : {0}", avg);  
        }
    }
}