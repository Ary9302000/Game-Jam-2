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
    public Transform home;
    public Transform resourceTarget;
    public float speed = 5;
    public bool selected = false;
    public int gatherRate = 5;
    public float gatherAmount = 0;
    public int gatherMax = 50;
    bool gathering = false;
    public string resource;


    // Start is called before the first frame update
    private void Awake()
    {
        navmesh = GetComponent<NavMeshAgent>();
        myPos = transform.position;
        target = myPos;
        navmesh.SetDestination(target);
        Update();
    }

    // Update is called once per frame
    private void Update()
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
                gathering = false;
                navmesh.SetDestination(target);
                if (hit.collider.CompareTag("Resource"))
                {
                    Gather(hit.collider.gameObject);
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Select(gameObject);
            }
        }
        if (gathering)
        {
            Debug.Log("gathering");
            navmesh.SetDestination(resourceTarget.position);
            if(Vector3.Distance(myPos, resourceTarget.position) <= navmesh.stoppingDistance)
            {
                navmesh.isStopped = true;
                Debug.Log("near resource");
                if(gatherAmount < gatherMax)
                {
                    gatherAmount += gatherRate * Time.deltaTime;
                    var script = resourceTarget.GetComponent<Resource>();
                    script.ChangeResource(gatherRate * Time.deltaTime);
                }
                else
                {
                    navmesh.SetDestination(home.position);
                }
            }
            if (Vector3.Distance(myPos, home.position) <= navmesh.stoppingDistance)
            {
                var otherScript = GetComponent<Player>();
//                otherScript.gameObject.SendMessage("Change" + resource, gatherAmount);
                gatherAmount = 0;
                navmesh.SetDestination(resourceTarget.position);
            }
            else
            {
                Debug.Log("I'm walking");
            }
        }
    }

    private void Gather(GameObject obj)
    {
        if (obj.name == "Tree")
        {
            resource = "Wood";
        } else if (obj.name == "Stone")
        {
            resource = "Stone";
        }
        else
        {
            resource = "Food";
        }
        resourceTarget = obj.transform;
        gathering = true;
    }

    public static void Select(GameObject gb)
    {
        gb.GetComponent<VillagerAI>().selected = !gb.GetComponent<VillagerAI>().selected;
    }
}
