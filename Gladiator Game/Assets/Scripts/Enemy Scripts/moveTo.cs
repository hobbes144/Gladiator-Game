using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTo : MonoBehaviour
{
    [SerializeField] private Transform goal;
    private NavMeshAgent agent;
    private float timer = 0f;
    private float threshold = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= threshold)
        {
            agent.destination = goal.position;
            timer = 0f;
        }
    }

    public void setTarget(Transform newGoal)
    {
        goal = newGoal;
    }
}
