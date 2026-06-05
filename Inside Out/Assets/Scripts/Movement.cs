using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController player;
    public float speedMultiplier = 1;

    void Update()
    {
        if (!GameManager.Instance.camLock)
        {
            DoMovement();
        }

        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.Rotate(0, 1, 0);
        //}
    }

    void DoMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.SimpleMove(speedMultiplier * transform.TransformDirection(Vector3.forward));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.SimpleMove(speedMultiplier * transform.TransformDirection(Vector3.back));
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.SimpleMove(speedMultiplier * transform.TransformDirection(Vector3.left));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.SimpleMove(speedMultiplier * transform.TransformDirection(Vector3.right));
        }
    }
}
