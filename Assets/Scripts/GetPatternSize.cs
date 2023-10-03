using UnityEngine;

public class GetPatternSize : MonoBehaviour
{
    // public Bounds Calculate(GameObject pattern)
    // {
    //     Bounds b = new Bounds();

    //     foreach (var child in pattern.GetComponentsInChildren<GameObject>())
    //     {
    //         b.Encapsulate(child.GetComponent<BoxCollider2D>().bounds);
    //     }

    //     return b;
    // }

    public Bounds Calculate()
    {
        Bounds b = new Bounds();

        int count = 0;

        foreach (Transform child in GetComponentInChildren<Transform>())
        {
            b.Encapsulate(child.GetComponent<BoxCollider2D>().bounds);
            count++;
        }

        Debug.Log(b);
        return b;
    }
}
