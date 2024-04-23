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
using GraphNS;

try
{
    Graph graph = new Graph(@"C:\Users\Micha\Data_Share\graphData.json");
    
    // Perform a Depth-First Search starting at vertex 0
    Console.WriteLine("Depth-First Search (DFS) starting from vertex 0:");
    graph.DFS(0);
    
    // Separator for readability
    Console.WriteLine("---------------------\n");
    
    // Perform a Breadth-First Search starting at vertex 0
    Console.WriteLine("Breadth-First Search (BFS) starting from vertex 0:");
    graph.BFS(0);
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}