using UnityEngine;

public class DestroyEmpty : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
