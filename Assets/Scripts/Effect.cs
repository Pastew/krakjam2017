using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Effect
{
    public int id;
    public int counter;
    public int lifeTime;

    public abstract void evaluate(City city);
    public abstract void recalculateData(City city);


    internal int GetID()
    {
        return id;
    }

}
