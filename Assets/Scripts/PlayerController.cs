using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Score = 0;

    private Rigidbody2D rb;
    [SerializeField] private bool _isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            rb.AddForce(Vector2.up * 500);
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
