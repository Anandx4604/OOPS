using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sealed_Class
{
    public class Sample
    {
        
    }

    public sealed class Student:Sample
    {

    }

    public class Employee: Student //cannot inherit form sealed classes
    {

    }
}