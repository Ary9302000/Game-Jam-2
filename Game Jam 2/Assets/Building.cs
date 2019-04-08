using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int WoodCost;
    public int StoneCost;
    public int FoodCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
