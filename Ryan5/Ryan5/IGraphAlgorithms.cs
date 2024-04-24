/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSC 346
*** ASSIGNMENT :    5
*** DUE DATE :      4/24/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION :IGraphAlgorithms interface, it declares the structure
*** for traversing the graphs, including two different ways. BFS utilizes
*** a queue while DFS utilizes a stack. This interface is implemented in 
*** Graph.cs
********************************************************************/

using System;
using System.Collections.Generic;
namespace GraphNS;

public interface IGraphAlgorithms {

    Queue<Vertex> GAQueue { get; set; }
    Stack<Vertex> GAStack { get; set; }

/********************************************************************
*** METHOD BFS
*********************************************************************
*** DESCRIPTION : Initiates a breadth-first traversal through a graph and its
*** vertices.
*** INPUT ARGS : start
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : 
********************************************************************/
    public abstract void BFS(int start);

/********************************************************************
*** METHOD DFS
*********************************************************************
*** DESCRIPTION : Initiates a depth-first traversal through a graph and its
*** vertices.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : 
********************************************************************/
    public abstract void DFS(int start);
}
