using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Keybuttons : MonoBehaviour
{
    public UnityEvent onPressLeft;
    public UnityEvent onPressRight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameManager.Instance.allowInteract && onPressLeft != null && GameManager.Instance.camState)
        {
            //StartCoroutine(DelayByOne(onPressLeft));
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && GameManager.Instance.allowInteract && onPressRight != null && GameManager.Instance.camState)
        {
            StartCoroutine(DelayByOne(onPressRight));
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
}
