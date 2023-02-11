using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class AgentDefender : MonoBehaviour
{
    public Transform[] points;
    private int _destPoint = 0;
    private NavMeshAgent _agent;
    public GameObject _target;
    private bool inArea = false;
    public static float chaspeed = 0.003f;

    [SerializeField] Animator animator;

    private const string key_isWalk = "IsWalk";
    private const string key_isRun = "IsRun";


    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(key_isWalk, true);
        _agent = GetComponent<NavMeshAgent>();
        _agent.autoBraking = false;
        GotoNextPoint();
    }
    
    void FixedUpdate()
    {
        if (_agent.remainingDistance < 0.01f)
            GotoNextPoint();


        if (inArea == true && _target.activeInHierarchy == true)
        {
            _agent.destination = _target.transform.position;
            EneChasing();
        }
    }
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        _agent.destination = points[_destPoint].position;
        _destPoint = (_destPoint + 1) % points.Length;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = true;
            _target = other.gameObject;
            animator.SetBool(key_isRun, true);
            animator.SetBool(key_isWalk, false);
            EneChasing();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = false;
            animator.SetBool(key_isWalk, true);
            animator.SetBool(key_isRun, false);
            GotoNextPoint();
        }
    }
    public void EneChasing()
    {

        transform.position += transform.forward * chaspeed ;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            SceneManager.LoadScene("GameOver");
        }
    }
}






