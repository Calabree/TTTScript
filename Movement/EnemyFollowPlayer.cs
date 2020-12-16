using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    private Transform player;
    NavMeshAgent agent;
    public float lineOfSight;

    public float fireRate = 1;
    public float nextFireTime;

    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            agent.isStopped = false;

            agent.destination=player.position;
        }

        if (distanceFromPlayer > lineOfSight)
        {
            agent.isStopped=true;
        }

        if (distanceFromPlayer <= shootingRange && nextFireTime<Time.time)
        {
            agent.isStopped = true;
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
