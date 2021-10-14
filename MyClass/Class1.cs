using System;
using MyAbstractClass;

namespace MyClass
{
    public class Class1 : Disposable
    {
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
