using System.Collections;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Transform _player;

    private float _boostSpd = 0.025f;
    private float _speed = 0.015f;
    [SerializeField] private bool _isMoveable = true;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            ScrollBoost();
        }
        else
        {
            Scroll();
        }

        if (Vector2.Distance(new Vector2(_player.position.x, 0), new Vector2(gameObject.transform.position.x, 0)) < 0.05f)
            StopMove();
    }

    private void Scroll()
    {
        if (_isMoveable)
            gameObject.transform.Translate(Vector2.left * _speed);
    }

    private void ScrollBoost()
    {
        if (_isMoveable)
            gameObject.transform.Translate(Vector2.left * _boostSpd);
    }

    private void StopMove()
    {
        if (gameObject.GetComponent<PowerUp>() && _isMoveable)
        {
            _isMoveable = false;
            StartCoroutine(RestartMoveCountDown());
        }
    }

    private IEnumerator RestartMoveCountDown()
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(4);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y);
        _isMoveable = true;
    }
}
