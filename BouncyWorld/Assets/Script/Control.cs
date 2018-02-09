using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Control : MonoBehaviour {
    public Panel gameover;
    public AudioClip gameon;
    public AudioClip gameoff;
    private AudioSource audioSource;

    public static Control instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameon;
        audioSource.Play();
    }
    public void GameOver()
    {
        gameover.Toggle(true);
        audioSource.Stop();
        audioSource.clip = gameoff;
        audioSource.Play();
    }
    public void OpenScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
