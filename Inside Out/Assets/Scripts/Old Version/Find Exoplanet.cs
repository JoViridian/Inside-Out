using UnityEngine;

public class FindExoplanet : MonoBehaviour
{
    public string letter;
    public float planetMass;
    public float planetRadius;
    public float planetOrbit;
    public string planetType;

    public string massType;
    public string factoid;

    public float orbitTimer;
    public float allowDiscovery;
    [HideInInspector] public bool firstTime;
    private float timer;
    private float massMin;
    private float massMax;

    void Start()
    {
        timer = Random.Range(0, orbitTimer);
        firstTime = true;
        massMin = planetMass * 0.5f;
        massMax = planetMass * 1.5f;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Reset");
            timer = orbitTimer;
        }
    }

    public bool DoFindPlanet()
    {
        if (timer < allowDiscovery)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DoDiscovery()
    {
        if (firstTime)
        {
            firstTime = false;
            massMin = Mathf.Round(Mathf.Clamp(Random.Range(massMin, planetMass), massMin, planetMass) * 10) / 10;
            massMax = Mathf.Round(Mathf.Clamp(Random.Range(planetMass, massMax), planetMass, massMax) * 10) / 10;
            return true;
        }
        else
        {
            return false;
        }
    }

    public string DoGiveInfo()
    {
        string a = "<size=28>" + GetComponentInParent<StarType>().codename + " " + letter + "</size=28>\n"
            + planetType + " (" + massMin + "<size=12>x</size=12> - " + massMax + "<size=12>x</size=12> M<size=12>" + massType + "</size=12>)\n"
            + planetOrbit + " AU\n"
            + factoid;
        return a;
    }
}
