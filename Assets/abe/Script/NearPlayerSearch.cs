using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NearPlayerSearch : MonoBehaviour
{
    [SerializeField] GameObject yamiko;

    private void Start()
    {
        NavMeshAgent nav =  yamiko.GetComponent<NavMeshAgent>() ;
        nav.speed = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AgentDefender.chaspeed = 0f;
            Debug.Log("見失った");
        }
    }
}
