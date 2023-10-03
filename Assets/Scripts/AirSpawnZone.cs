using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSpawnZone : MonoBehaviour
{
    public List<GameObject> coinPatterns;
    public Coin coin;

    private BoxCollider2D _zone;
    private float _spawnTimer = .15f;
    private bool _spawning = false;

    private float _boundsMax;
    private float _boundsMin;

    private int _randPattern;

    private void Start()
    {
        _zone = gameObject.GetComponent<BoxCollider2D>();
        _boundsMax = transform.position.y + _zone.bounds.extents.y;
        _boundsMin = transform.position.y - _zone.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SpawnCoinPattern();

        if (Input.GetKey(KeyCode.LeftControl))
            CoinFlurry();
    }

    private void SpawnCoinPattern()
    {
        _randPattern = Random.Range(0, coinPatterns.Count);
        Instantiate(coinPatterns[_randPattern], new Vector3(gameObject.transform.position.x, GetSpawnRange(), 0), gameObject.transform.rotation);
    }

    private float GetSpawnRange()
    {
        // float pos;

        // switch (pattern)
        // {
        //     case 0:
        //         pos = Random.Range(-_zone.bounds.extents.y, _zone.bounds.extents.y);
        //         break;
        //     case 1:
        //         pos = Random.Range(-0.75f, 2.0f);
        //         break;
        //     default:
        //         pos = -1f;
        //         break;
        // }

        //return pos;

        float pos = Random.Range(_boundsMin, _boundsMax);

        if (pos >= _boundsMax)
        {
            Debug.Log("too high");
            Bounds b = coinPatterns[_randPattern].GetComponent<GetPatternSize>().Calculate();

            //pos -= b.extents.y;
        }
        if (coinPatterns[_randPattern].GetComponent<GetPatternSize>())
        {
            coinPatterns[_randPattern].GetComponent<GetPatternSize>().Calculate();
        }

        return pos;
    }

    private void CoinFlurry()
    {
        StartCoroutine(SpawnCoinFlurry());
    }

    private IEnumerator SpawnCoinFlurry()
    {
        if (!_spawning)
        {
            _spawning = true;
            Instantiate(coin, new Vector3(gameObject.transform.position.x, GetSpawnRange(), 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(_spawnTimer);
            _spawning = false;
        }

    }
}
