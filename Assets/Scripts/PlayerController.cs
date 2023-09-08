using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Score = 0;

    [Range(1, 10)]
    public float JumpVelocity = 5;

    private Rigidbody2D rb;
    [SerializeField] private bool _isGrounded = true;

    private float _fallMultiplier = 1.5f;
    private float _lowJumpMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        // if (Input.GetKey(KeyCode.Space))
        // {
        //     rb.AddForce(Vector2.up * 10);

        //     if (Input.GetKeyUp(KeyCode.Space)){
        //         _isGrounded = false;
        //     }
        // }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * JumpVelocity;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * _fallMultiplier * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * _lowJumpMultiplier * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<FloorScroll>())
        {
            _isGrounded = true;
        }
    }

    public void UpdateScore(GameObject obj)
    {
        if (obj.TryGetComponent(out Coin coin))
        {
            Score += 1;
        }
    }

}
