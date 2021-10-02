using System;
using System.Collections.Generic;

namespace asd1
{
    public class Node
    {
        public byte[] Data;
        public List<Node> Children;

        public byte Difficulty => GetDifficulty(Data);
        public byte Depth;

        public byte F1;

        public Node()
        {
        }
        public Node(byte[] data)
        {
            Data = data;
        }
        public Node(byte[] data, byte depth)
        {
            Data = data;
            Depth = depth;
        }

        public byte GetF1 => (byte) (Difficulty + Depth);
        public static byte GetDifficulty(byte[] array)
        {
            byte result = 0;

            for (int i = 0; i < 8; i++) // j - x, array[j] - y
            {
                bool isHorizontal = false;
                bool isMainDiagonal = false;
                bool isSideDiagonal = false;

                for (int j = 0; j < 8; j++)
                {
                    if (i == j) continue;

                    if (!isHorizontal && array[i] == array[j])
                    {
                        isHorizontal = true;
                        result++;
                    }

                    if (!isMainDiagonal && j - i == array[j] - array[i])
                    {
                        isMainDiagonal = true;
                        result++;
                    }

                    if (!isSideDiagonal && i - j == array[j] - array[i])
                    {
                        isSideDiagonal = true;
                        result++;
                    }
                }
            }

            return (byte) (result / 2);
        }

        public void GetStates()
        {
            Children = new List<Node>();
            for (byte i = 0; i < 8; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    if (Data[i] == j) continue;

                    byte[] temp = new byte[8];
                    Array.Copy(Data, temp, Data.Length);
                    temp[i] = j;
                    Children.Add(new Node(temp, (byte)(Depth + 1)));
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