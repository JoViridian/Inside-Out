using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Keybuttons : MonoBehaviour
{
    public UnityEvent onPressLeft;
    public UnityEvent onPressRight;
    public bool delayAction = true;
    public bool bypassState = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameManager.Instance.allowInteract && onPressLeft != null && GameManager.Instance.camState)
        {
            onPressLeft.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && bypassState && onPressLeft != null)
        {
            //CheckForDelay(onPressLeft);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && GameManager.Instance.allowInteract && onPressRight != null && GameManager.Instance.camState)
        {
            CheckForDelay(onPressRight);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && bypassState && onPressRight != null)
        {
            CheckForDelay(onPressRight);
        }
    }

    IEnumerator DelayByOne(UnityEvent a)
    {
        GameManager.Instance.allowInteract = false;
        yield return new WaitForSeconds(0.5f);
        a?.Invoke();
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.allowInteract = true;
    }

    void CheckForDelay(UnityEvent a)
    {
        if (delayAction && a != null)
        {
            StartCoroutine(DelayByOne(a));
        }
        else
        {
            a?.Invoke();
        }
    }
}
