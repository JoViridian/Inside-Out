using UnityEngine.Events;
using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour
{
    public float distAllow;
    private float distInternal;
    public UnityEvent onClick;
    public UnityEvent onHover;
    public UnityEvent onMouseExit;
    public GameObject playerRef;
    public bool delayAction = true;
    

    private void Update()
    {
        distInternal = (transform.position - playerRef.transform.position).magnitude;
    }

    private void OnMouseOver()
    {
        if (distInternal < distAllow && GameManager.Instance.allowInteract)
        {
            onHover.Invoke();
            //Debug.Log("Detecting");

            if (Input.GetKey(KeyCode.Mouse0) && delayAction)
            {
                StartCoroutine(DelayByOne(onClick));
            } 
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                onClick.Invoke();
            }
        }
        else
        {
            onMouseExit.Invoke();
        }
    }

    private void OnMouseExit()
    {
        onMouseExit.Invoke();
        Debug.Log("Mouse Exited");
    }

    IEnumerator DelayByOne(UnityEvent a)
    {
        GameManager.Instance.allowInteract = false;
        yield return new WaitForSeconds(0.5f);
        a?.Invoke();
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.allowInteract = true;
    }

    public void TurnOn(GameObject GO)
    {
        GO.SetActive(true);
    }

    public void TurnOff(GameObject GO)
    {
        GO.SetActive(false);
    }
}
