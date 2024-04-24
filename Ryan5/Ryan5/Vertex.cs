/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSC 346
*** ASSIGNMENT :    5
*** DUE DATE :      4/24/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : This files defines the Vertex class that is used
*** in Graph.cs (and implemented). Each vertex has a number, a boolean
*** value that determines if it is considered visited or not, and also has
*** adjacency checks with other vertices.
********************************************************************/

using System;
using System.Collections.Generic;
namespace GraphNS;

public class Vertex {

    public int Number { get; set; }
    public bool Visited { get; set; }
    public List<bool> AdjVertices { get; set; }

/********************************************************************
*** METHOD Constructor 
*********************************************************************
*** DESCRIPTION : Initializes a new instance of the vertex class with optional
*** parameters!
*** INPUT ARGS : int number, bool visited, List<bool>? adjVertices
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : 
********************************************************************/
    public Vertex(int number = 0, bool visited = false, List<bool>? adjVertices = null) {
        Number = number;
        Visited = visited;
        AdjVertices = adjVertices ?? new List<bool>();
    }
}