using System;

namespace GraphAdjacencyMatrix
{
    class Graph
    {
        private int[,] adjacencyMatrix;
        private int vertexCount;

        public Graph(int vertexCount)
        {
            this.vertexCount = vertexCount;
            adjacencyMatrix = new int[vertexCount, vertexCount];
        }

        public void AddEdge(int startVertex, int endVertex, int weight = 1)
        {
            if (startVertex >= vertexCount || endVertex >= vertexCount)
                throw new ArgumentOutOfRangeException("Vertex does not exist");
            adjacencyMatrix[startVertex, endVertex] = weight;
        }

        public void RemoveEdge(int startVertex, int endVertex)
        {
            if (startVertex >= vertexCount || endVertex >= vertexCount)
                throw new ArgumentOutOfRangeException("Vertex does not exist");
            adjacencyMatrix[startVertex, endVertex] = 0;
        }

        public bool HasEdge(int startVertex, int endVertex)
        {
            if (startVertex >= vertexCount || endVertex >= vertexCount)
                throw new ArgumentOutOfRangeException("Vertex does not exist");
            return adjacencyMatrix[startVertex, endVertex] != 0;
        }

        public bool IsVertexIsolated(int vertex)
        {
            if (vertex >= vertexCount)
                throw new ArgumentOutOfRangeException("Vertex does not exist");

            for (int i = 0; i < vertexCount; i++)
            {
                if (adjacencyMatrix[vertex, i] != 0 || adjacencyMatrix[i, vertex] != 0)
                    return false;
            }
            return true;
        }

        public void PrintGraph()
        {
            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(5);

            // Добавление ребер
            graph.AddEdge(0, 1, 5);
            graph.AddEdge(0, 2, 3);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 3, 2);

            // Вывод матрицы смежности
            Console.WriteLine("Graph after adding edges:");
            graph.PrintGraph();

            // Проверка наличия ребра
            Console.WriteLine("\nChecking if edge (0, 1) exists: " + graph.HasEdge(0, 1));

            // Проверка изолированности вершины
            Console.WriteLine("Checking if vertex 4 is isolated: " + graph.IsVertexIsolated(4));

            // Удаление ребра
            graph.RemoveEdge(0, 1);
            Console.WriteLine("\nGraph after removing edge (0, 1):");
            graph.PrintGraph();
        }
    }
}
