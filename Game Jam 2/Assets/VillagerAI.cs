using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerAI : MonoBehaviour
{

    private NavMeshAgent navmesh;
    public Vector3 target;
    public Vector3 myPos;
    public float speed = 5;
    public bool selected = false;
    public int gatherRate = 5;
    public int gatherMax = 50;
    public string resource;


    // Start is called before the first frame update
    private void Awake()
    {
        navmesh = GetComponent<NavMeshAgent>();
        myPos = transform.position;
        target = myPos;
        navmesh.SetDestination(target);
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 temp;
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    temp = hit.point;
                    target = temp;
                }
                navmesh.SetDestination(target);
                Select(gameObject);
            }
            if (Input.GetMouseButtonDown(1))
            {
                Select(gameObject);
            }
    }
}

    public static void Select(GameObject gb)
    {
        gb.GetComponent<VillagerAI>().selected = !gb.GetComponent<VillagerAI>().selected;
    }
}
