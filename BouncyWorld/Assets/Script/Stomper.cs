using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour {
    public GameObject shadowPrefab;
    private GameObject shadow;
    public void InitiateShadow()
    {
        shadow = Instantiate(shadowPrefab);
        shadow.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        shadow.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
    }
    public void DestroyShadow()
    {
        Destroy(shadow.gameObject);
    }
}
