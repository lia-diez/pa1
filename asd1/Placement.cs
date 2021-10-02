using System; 
 
namespace asd1 
{ 
    public static class Placement 
    { 
        public static byte[] Generate() 
        { 
            Random random = new Random(); 
            byte[] array = new byte[8]; 
            for (byte i = 0; i < array.Length; i++) 
            { 
                // array[i] = (byte)random.Next(8); 
                array[i] = i;
            } 
 
            for (byte i = 0; i < array.Length; i++) 
            { 
                Swap(ref array[i], ref array[random.Next(0, 8)]); 
            }
            
            return array; 
        } 
 
        private static void Swap(ref byte a, ref byte b) 
        { 
            (a, b) = (b, a); 
        } 
    } 
}