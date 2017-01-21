using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Utils
{
    public static float Distance2D(Vector3 v1, Vector3 v2)
    {
        Vector2 v12d = new Vector2(v1.x, v1.y);
        Vector2 v22d = new Vector2(v2.x, v2.y);

        return Vector2.Distance(v12d, v22d);
    }

    public static float Distance2DinKm(Vector3 v1, Vector3 v2)
    {
        return GameUnitsToKilometers(Distance2D(v1, v2));
    }

    public static float GameUnitsToKilometers(float gameUnits)
    {
        return 610 / GameConstans.MAX_MAP_X * gameUnits;
    }
}
