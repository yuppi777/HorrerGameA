using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class chenziScene : MonoBehaviour
{
    [SerializeField] string destSceneName;

    public void ChenzScene()
    {
        SceneManager.LoadScene(destSceneName);
    }
}
