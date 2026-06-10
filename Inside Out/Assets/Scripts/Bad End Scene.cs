using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BadEndScene : MonoBehaviour
{
    private bool active;
    public SkyPan skySpin;
    public FadeTransition fade;
    public AudioClip clip;
    public float severity = 40;
    public float endDuration;
    public UnityEvent endLoad;

    private void Start()
    {
        active = false;
    }

    private void Update()
    {
        if (active)
        {
            skySpin.speed *= ( 1 + Time.deltaTime * severity);
        }
    }

    public void EndScene()
    {
        active = true;
        fade.enabled = false;
        GameManager.Instance.allowInteract = false;
        GameManager.Instance.PlayClip(clip, 0.5f);
        StartCoroutine(DelayScene(endDuration));
    }

    IEnumerator DelayScene(float a)
    {
        yield return new WaitForSeconds(a);
        endLoad.Invoke();

    }
}
