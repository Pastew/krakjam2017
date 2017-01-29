using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AuditionData
{
    public int id;
    public int[] idsToRemoveWhenChosen;
    public string description;
    public int effectID;

    public AuditionData(string description, int effectID, int[] idsToRemoveWhenChosen)
    {
        this.id = -1;
        this.idsToRemoveWhenChosen = idsToRemoveWhenChosen;
        this.description = description;
        this.effectID = effectID;
    }

    internal void SetID(int id)
    {
        this.id = id;
    }
}
