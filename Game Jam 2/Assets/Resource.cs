using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int startValue;
    public float value;

    // Start is called before the first frame update
    void Start()
    {
        value = startValue = 250;
    }

    public void ChangeResource(float val)
    {
        value -= val;
    }
    // Update is called once per frame
    void Update()
    {
        if(value < 0)
        {
            Destroy(gameObject);
        }
    }
}
