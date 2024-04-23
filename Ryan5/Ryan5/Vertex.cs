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

public class Vertex {

    public int Number { get; set; }
    public bool Visited { get; set; }
    public List<bool> AdjVertices { get; set; }

    public Vertex(int number = 0, bool visited = false, List<bool> adjVertices = null) {
        Number = number;
        Visited = visited;
        AdjVertices = adjVertices ?? new List<bool>();
    }
}