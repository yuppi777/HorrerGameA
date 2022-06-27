using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string _sceneName;
   public void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
