/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSC 346
*** ASSIGNMENT :    5
*** DUE DATE :      4/24/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : <detailed English description of the current assignment> ***
********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace GraphNS;

public class Graph : IAccessData, IGraphAlgorithms {

    private List<Vertex> vertices;

    public Graph(string filePath) {
        GetData(filePath);
    }

    private void ResetVisitedSet() {
        foreach(var vertex in vertices) {
            vertex.Visited = false;
        }
    }

    private Vertex GetAdjUnvisitedVertex(Vertex vert) {

        return vertices.FirstOrDefault(vertex => !vertex.Visited && vert.AdjVertices[vertices.IndexOf(vertex)]);

    }

    private void ViewVertex(Vertex vert) {
        WriteLine(vert.Number);
    }

    // IAccessData Implementation
    private void GetData(string path) {

        try {
            if(!File.Exists(path)) {
                throw new FileNotFoundException("The file doesn't exist!", path);
            }

            string jsonString = File.ReadAllText(path);
            vertices = JsonSerializer.Deserialize<List<Vertex>>(jsonString) ?? new List<Vertex>();
        }
        catch (Exception ex) {
            WriteLine(ex.Message);
        }
        
    }

    // IGraphAlgorithms Implementation
    //public Queue<Vertex> GAQueue { get; set;}
    //public Stack<Vertex> GAStack { get; set;}

    public void BFS(int start) {
        // queue
        


    }

    public void DFS(int start) {
        // stack
        Stack<Vertex> stack = new Stack<Vertex>();

        ResetVisitedSet();

        Vertex beginningVertex = vertices[start];
        beginningVertex.Visited = true;
        ViewVertex(beginningVertex);
        stack.Push(beginningVertex);

        while(stack.Count > 0) {
            Vertex v = stack.Peek();
            Vertex adjUnvisitedVertex = GetAdjUnvisitedVertex(v);

            if(adjUnvisitedVertex != null) {
                adjUnvisitedVertex.Visited = true;
                ViewVertex(adjUnvisitedVertex);
                stack.Push(adjUnvisitedVertex);
            } else {
                stack.Pop();
            }
        }
    }

}