using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {
    public GameObject player;
    public float speed = 7f;
    private float lastTime;
    private Rigidbody rb;
    // Update is called once per frame
    private void Awake()
    {
        player = GameObject.Find("Player");
        speed = 5f;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate () {
        if (player)
        {
            Chase();
        }
    }
    void Chase()
    {
        Vector3 dir = player.transform.position-transform.position;
        rb.velocity = new Vector3(dir.normalized.x, 0, dir.normalized.z)*speed;
    }
}
