using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pet : MonoBehaviour
{
    [SerializeField] private TransformVariable target;
    [SerializeField] private GameEvent treatDropEvent;
    [SerializeField] private GameEvent treatDeliveredEvent;
    [SerializeField] private IntVariable score;
    [SerializeField] private TransformVariable human;
    private Vector3 destination;
    private NavMeshAgent agent;
    private new Transform transform;
    private WaitForSeconds timeCheckWait = new WaitForSeconds(0.5f);

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        transform = base.transform;
    }

    private void OnEnable()
    {
        treatDropEvent.gameEvent.AddListener(GoToDestination);
    }

    private void GoToDestination()
    {
        destination = new Vector3(target.value.position.x, agent.transform.position.y, target.value.position.z);

        agent.SetDestination(destination);

        StartCoroutine(CheckDestinationReached());
    }

    private IEnumerator CheckDestinationReached()
    {
        while (Vector3.Distance(transform.position, destination) > agent.stoppingDistance)
            yield return timeCheckWait;

        if (target.value == human.value)
            DropTreat();
        else
            PickupTreat();
    }

    private void PickupTreat()
    {
        target.value.SetParent(transform);

        target.value = human.value;

        GoToDestination();
    }

    private void DropTreat()
    {
        Destroy(transform.GetChild(0).gameObject);

        target.value = null;

        score.value += 1;

        treatDeliveredEvent.gameEvent.Invoke();
    }

    private void OnDisable()
    {
        treatDropEvent.gameEvent.RemoveListener(GoToDestination);
    }
}
