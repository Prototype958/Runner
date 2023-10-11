using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnZone : MonoBehaviour
{
    public List<GameObject> enemyPatterns;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SpawnEnemyPattern();
        }
    }

    private void SpawnEnemyPattern()
    {
        Instantiate(enemyPatterns[0], gameObject.transform.position, gameObject.transform.rotation);
    }
}
