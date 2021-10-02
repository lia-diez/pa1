using System; 
 
namespace asd1  
{  
    public static class Placement  
    {  
        public static int[] Generate()  
        {  
            Random random = new Random();  
            int[] array = new int[8];  
            for (int i = 0; i < array.Length; i++)  
            {  
                array[i] = random.Next(8);  
                // array[i] = i; 
            }  
 
            for (int i = 0; i < array.Length; i++)  
            {  
                Swap(ref array[i], ref array[random.Next(0, 8)]);  
            } 
 
            return array;  
        }  
 
        private static void Swap(ref int a, ref int b)  
        {  
            (a, b) = (b, a);  
        }  
    }  
}