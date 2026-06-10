using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TryWin : MonoBehaviour
{
    public GameObject doorInteract;
    public KnockKnock knock;
    public Animator animator;
    public AudioClip missClip;
    public float winCondition;
    private float winConditionInt;
    public UnityEvent onFail;
    public UnityEvent onSuccess;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winConditionInt = winCondition;
    }

    public void TryForWin()
    {
        int a = Random.Range(1, 101);
        if (a >= winConditionInt)
        {
            onSuccess.Invoke();
        }
        else
        {
            onFail.Invoke();
        }
    }

    public void DoThump()
    {
        GameManager.Instance.PlayClip(missClip, 0.5f);
        winConditionInt -= knock.imageCount;
        StartCoroutine(FailAnimation());
    }

    IEnumerator FailAnimation()
    {
        doorInteract.SetActive(false);
        animator.SetBool("Budge", true);
        yield return new WaitForSeconds(0.5f);
        doorInteract.SetActive(true);
        animator.SetBool("Budge", false);
    }
}
