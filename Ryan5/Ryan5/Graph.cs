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
namespace GraphNS;

public class Graph : IAccessData, IGraphAlgorithm {

    private List<Vertex> vertices = new List<Vertex>(); // private field

    private void ResetVisitedSet() {

    }

    private Vertex GetAdjUnvisitedVertex(Vertex vertex) {

    }

    private void ViewVertex(Vertex vertex) {

    }

    // IAccessData Implementation
    public void GetData(string path) {

        
    }

    // IGraphAlgorithms Implementation
    public Queue<Vertex> GAQueue { get; set;}
    public Stack<Vertex> GAStack { get; set;}

    public void BFS(int start) {

    }

    public void DFS(int start) {

    }

}