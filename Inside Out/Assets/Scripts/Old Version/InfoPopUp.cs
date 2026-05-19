using UnityEngine;
using TMPro;

public class InfoPopUp : MonoBehaviour
{
    public TextMeshProUGUI textA;
    public TextMeshProUGUI textB;
    public TextMeshProUGUI textC;
    public TextMeshProUGUI textD;
    [HideInInspector] public string infoA;
    [HideInInspector] public string infoB;
    [HideInInspector] public string infoC;
    [HideInInspector] public string infoD;
    [HideInInspector] public bool turnOn;

    private void Start()
    {
        infoA = ""; 
        infoB = "";
        infoC = "";
        infoD = "";
        turnOn = false;
    }

    void Update()
    {
        textA.text = infoA;
        textB.text = infoB;
        textC.text = infoC;
        textD.text = infoD;

        DoActiveCheck();
    }

    private void DoActiveCheck()
    {
        if(turnOn)
        {
            turnOn = false;
        }
        else
        {
            infoA = "";
            infoB = "";
            infoC = "";
            infoD = "";
        }
    }
}
