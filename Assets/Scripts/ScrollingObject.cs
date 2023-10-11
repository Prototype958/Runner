using System;
using System.Collections;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Transform _player;

    private float _boostSpd = 7f;
    private float _speed = 5f;
    private bool _isMoveable = true;

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

        CheckStopMove();
    }

    public void DisableMove()
    {
        _isMoveable = false;
    }

    public void TogggleMove()
    {
        _isMoveable = !_isMoveable;
    }

    private void CheckStopMove()
    {
        if (gameObject.GetComponent<PowerUp>() && _isMoveable)
        {
            if (Vector2.Distance(new Vector2(_player.position.x, 0), new Vector2(gameObject.transform.position.x, 0)) < 0.05f)
            {
                _isMoveable = false;
                StartCoroutine(RestartMoveCountDown());
            }
        }
    }

    private void Scroll()
    {
        if (_isMoveable)
            gameObject.transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void ScrollBoost()
    {
        if (_isMoveable)
            gameObject.transform.Translate(Vector2.left * _boostSpd * Time.deltaTime);
    }

    private IEnumerator RestartMoveCountDown()
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(4);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y);
        _isMoveable = true;
    }
}
