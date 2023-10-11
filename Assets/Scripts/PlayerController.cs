using System.Security;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Score = 0;

    [Range(1, 15)]
    public float JumpVelocity;

    private Rigidbody2D rb;
    [SerializeField] private LayerMask groundMask;

    private float _fallMultiplier = 2f;
    private float _lowJumpMultiplier = 1.5f;

    public GameObject weapon;
    private bool _isDeployed = false;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Attack();
    }

    private void Jump()
    {
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
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

    private void Attack()
    {
        if (!_isDeployed && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //_isDeployed = true;
            Instantiate(weapon, new Vector3(gameObject.transform.position.x + .5f, gameObject.transform.position.y, -1.5f), gameObject.transform.rotation);
        }
    }

    private bool isGrounded()
    {
        CapsuleCollider2D col = gameObject.GetComponent<CapsuleCollider2D>();
        float groundSensitivity = .25f;

        RaycastHit2D boxHit = Physics2D.BoxCast(col.bounds.center, col.size, 0f, Vector2.down, groundSensitivity, groundMask);
        Color boxColor;
        if (boxHit.collider != null)
            boxColor = Color.green;
        else
            boxColor = Color.red;

        Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x, 0), Vector2.down * (col.bounds.extents.y + groundSensitivity), boxColor);
        Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x, 0), Vector2.down * (col.bounds.extents.y + groundSensitivity), boxColor);
        Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x, col.bounds.extents.y + groundSensitivity), Vector2.right * col.bounds.extents.y, boxColor);

        return boxHit.collider != null;
    }

    public void UpdateScore(GameObject obj)
    {
        if (obj.TryGetComponent(out Coin coin))
        {
            Score += 1;
        }
    }

}
