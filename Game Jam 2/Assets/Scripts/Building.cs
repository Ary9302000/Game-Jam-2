using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int WoodCost;
    public int StoneCost;
    public int FoodCost;

    public int GetWCost()
    {
        return WoodCost;
    }
    public int GetSCost()
    {
        return StoneCost;
    }
    public int GetFCost()
    {
        return FoodCost;
    }
}
