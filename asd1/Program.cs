using System; 
using System.Text; 
 
namespace asd1 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            Console.OutputEncoding = Encoding.UTF8; 
            int[] array = Placement.Generate(); 
            Node root = new Node(array); 
            Console.WriteLine(root); 
            int[] ehfeorih = Search.RBFS(array); 
            Console.WriteLine(new Node(ehfeorih)); 
        } 
    } 
}