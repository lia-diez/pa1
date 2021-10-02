using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace asd1
{
    public class Search
    {
        public static byte[] BFS(byte[] array)
        {
            Node state = new Node(array);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(state);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (state.Difficulty != 0)
            {
                state.GetStates();
                foreach (var child in state.Children)
                {
                    queue.Enqueue(child);
                }

                state = queue.Dequeue();
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000);
            Console.WriteLine(state.Depth);
            return state.Data;
        }

        public static byte[] RBFS(byte[] array)
        {
            Node root = new Node(array, 0);
            byte resultFunc;
            (root, resultFunc) = RBFS(root, 255);
            return root.Data;
        }

        private static (Node, byte) RBFS(Node state, byte limit)
        {
            if (state.Difficulty == 0) 
                return (state, 0);
            state.GetStates();
            foreach (var child in state.Children)
            {
                child.F1 = child.GetF1;
            }

            while (true)
            {
                state.Children.Sort((a, b) => a.F1.CompareTo(b.F1));
                Node best = state.Children[0];
                Console.WriteLine(best);
                if (best.F1 > limit)
                    return (null, best.GetF1);
                byte alternative = state.Children[1].GetF1;
                (Node result, byte resultFunc) = RBFS(best, Math.Min(limit, alternative));
                state.Children[0] = best;
                state.Children[0].F1 = resultFunc;
                if (result != null) return (result, 0);
            }
        }

         private static void Get2Best(ref List<Node> states, out Node best, out byte alternative)
         {
             best = new Node();
             best.F1 = Byte.MaxValue;
             alternative = Byte.MaxValue;

             for (int i = 0; i < states.Count; i++)
             {
                 states[i].F1 = (byte) (states[i].Difficulty + states[i].Depth);
                 if (states[i].F1 <= best.F1)
                 {
                     alternative = best.F1;
                     best = states[i];
                 }
                 else if (states[i].F1 < alternative)
                 {
                     alternative = states[i].F1;
                 }
             }

             (best, states[0]) = (states[0], best);
         }
    }
}