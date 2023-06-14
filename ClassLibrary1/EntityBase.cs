using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1;

public abstract class EntityBase
{
    protected object _lockObj = new ();
}