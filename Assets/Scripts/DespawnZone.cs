using UnityEngine;

public class DespawnZone : MonoBehaviour
{
    [SerializeField] private GameObject _spawnZone;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<FloorScroll>())
            col.gameObject.GetComponent<FloorScroll>().ResetPosition();
        else if (col.gameObject.GetComponent<Coin>() ||
                 col.gameObject.GetComponent<Enemy>())
            Destroy(col.gameObject);
    }
}
