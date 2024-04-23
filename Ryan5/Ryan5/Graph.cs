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

    private List<Vertex> vertices = new();

    public Queue<Vertex> GAQueue { get; set;} = new();
    public Stack<Vertex> GAStack { get; set;} = new();

    public Graph(string filePath) {
        GetData(filePath);
    }

    private void ResetVisitedSet() {
        foreach(var vertex in vertices) {
            vertex.Visited = false;
        }
    }

    private Vertex? GetAdjUnvisitedVertex(Vertex vert) {

        return vertices.FirstOrDefault(vertex => !vertex.Visited && vert.AdjVertices[vertices.IndexOf(vertex)]);

    }

    private void ViewVertex(Vertex vert) {
        Console.Write(vert.Number + " ");
    }

    // IAccessData Implementation
    private void GetData(string path) {

        try {
            string jsonString = File.ReadAllText(path);
            vertices = JsonSerializer.Deserialize<List<Vertex>>(jsonString)! ?? new List<Vertex>();
        }
        catch (Exception ex) {
            WriteLine(ex.Message);
        }
        
    }

    // IGraphAlgorithms Implementation

    public void BFS(int start) {
        // queue
        ResetVisitedSet();

        Vertex beginningVertex = vertices[start];
        beginningVertex.Visited = true;
        ViewVertex(beginningVertex);
        GAQueue.Enqueue(beginningVertex);

        while(GAQueue.Count > 0) {
            Vertex v = GAQueue.Dequeue();

            for(int i = 0; i < v.AdjVertices.Count; i++) {
                if(v.AdjVertices[i] && !vertices[i].Visited) {
                    Vertex neighbor = vertices[i];
                    neighbor.Visited = true;
                    ViewVertex(neighbor);
                    GAQueue.Enqueue(neighbor);
                }
            }
        }
        ResetVisitedSet();
    }

    public void DFS(int start) {
        // stack
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