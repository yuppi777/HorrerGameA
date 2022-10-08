using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound1);


        audioSource.PlayOneShot(sound2);
        Invoke("SceneLoad", 3f);

    }

    void SceneLoad()
    {
        //SceneManager.LoadScene("Title");
    }
}
