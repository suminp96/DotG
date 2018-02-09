using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
    public float explosionForce;
    public float explosionRadius;
    public GameObject particle;
    public GameObject enemyExplodeParticle;

    private int score;
    private ScoreKeeper sk;

    private void Awake()
    {
        sk = FindObjectOfType<ScoreKeeper>();
        explosionForce = 100f;
        explosionRadius = 0.5f;
        score = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var part = Instantiate(particle);
            part.transform.position = transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
            Collider[] colls = Physics.OverlapSphere(transform.position, 10.0f);
            foreach(Collider coll in colls)
            {
                if (coll.gameObject.tag == "Enemy")
                {
                    score++;
                    var parti = Instantiate(enemyExplodeParticle);
                    parti.transform.position = new Vector3(coll.gameObject.transform.position.x, 2f, coll.gameObject.transform.position.z);
                    Destroy(coll.gameObject);
                }
                else if(coll.gameObject.tag == "Stomper")
                {
                    score += 5;
                    var parti = Instantiate(enemyExplodeParticle);
                    parti.transform.position = new Vector3(coll.gameObject.transform.position.x, 2f, coll.gameObject.transform.position.z);
                    coll.gameObject.GetComponent<Stomper>().DestroyShadow();
                    Destroy(coll.gameObject);
                }
            }
            sk.AddScore(score);
            score = 0;
            Destroy(this.gameObject);
        }
    }
}
