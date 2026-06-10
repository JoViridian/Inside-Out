using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public Animator startEnd;
    public UnityEvent endLoad;
    public AudioClip doorCreak;
    public Image image;
    public float endDuration;
    private bool sequenceStart = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sequenceStart)
        {
            transform.position += 0.5f * Vector3.up * Time.deltaTime;
        }
        
    }

    public void PlayEnd()
    {
        //Debug.Log("Start good end");
        image.color = new Color(1,1,1,0);
        startEnd.SetBool("Activate End", true);
        sequenceStart = true;
        GameManager.Instance.camLock = true;
        GameManager.Instance.PlayClip(doorCreak, 0.5f);
        StartCoroutine(DelayScene(endDuration));
    }

    IEnumerator DelayScene(float a)
    {
        yield return new WaitForSeconds(a);
        endLoad.Invoke();

    }
}
