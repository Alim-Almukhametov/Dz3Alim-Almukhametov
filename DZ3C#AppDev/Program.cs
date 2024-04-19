using System.Security.Cryptography.X509Certificates;

namespace DZ3C_AppDev
{
    internal class Program
    {
        public static bool HasExit(int startY , int startX , int[,] labirint)
        {
            if (labirint[startY, startX] == 1) { return false; }
            else if (labirint[startY,startX]==2) { return true; }
            var stack = new Stack<Tuple<int ,int >>();
            stack.Push(new(startY, startX));
            while (stack.Count > 0) 
            {
                var temp = stack.Pop();
                if (labirint[temp.Item1 ,temp.Item2]==2) { return true; }

                labirint[temp.Item1, temp.Item2] = 1;
                if (temp.Item2-1>=0 && labirint[temp.Item1,temp.Item2-1]!=1 ) 
                { stack.Push(new (temp.Item1 ,temp.Item2-1)); }
                if (temp.Item2 +1 <labirint.GetLength(1) && labirint[temp.Item1 ,temp.Item2+1]!=1) 
                { stack.Push(new(temp.Item1, temp.Item2 + 1)); }
                if (temp.Item1-1>=0 && labirint[temp.Item1-1,temp.Item2]!=1)
                { stack.Push(new(temp.Item1 - 1, temp.Item2)); }
                if (temp.Item1+1<labirint.GetLength(0)&& labirint[temp.Item1+1,temp.Item2]!=1)
                { stack.Push(new(temp.Item1 + 1, temp.Item2)); }
            }
            return false;
        }
        public static int HowManyExits(int[,] lab)
        {
          var list = new List<int>();
            for (int i = 0; i < lab.GetLength(0); i++) 
            {
                for (int j = 0; j < lab.GetLength(1); j++) 
                {
                    list.Add(lab[i,j]);
                }
            }
            int countEXits = 0;
            for (int i = 0; i < list.Count; i++) 
            {
                if (list[i] == 2) 
                {
                countEXits++;
                }
            }
            return countEXits;
            
        }
        static void Main(string[] args)
        {
            int[,] labirynth1 = new int[,]
              {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 0, 0, 0 },
                {1, 1, 0, 0, 1, 1, 1 },
                {1, 1, 1, 0, 0, 1, 1 },
                {1, 1, 1, 0, 0, 1, 1 }
              };

            bool hasExit = HasExit(1,1,labirynth1);
            if (hasExit) 
            {
                Console.Write("How many exits? : ");
                Console.WriteLine(HowManyExits(labirynth1));
            }
            else
            {
                Console.WriteLine($"Labirint has Exit? : {hasExit}");
            }
           
           



        }
    }
}
