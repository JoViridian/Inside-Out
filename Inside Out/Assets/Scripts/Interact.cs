using UnityEngine.Events;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public UnityEvent onClick;
    public GameObject playerRef;
    public float distAllow;
    private float distInternal;

    private void Update()
    {
        distInternal = (transform.position - playerRef.transform.position).magnitude;
    }

    private void OnMouseOver()
    {
        if(Input.GetKey(KeyCode.Mouse0) && distInternal < distAllow)
        {
            onClick.Invoke();
        }

        if (distInternal < distAllow)
        {
            Debug.Log("Hover" + distInternal);
        }
    }
}
