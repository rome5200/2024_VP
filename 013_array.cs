namespace _013_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 배열 선언 및 초기화 (1)
            int[] a = { 1, 2, 3 };
            
            // 배열 선언 및 초기화 (2)
            int[] b = new int[3] { 1, 2, 3 };

            // 배열 선언 및 초기화 (3)
            int[] c = new int[] { 1, 2, 3 };

            // 배열 선언 및 초기화 (4)
            int[] d = new int[3];
            d[0] = 1;
            d[1] = 2;
            d[2] = 3;

            // (1) 배열 출력
            Console.Write("a[] : ");
            foreach (int i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // (2) 배열 출력
            Console.Write("b[] : ");
            foreach (int i in b)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // (3) 배열 출력
            Console.Write("c[] : ");
            foreach (int i in c)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // (4) 배열 출력
            Console.Write("d[] : ");
            foreach (int i in d)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // 문자열 s 선언 및 초기화
            string[] s = { "abc", "bcd", "cde" };

            // 문자열 s 출력
            Console.Write("s[] : ");
            foreach (string i in s)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // 리스트 la 생성
            List<int> la = new List<int>();
            la.Add(10); // 리스트 la에 10 추가
            la.Add(20); // 리스트 la에 20 추가
            la.Add(3); // 리스트 la에 3 추가

            // 리스트 la 출력
            Console.Write("List<int> la : ");
            foreach (int i in la)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // 리스트 la 정렬
            la.Sort();
            Console.Write("List<int> sorted la : ");
            
            // 정렬된 리스트 la 출력
            foreach (int i in la)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
