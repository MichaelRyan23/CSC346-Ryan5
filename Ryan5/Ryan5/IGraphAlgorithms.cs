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

public interface IGraphAlgorithms {

    Queue<Vertex> GAQueue { get; set; }
    Stack<Vertex> GAStack { get; set; }

    void BFS(int start);
    void DFS(int start);
}
