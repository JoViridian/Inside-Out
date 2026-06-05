using UnityEngine;

public class SkyPan : MonoBehaviour
{
    public float speed;
    public Vector3 spinDirection = Vector3.right;

    void Update()
    {
        transform.Rotate(spinDirection * 0.001f * speed);
    }
}
