using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    [SerializeField] private int _maxHealth = 1;
    [SerializeField] private int _damage = 1;

    private ScrollingObject _scrolling;

    private void Start()
    {
        _scrolling = GetComponent<ScrollingObject>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {
            _scrolling.TogggleMove();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {
            _scrolling.TogggleMove();
        }
    }
}
