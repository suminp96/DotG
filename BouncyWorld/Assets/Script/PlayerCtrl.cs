using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour {
    public float speed;
    public float jump;
    public Image healthbar;
    public GameObject particle;
    public GameObject damage;
    public Image gameOver;

    private AudioSource audioSource;
    private int hp;
    private int currhp;
    private Rigidbody rb;
    private bool onGround;
    private CameraMove cam;
    private DirPad dp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speed = 8f;
        jump = 5f;
        hp = 20;
        currhp = hp;
        onGround = true;
        cam = FindObjectOfType<CameraMove>();
        dp = FindObjectOfType<DirPad>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (currhp <= 0)
        {
            Death();
        }
    }
    void FixedUpdate()
    {
        Move();
        if (Input.GetButton("Jump"))
        {
            Jump();
        }
    }
    
    void Move()
    {
        Vector3 move;
        if (dp.dragging)
        {
            move = dp.dir.normalized;
            move.z = move.y;
        }
        else
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            move = new Vector3(h, 0f, v).normalized;
        }
        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);
    }
    public void Jump()
    {
        if (onGround)
        {
            rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currhp -= 1;
            cam.shakeDuration = 0.35f;
            var dam = Instantiate(damage, transform);
            Destroy(dam.gameObject, 0.5f);
            Destroy(collision.gameObject);
            audioSource.Play();
        }
        else if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
        healthbar.fillAmount = (float)currhp / hp;
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Damage")
        {
            currhp = 0;
            healthbar.fillAmount = (float)currhp / hp;
        }
    }
    void Death()
    {
        Instantiate(particle);
        particle.transform.position = transform.position;
        Control.instance.GameOver();
        Destroy(gameObject);
    }
}
