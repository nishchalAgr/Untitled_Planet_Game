using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public GameObject circleUI;
    public CircleOnLine circleOnLine;

    float kVal = 100;
    float initY;
    Transform myTransform;
    //Rigidbody2D rg;
    int count;
    GameObject circleObj;
    GameObject textBoxGenerator;
    string name = "";

    TextBoxGenerator tbgObject;
    LineCreator lc;

    List<Planet> linkedPlanets;
    // Start is called before the first frame update
    void Start()
    {
        linkedPlanets = new List<Planet>();
        myTransform = gameObject.GetComponent<Transform>();
        textBoxGenerator = GameObject.Find("TextBoxGenerator");
        lc = GameObject.Find("LineCreator").GetComponent<LineCreator>();
        tbgObject = textBoxGenerator.GetComponent<TextBoxGenerator>();
        //rg = gameObject.GetComponent<Rigidbody2D>();
        initY = myTransform.position.y;
        kVal = Random.Range(50, 85);
        count = 0;

        StartCoroutine("sendCirclesAnim");
    }

    // Update is called once per frame
    void Update()
    {
        count++;
    }

    void FixedUpdate()
    {
        //bobbingAnimation();
    }

    void OnMouseEnter()
    {
        circleObj = Instantiate(circleUI, gameObject.transform.position, Quaternion.identity);
        tbgObject.setCurrentName(name);
        tbgObject.setExist(true);
        lc.defineInitPlanet(true, this);
        //Debug.Log("Mouse Over");
    }

    void OnMouseExit() {

        tbgObject.setExist(false);
        lc.defineInitPlanet(false);
        Destroy(circleObj);
    }

    void bobbingAnimation() {

        float currentPos = myTransform.position.y - initY;
        float force = -kVal * currentPos;
        //rg.AddForce(new Vector3(0, force, 0));
    }

    public void setName(string planetName) {

        this.name = planetName;
    }

    public void linkPlanet(Planet planetToLink) {
        Debug.Log(planetToLink);
        linkedPlanets.Add(planetToLink);
    }

    IEnumerator sendCirclesAnim() {

        while (true) { 
        
            yield return new WaitForSeconds(0.75f);

            Vector3 beginPos = transform.position;
            beginPos.z += 100;

            if (linkedPlanets.Count > 0) {

                for (int i = 0; i < linkedPlanets.Count; i++) {

                    CircleOnLine col = Instantiate(circleOnLine, beginPos, Quaternion.identity);
                    col.defineEndPos(linkedPlanets[i].transform.position, 2f);
                }
            }
        }
    }
}
