using System;
using System.Collections.Generic;

namespace asd1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            byte[] array = Placement.Generate();
            // byte[] array = {2, 6, 1, 2, 5, 1, 3, 4};
            Node root = new Node(array);
            Console.WriteLine(root);
            // byte[] ehfeorih = Search.BFS(array);
            byte[] ehfeorih = Search.RBFS(array);
            Console.WriteLine(new Node(ehfeorih));
        }
    }
}