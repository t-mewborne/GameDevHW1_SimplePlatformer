using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    [SerializeField] private LayerMask groundMask; //Note: serialized field allows the private value to appear in the inspector
    private CircleCollider2D cc;
    public float speed = 5f;
    public float jumpVelocity = 25f;
    private float jumpForce = 1000f;
    public Rigidbody2D rb;
    private Vector2 respawnpt;
    private int score = 0;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI levelCompleteText;

    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        respawnpt = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        scoreText.text = "Score: " + score;
    }

    private bool isGrounded() 
    {
        RaycastHit2D raycastHit2D = Physics2D.CircleCast(cc.bounds.center,cc.radius,Vector2.down,.1f,groundMask);
        return raycastHit2D.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if ("Respawn".Equals(collision.gameObject.tag))
        {
            transform.position = respawnpt;
            if (score > 0) score -= 2;
        }

        if ("Coin".Equals(collision.gameObject.tag))
        {
            score += 5;
        }

        if ("Finish".Equals(collision.gameObject.tag)) 
        {
            Destroy(this.gameObject);
            levelCompleteText.text = "Level\nComplete!";
        }
    }
}
