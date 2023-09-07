using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSpawnZone : MonoBehaviour
{
    public GameObject coinPattern;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float randY = Random.Range(-2.0f, 2.0f);
            //Instantiate(coinPattern, gameObject.transform);
            Instantiate(coinPattern, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + randY, 0), gameObject.transform.rotation);
        }
    }
}
