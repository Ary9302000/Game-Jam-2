using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int populationValue = 5;
    public static int populationCapacity = 10;
    public static int woodValue = 0;
    public static int stoneValue = 0;
    public static int foodValue = 0;
    public float consumptionRate = 10f;
    public int prepDuration;
    public int winterDuration;
    public bool Winter;
    public GameObject clone;
    public GameObject storage;
    public bool building;

    // Start is called before the first frame update
    void Start()
    {
        clone = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (building)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 temp;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, 9))
            {
                temp = hit.point;
                clone.transform.position = temp;
                clone.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Place(clone);
            }
        }
    }

    public void Place(GameObject gameObject)
    {
        Instantiate(clone, clone.transform.position, clone.transform.rotation);
        if(clone.tag == "Cottage")
        {
            populationCapacity += 5;
        }
    }
}
