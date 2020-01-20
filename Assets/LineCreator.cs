using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject line;
    LineRenderer lineRend;

    public float x1 = 0;
    public float y1 = 0;
    public float x2 = 0;
    public float y2 = 0;

    bool isDraw = false;

    //defined when mouse hovers over planets
    bool isOnPlanet = false;
    float initPlanetX;
    float initPlanetY;
    Planet initPlanet;

    Vector3[] points = new Vector3[2];

    Planet[] planets;
    int planetNumber;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("countPlanets", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //lineRend.SetPositions(points);
        //planets = FindObjectsOfType<Planet>();
        Vector3 initClick = Input.mousePosition;
        initClick.z = 0;
        initClick = Camera.main.ScreenToWorldPoint(initClick);

        if (Input.GetMouseButtonDown(1)) {

            if (!isDraw) {

                if (isOnPlanet) {

                    GameObject lineObj = Instantiate(line, transform.position, Quaternion.identity);
                    lineRend = lineObj.GetComponent<LineRenderer>();
                    points[0] = new Vector3(initPlanetX, initPlanetY);
                    isDraw = true;
                }
            }

            else {

                float[] closestPlanet = findClosestPlanet(initClick.x, initClick.y);
                points[1] = new Vector3(closestPlanet[0], closestPlanet[1]);
                lineRend.SetPositions(points);
                //Debug.Log(planets[(int)closestPlanet[2]].GetComponent<Planet>());
                initPlanet.linkPlanet(planets[(int)closestPlanet[2]]);
                Debug.Log("1");
                planets[(int)closestPlanet[2]].linkPlanet(initPlanet);
                Debug.Log("1");
                isDraw = false;
            }
        }

        else if (isDraw) {

            points[1] = new Vector3(initClick.x, initClick.y);
            lineRend.SetPositions(points);
        }
    }

    public void defineInitPlanet(bool isOnPlanet) {

        if(!isDraw)
            this.isOnPlanet = isOnPlanet;
    }

    public void defineInitPlanet(bool isOnPlanet, float px, float py) {

        if (!isDraw){

            this.isOnPlanet = isOnPlanet;
            this.initPlanetX = px;
            this.initPlanetY = py;
        }
    }

    public void defineInitPlanet(bool isOnPlanet, Planet initPlanet) {
        if (!isDraw){

            this.isOnPlanet = isOnPlanet;
            this.initPlanet = initPlanet;
            initPlanetX = this.initPlanet.transform.position.x;
            initPlanetY = this.initPlanet.transform.position.y;
        }
    }

    float[] findClosestPlanet(float x, float y) {

        float[] finalPos = new float[3];

        float dist = -1;
        float shortestDist = -1;
        float planetIndex = -1;

        for (int i = 0; i < planetNumber; i++) {

            float px = planets[i].transform.position.x;
            float py = planets[i].transform.position.y;

            dist = (x - px) * (x - px) + (y - py) * (y - py);

            //Debug.Log(dist);

            if (px == initPlanetX && py == initPlanetY) {
                continue;
            }

            if (shortestDist == -1) {

                shortestDist = dist;
                finalPos[0] = px;
                finalPos[1] = py;
                planetIndex = i;
                continue;
            }

            if (dist < shortestDist) {

                shortestDist = dist;
                finalPos[0] = px;
                finalPos[1] = py;
                planetIndex = i;
            }
        }

        finalPos[2] = planetIndex;
        return finalPos;
    }

    void countPlanets() {

        planets = FindObjectsOfType<Planet>();
        planetNumber = planets.Length;
        Debug.Log(planetNumber);
    }
}
