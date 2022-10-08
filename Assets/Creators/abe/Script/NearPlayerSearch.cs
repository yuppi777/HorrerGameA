using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NearPlayerSearch : MonoBehaviour
{
    [SerializeField] GameObject yamiko;
    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        NavMeshAgent nav =  yamiko.GetComponent<NavMeshAgent>() ;
        nav.speed = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NavMeshAgent nav = yamiko.GetComponent<NavMeshAgent>();
            nav.speed = 8;
            audioSource.Stop();
            audioSource.PlayOneShot(sound2);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NavMeshAgent nav = yamiko.GetComponent<NavMeshAgent>();
            nav.speed = 2;
            audioSource.Stop();
            audioSource.PlayOneShot(sound1);
        }
    }
}
