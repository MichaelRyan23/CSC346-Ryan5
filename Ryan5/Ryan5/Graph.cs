/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSC 346
*** ASSIGNMENT :    5
*** DUE DATE :      4/24/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : This program creates a graph ADT with operations such as
*** depth-first and breadth-first searching. The graph class works with actually
*** managing the state of the graph, having vertices that are managed with
*** a custom vertex class. Also uses JSON deserialization, which is kinda cool.
********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace GraphNS;

public class Graph : IAccessData, IGraphAlgorithms {

    private List<Vertex> vertices = new();

    public Queue<Vertex> GAQueue { get; set;} = new();
    public Stack<Vertex> GAStack { get; set;} = new();

/********************************************************************
*** METHOD Constructor
*********************************************************************
*** DESCRIPTION : Initializes the graph with data from a given file path.
*** INPUT ARGS : string filePath
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : 
********************************************************************/
    public Graph(string filePath) {
        GetData(filePath);
    }

/********************************************************************
*** METHOD ResetVisitedSet
*********************************************************************
*** DESCRIPTION : Sets the visited state of all vertices to false!
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : 
********************************************************************/
    private void ResetVisitedSet() {
        foreach(var vertex in vertices) {
            vertex.Visited = false;
        }
    }

/********************************************************************
*** METHOD GetAdjUnvisitedVertex
*********************************************************************
*** DESCRIPTION : Retrieves the first adjacent unvisited vertex using a for
*** loop to walk through.
*** INPUT ARGS : Vertex vert
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : Vertex?
********************************************************************/
    private Vertex? GetAdjUnvisitedVertex(Vertex vert) {

        for(int i = 0; i < vert.AdjVertices.Count; i++) {
            if(vert.AdjVertices[i] && !vertices[i].Visited) {
                return vertices[i];
            }
        }
        return null;
    }

/********************************************************************
*** METHOD ViewVertex
*********************************************************************
*** DESCRIPTION : Outputs the number of a vertex (whichever one it's on)
*** INPUT ARGS : Vertex vert
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : 
********************************************************************/
    private void ViewVertex(Vertex vert) {
        Console.Write(vert.Number + " ");
    }

/********************************************************************
*** METHOD GetData
*********************************************************************
*** DESCRIPTION : Deserializes JSON data from a file and puts that information
*** into the vertices list.
*** INPUT ARGS : string path
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : 
********************************************************************/
    private void GetData(string path) {

        try {
            string jsonString = File.ReadAllText(path);
            vertices = JsonSerializer.Deserialize<List<Vertex>>(jsonString)! ?? new List<Vertex>();
        }
        catch (Exception ex) {
            WriteLine(ex.Message);
        }
        
    }

/********************************************************************
*** METHOD BFS
*********************************************************************
*** DESCRIPTION : When called, performs a breadth first search on a given
*** vertex.
*** INPUT ARGS : int start
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : 
********************************************************************/
    public void BFS(int start = 0) {
        // queue
        if(vertices.Count == 0 || start < 0 || start >= vertices.Count) {
            WriteLine("Invalid start vertex!");
            return;
        }

        ResetVisitedSet();

        Vertex beginningVertex = vertices[start];
        beginningVertex.Visited = true;
        ViewVertex(beginningVertex);
        GAQueue.Enqueue(beginningVertex);

        while(GAQueue.Count > 0) {
            Vertex v = GAQueue.Dequeue();

            Vertex? adjVertex;

            while((adjVertex = GetAdjUnvisitedVertex(v)) != null) {
                adjVertex.Visited = true;
                ViewVertex(adjVertex);
                GAQueue.Enqueue(adjVertex);
            }
        }
        ResetVisitedSet();
    }

/********************************************************************
*** METHOD DFS
*********************************************************************
*** DESCRIPTION : When called, performs a depth-first search on a given vertex.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : 
********************************************************************/
    public void DFS(int start = 0) {
        // stack
        if(vertices.Count == 0 || start < 0 || start >= vertices.Count) {
            WriteLine("Invalid start index!");
            return;
        }
        ResetVisitedSet();

        Vertex beginningVertex = vertices[start];
        beginningVertex.Visited = true;
        ViewVertex(beginningVertex);
        GAStack.Push(beginningVertex);

        while(GAStack.Count > 0) {
            Vertex v = GAStack.Peek();
            Vertex? adjUnvisitedVertex = GetAdjUnvisitedVertex(v);

            if(adjUnvisitedVertex != null) {
                adjUnvisitedVertex.Visited = true;
                ViewVertex(adjUnvisitedVertex);
                GAStack.Push(adjUnvisitedVertex);
            } else {
                GAStack.Pop();
            }
        }
        ResetVisitedSet();
    }
}