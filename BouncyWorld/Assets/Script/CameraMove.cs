using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Transform player;
    public float shakeDuration= 0f;
    public float shakeAmount = 0.05f;
    public float decreaseFactor = 1.0f;
    public float hight;
    Vector3 originPos;
    // Update is called once per frame
    private void Awake()
    {
        player = FindObjectOfType<PlayerCtrl>().transform;
    }
    void Update()
    {
        if (player)
        {
            originPos = new Vector3(player.position.x, hight, player.position.z);
            if (shakeDuration > 0)
            {
                transform.localPosition = originPos + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                transform.position = originPos;
            }
        }
    }
}
