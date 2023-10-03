using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AirSpawnNodes : MonoBehaviour
{
    public List<GameObject> CoinPatterns;
    public Coin Coin;

    private List<Transform> _nodes;
    private float _spawnTimer = .15f;
    private bool _spawning = false;

    private int _randPattern;
    private int _randNode;

    // Start is called before the first frame update
    void Start()
    {
        _nodes = new List<Transform>();
        GetSpawnNodes();
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
        _randPattern = Random.Range(0, CoinPatterns.Count);

        if (CoinPatterns[_randPattern].name.ContainsInsensitive("Row3"))
        {
            // Larger patterns are too big to spawn at the lowest nodes
            _randNode = Random.Range(0, _nodes.Count - 3);
        }
        else if (CoinPatterns[_randPattern].name.ContainsInsensitive("Row2"))
        {
            _randNode = Random.Range(0, _nodes.Count - 2);
        }
        else
        {
            _randNode = Random.Range(0, _nodes.Count);
        }

        Instantiate(CoinPatterns[_randPattern], _nodes[_randNode].transform.position, gameObject.transform.rotation);
    }

    private void GetSpawnNodes()
    {
        foreach (Transform child in GetComponentInChildren<Transform>())
            _nodes.Add(child);
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
            Instantiate(Coin, _nodes[Random.Range(0, _nodes.Count)].transform.position, gameObject.transform.rotation);
            yield return new WaitForSeconds(_spawnTimer);
            _spawning = false;
        }

    }
}
