using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Panel : MonoBehaviour {
    public bool gameOver;
    public Material img;
    private void Awake()
    {
        Toggle(false);
    }
    public void Toggle(bool trigger)
    {
        gameObject.SetActive(trigger);
    }
    public void Update()
    {
        if (gameOver)
        {
            Toggle(true);
        }
    }
}
