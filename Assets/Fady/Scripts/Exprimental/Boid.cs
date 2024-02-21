using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Boid : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject[] myNeighbors;
    // Start is called before the first frame update
    void Start()
    {
        myNeighbors = BoidsManager.instance.boids;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = Truncate((((Alignment() +cohesion())/2) + Seperation()));
        
        
    }
    Vector3 Truncate(Vector3 velocity) {

        if (velocity.magnitude > BoidsManager.instance.MaxSpeed)
        {
            velocity = (velocity.normalized) * BoidsManager.instance.MaxSpeed;
        }
        else if(velocity.magnitude < BoidsManager.instance.MinSpeed) { 
        
            velocity = (velocity.normalized) * BoidsManager.instance.MinSpeed;
        }
        return velocity;

    }
    private Vector3 Alignment()
    {
        //Debug.Log(BoidsManager.instance.boidCounter);
        Vector3 tempAlign = Vector3.zero;
        if (BoidsManager.instance.boidCounter > 1)
        {
            for (int i = 0; i < BoidsManager.instance.boidCounter; i++)
            {
                if (myNeighbors[i] != this.gameObject)
                {
                    tempAlign += myNeighbors[i].transform.forward;
                }
                
            }
            tempAlign /= BoidsManager.instance.boidCounter-1;
            tempAlign *= 0.2f;
            tempAlign += (BoidsManager.instance.GOAL.position-this.transform.position).normalized;
            //tempAlign=tempAlign.normalized;
            //tempAlign = (tempAlign+BoidsManager.instance.GOAL.position;
        }
        return tempAlign;
    }
    private Vector3 cohesion()
    {
        Vector3 tempCohesion= Vector3.zero;
        if (BoidsManager.instance.boidCounter > 1)
        {
            for (int i = 0; i < BoidsManager.instance.boidCounter; i++)
            {
                if (myNeighbors[i] != this.gameObject)
                {
                    tempCohesion += myNeighbors[i].transform.position;
                }
            }
            tempCohesion /= BoidsManager.instance.boidCounter - 1;
            //if not mob
            tempCohesion = (tempCohesion-this.gameObject.transform.position).normalized;
            tempCohesion *= 0.2f;
            tempCohesion += (BoidsManager.instance.GOAL.position - this.transform.position).normalized;
            //tempCohesion += Random.insideUnitSphere*0.2f;
            //tempCohesion -= this.transform.position;
            //tempCohesion = tempCohesion.normalized;
            //tempCohesion = Vector3.zero;
        }
        return tempCohesion;
    }
    private Vector3 Seperation()
    {
        Vector3 tempSeperation = Vector3.zero;
        Vector3 ignoreSeperation=Vector3.zero;
        int boidsToAvoid = 0;
        if (BoidsManager.instance.boidCounter > 1)
        {
            for (int i = 0; i < BoidsManager.instance.boidCounter; i++)
            {
                if (myNeighbors[i] != this.gameObject)
                {
                    if (Vector3.Distance(myNeighbors[i].transform.position, this.transform.position) < BoidsManager.instance.seperationDistance)
                    {
                        boidsToAvoid++;
                        Debug.Log(boidsToAvoid);
                        tempSeperation += (this.transform.position - myNeighbors[i].transform.position).normalized;
                    }
                }
            }
            if (boidsToAvoid > 0)
            {
                Debug.Log(tempSeperation);
                tempSeperation /= boidsToAvoid;
                
                ignoreSeperation = Vector3.Lerp(Vector3.zero,tempSeperation, Mathf.Clamp01(Vector3.Distance(this.transform.position, BoidsManager.instance.GOAL.position) /BoidsManager.instance.seperationDistance-1));

                //ignoreSeperation = Vector3.Lerp(tempSeperation, Vector3.zero, Vector3.Distance(this.transform.position, BoidsManager.instance.GOAL.position).normalize);
            }

        }
        return ignoreSeperation;

    }


}
