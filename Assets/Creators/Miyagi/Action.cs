using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] private GameObject boardPanel;

    private void Awake()
    {
        boardPanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (boardPanel.activeSelf)
            {
                boardPanel.SetActive(false);
            }
            ObjectAction();

        }

        
    }

    void ObjectAction()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
        if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Board"))
                {
                    if (!boardPanel.activeSelf) 
                    { 
                        boardPanel.SetActive(true); 
                    }
                }
            }
    }
}
