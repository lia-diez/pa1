using System; 
using System.Collections.Generic; 
 
namespace asd1 
{ 
    public class Node 
    { 
        public int[] Data; 
        public List<Node> Children; 
 
        public int Difficulty => GetDifficulty(); 
        public int Depth; 
 
        public int F1; 
        public int GetF1 => (int) (Difficulty + Depth); 
 
        public Node() 
        { 
        } 
        public Node(int[] data) 
        { 
            Data = data; 
        } 
        public Node(int[] data, int depth) 
        { 
            Data = data; 
            Depth = depth; 
        } 
 
        public int GetDifficulty() 
        { 
            int result = 0; 
 
            for (int i = 0; i < 8; i++) // j - x, array[j] - y 
            { 
                bool isHorizontal = false; 
                bool isMainDiagonal = false; 
                bool isSideDiagonal = false; 
 
                for (int j = 0; j < 8; j++) 
                { 
                    if (i == j) continue; 
 
                    if (!isHorizontal && Data[i] == Data[j]) 
                    { 
                        isHorizontal = true; 
                        result++; 
                    } 
 
                    if (!isMainDiagonal && j - i == Data[j] - Data[i]) 
                    { 
                        isMainDiagonal = true; 
                        result++; 
                    } 
 
                    if (!isSideDiagonal && i - j == Data[j] - Data[i]) 
                    { 
                        isSideDiagonal = true; 
                        result++; 
                    } 
                } 
            } 
 
            return (int) (result / 2); 
        } 
 
        public void GetStates() 
        { 
            Children = new List<Node>(); 
            for (int i = 0; i < 8; i++) 
            { 
                for (int j = 0; j < 8; j++) 
                { 
                    if (Data[i] == j) continue; 
 
                    int[] temp = new int[8]; 
                    Array.Copy(Data, temp, Data.Length); 
                    temp[i] = j; 
                    Children.Add(new Node(temp, (int)(Depth + 1)));  
                } 
            } 
        } 
 
        public override string ToString() 
        { 
            string result = ""; 
            for (int i = 0; i < 8; i++) 
            { 
                for (int j = 0; j < 8; j++) 
                { 
                    result += Data[i] == j ? "♛ " : (i + j) % 2 == 0 ? "▓▓" : "░░"; 
                } 
 
                result += " \n"; 
            } 
 
            return result; 
        } 
    } 
}