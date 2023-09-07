using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {
            col.gameObject.GetComponent<PlayerController>().UpdateScore(gameObject);
            Destroy(gameObject);
        }
    }
}
