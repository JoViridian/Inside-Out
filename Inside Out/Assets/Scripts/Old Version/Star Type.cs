using UnityEngine;

public class StarType : MonoBehaviour
{
    public string codename;
    public string type;
    public float mass;
    public float distance;
    public string factoid;

    public FindExoplanet planetB;
    public FindExoplanet planetC;
    public FindExoplanet planetD;

    public GameObject newInfo;
    public AudioClip popUpSound;
    private string infoKnown;
    private string infoGainedB;
    private string infoGainedC;
    private string infoGainedD;

    private void Start()
    {
        infoGainedB = "";
        infoGainedC = "";
        infoGainedD = "";
    }

    // Update is called once per frame
    void Update()
    {
        infoKnown = "<size=28>" + codename + " A </size=28>\n"
            + type + " (" + mass + "<size=12>x</size=12> M<size=12>s</size=12>)\n"
            + distance + " lightyears away\n"
            + factoid;
    }

    void OnMouseOver()
    {
        if (planetB != null)
        {
            if (planetB.DoFindPlanet())
            {
                if (planetB.DoDiscovery())
                {
                    Instantiate(newInfo);
                    GameManager.Instance.PlayClip(popUpSound, 0.2f);
                }
                
                infoGainedB = planetB.DoGiveInfo();
            }
        }

        if (planetC != null)
        {
            if (planetC.DoFindPlanet() && !planetB.firstTime)
            {
                if (planetC.DoDiscovery())
                {
                    Instantiate(newInfo);
                    GameManager.Instance.PlayClip(popUpSound, 0.2f);
                }

                infoGainedC = planetC.DoGiveInfo();
            }
        }

        if (planetD != null)
        {
            if (planetD.DoFindPlanet() && !planetB.firstTime && !planetC.firstTime)
            {
                if (planetD.DoDiscovery())
                {
                    Instantiate(newInfo);
                    GameManager.Instance.PlayClip(popUpSound, 0.2f);
                }

                infoGainedD = planetD.DoGiveInfo();
            }
        }

        DoShowInfo();
    }

    private void DoShowInfo()
    {
        InfoPopUp a = GameManager.Instance.infoBox.GetComponent<InfoPopUp>();
        a.turnOn = true;
        a.infoA = infoKnown;
        a.infoB = infoGainedB;
        a.infoC = infoGainedC;
        a.infoD = infoGainedD;
    }
}
