using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Effect
{
    protected int id;
    protected int counter;
    protected int lifeTime;

    public abstract bool evaluate(City city);

}
