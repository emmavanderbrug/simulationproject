using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour {

    public float distanceAway;
    public Transform thisObject;
    public int maxSpeedValue;
    public Transform player;
    public Collider playerCollider;
    private NavMeshAgent navMeshAgent;
    public float range_radius = 10;
    public float timer;
    public int maxTimerValue;
    private int timerValue;
    public int movementRadius;
    public Vector3 target;
   


    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        timerValue = Random.Range(2, maxTimerValue);
        navMeshAgent.speed = Random.Range(3, maxSpeedValue);
    }

    void Update()
    {
        Collider[] foundColliders = Physics.OverlapSphere(thisObject.position, range_radius);

        bool playerFound = false;

        timer += Time.deltaTime;

        if (timer >= timerValue)
        {
            Newtarget();
            timer = 0;
        }

        foreach (Collider coll in foundColliders)
        {
            if (coll == playerCollider)
                playerFound = true;
        }
        if (playerFound)
        {
            if (player)
            {
                navMeshAgent.speed = maxSpeedValue;
                navMeshAgent.SetDestination(player.position);
            }
            else
            {
                if (player = null)
                {
                    player = this.gameObject.GetComponent<Transform>();
                }
                else
                {
                    player = GameObject.FindGameObjectWithTag("Player").transform;
                }
            }
        }
    }

void Newtarget ()
    {
        Vector3 randomDirection = Random.insideUnitSphere * movementRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, movementRadius, 1);
        Vector3 finalPosition = hit.position;
        GetComponent<NavMeshAgent>().destination = finalPosition;
        timerValue = Random.Range(2, maxTimerValue);
        navMeshAgent.speed = Random.Range(3, maxSpeedValue);
    }
}
