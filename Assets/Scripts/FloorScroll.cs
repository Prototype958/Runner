using UnityEngine;

public class FloorScroll : MonoBehaviour
{
    public void ResetPosition()
    {
        float width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        float curPosX = gameObject.transform.position.x;
        gameObject.transform.position = new Vector2(curPosX + (width * 2), gameObject.transform.position.y);
    }
}
