using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    static public int redLayer = 11;
    static public int greenLayer = 12;
    static public int blueLayer = 13;

    static public LayerMask GetEnemyLayer(Team team)
    {
        LayerMask mask = 0;
        switch (team)
        {
            case Team.Red:
                mask = (1 << greenLayer) | (1 << blueLayer);
                break;
            case Team.Blue:
                mask = (1 << greenLayer) | (1 << redLayer);
                break;
            case Team.Green:
                mask = (1 << redLayer) | (1 << blueLayer);
                break;
        }
        return mask;
    }
}
