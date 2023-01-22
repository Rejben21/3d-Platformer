using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
    public Transform spikes, upPosition;
    private Vector3 startPos;

    public float moveSpeed, timeToWait;

    private bool shouldMove;

    void Start()
    {
        startPos = spikes.position;
    }

    void Update()
    {
        if(shouldMove)
        {
            spikes.position = Vector3.MoveTowards(spikes.position, upPosition.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            spikes.position = Vector3.MoveTowards(spikes.position, startPos, moveSpeed / 4 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(SpikesMove());
        }
    }

    private IEnumerator SpikesMove()
    {
        yield return new WaitForSeconds(timeToWait);

        shouldMove = true;

        yield return new WaitForSeconds(2);

        shouldMove = false;
    }
}
