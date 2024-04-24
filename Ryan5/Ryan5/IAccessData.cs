/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSC 346
*** ASSIGNMENT :    5
*** DUE DATE :      4/24/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : This file is the interface for specifying the GetData
*** operation which basically deserializes information from a JSON file.
*** it's actual implementation can be found in Graph.cs.
********************************************************************/

using System;
using System.Collections.Generic;
namespace GraphNS;

public interface IAccessData {

/********************************************************************
*** METHOD GetData
*********************************************************************
*** DESCRIPTION : Helps open, access, and close the storage device (file)
*** ensuring that data is working and going into vertices correctly.
*** INPUT ARGS : string path
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : 
********************************************************************/
    void GetData(string path) {}

}
