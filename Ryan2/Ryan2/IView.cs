/********************************************************************
*** NAME :          Michael Ryan   
*** CLASS :         CSC 346
*** ASSIGNMENT :    A2
*** DUE DATE :      2/26/2024
*** INSTRUCTOR :    GAMRADT
*********************************************************************
*** DESCRIPTION : This assignment involved creating an ADT within a namespace
*** called VikingNS. The ADT is made from a viking class that has 5 "characteristics"
*** There is also a global class for global enums Status and Weapon, along with
*** an interface called IView. Alongside the constructor is also some basic
*** exception handling techniques we learned in class.
********************************************************************/
namespace VikingNS
{
    
    public interface IView
    {
        void ViewH();
        void ViewV();
    }

}