using System; 
using System.Collections.Generic; 
using System.Diagnostics; 
 
namespace asd1 
{ 
    public class Search 
    { 
        public static int[] BFS(int[] array) 
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
 
        public static int[] RBFS(int[] array) 
        { 
            Node root = new Node(array, 0); 
            if (root.Difficulty == 0) return root.Data; 
            root = RBFS(root, 255); 
            return root.Data; 
        } 
 
        private static Node RBFS(Node state, int limit) 
        { 
            state.GetStates();
            List<Node> successors = state.Children;
            successors.Sort((a, b) => a.GetF1.CompareTo(b.GetF1));
            if (successors[0].Difficulty == 0)  
                return successors[0]; 
            if (successors[0].GetF1 > limit) 
                return null; 
 
            Node result = null; 
            while (successors.Count > 1 && result == null) 
            { 
                result = RBFS(successors[0], Math.Min(limit, successors[1].GetF1)); 
                successors.RemoveAt(0);
            } 
 
            return result; 
        } 
 
        private static void Get2Best(List<Node> states, out Node best, out int alternative) 
        { 
            best = new Node(); 
            best.F1 = Int32.MaxValue; 
            alternative = Int32.MaxValue; 
 
            for (int i = 0; i < states.Count; i++) 
            { 
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
        } 
    } 
}