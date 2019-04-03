using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static int resourceValue = 0;
    public Text text;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        text.text = resourceValue.ToString();
    }

    public static void AddResource(int value)
    {
        resourceValue += value;
    }

    public static void RemoveResource(int value)
    {
        resourceValue -= value;
    }
}
