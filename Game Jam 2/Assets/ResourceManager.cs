using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : Player
{
    public static int resourceValue = 0;
    public Text text;
    private void Start()
    {
        text.text = "0";
    }
    public void ChangeWood(int value)
    {
        woodValue += value;
        text.text = woodValue.ToString();
    }
    public void ChangeFood(int value)
    {
        foodValue += value;
        text.text = foodValue.ToString();
    }
    public void ChangeStone(int value)
    {
        stoneValue += value;
        text.text = stoneValue.ToString();
    }
}
