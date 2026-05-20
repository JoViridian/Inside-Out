using UnityEngine;
using UnityEngine.Events;

public class Keybuttons : MonoBehaviour
{
    public UnityEvent onPressLeft;
    public UnityEvent onPressRight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            onPressLeft.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            onPressRight.Invoke();
        }
    }
}
