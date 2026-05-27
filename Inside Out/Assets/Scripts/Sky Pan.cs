using UnityEngine;

public class SkyPan : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(Vector3.right * 0.001f * speed);
    }
}
