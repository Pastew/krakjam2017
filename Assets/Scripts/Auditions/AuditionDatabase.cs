using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class AuditionDatabase
{
    public static Dictionary<int, AuditionData> auditionDatabase = new Dictionary<int, AuditionData>
    {
        {0, new AuditionData("Głos wolności", 0, new int[] { }) },
        {1, new AuditionData("Głos czynu", 1, new int[] { }) },
        {2, new AuditionData("Głos wytrwałości", 1, new int[] {0,1,5 }) },
        {3, new AuditionData("Krytyka kapitalizmu", 6, new int[] {3,4,5}) },
        {4, new AuditionData("Dokument o USA", 10, new int[] { 3, 4, 5 }) },
        {5, new AuditionData("Pocieszenie Narodu", 13, new int[] { 3, 4, 5 }) },
        {6, new AuditionData("Wsparcie zamachu", 7, new int[] { 6, 7, 8 }) },
        {7, new AuditionData("Potępienie zamachu", 8, new int[] { 6, 7, 8 }) },
        {8, new AuditionData("Oszukaj służby", 9, new int[] { 6, 7, 8 }) },
        {9, new AuditionData("Zachwyt Ameryką", 11, new int[] { 11, 12 }) },
        {10, new AuditionData("Wyolbrzymienie problemów USA", 12, new int[] { 11, 12 }) }
    };

    internal static AuditionData GetAuditionData(int i)
    {
        AuditionData a = auditionDatabase[i];
        a.SetID(i);
        return a;
    }
}
