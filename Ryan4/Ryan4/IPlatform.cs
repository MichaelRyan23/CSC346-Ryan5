/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSc 346
*** ASSIGNMENT :    4
*** DUE DATE :      4/5/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : Defines the IPlatform interface that all platform classes
*** must satisfy with their own implementation. Each platform class provides
*** it's own intro.
********************************************************************/
using System;
namespace StoreNS;

public interface IPlatform {

/********************************************************************
*** METHOD Introduction
*********************************************************************
*** DESCRIPTION : Displays a greeting message to the specified store section
*** (PS5 or switch in this case)
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS :  
*** RETURN : N/A
********************************************************************/
    void Introduction();
}