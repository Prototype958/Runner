using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private float _boostSpd = 0.025f;
    private float _speed = 0.015f;

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
    }

    public void Scroll()
    {
        gameObject.transform.Translate(Vector2.left * _speed);
    }

    public void ScrollBoost()
    {
        gameObject.transform.Translate(Vector2.left * _boostSpd);
    }
}
