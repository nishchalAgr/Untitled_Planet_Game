using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public GameObject planetObject;
    public float xDim = 5;
    public float yDim = 5;
    public float gapBetween = 100f;
    public Sprite[] spriteList;

    float myX;
    float myY;

    // Start is called before the first frame update
    void Start()
    {
        myX = gameObject.transform.position.x;
        myY = gameObject.transform.position.y;
        generateRandom();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateRandom() {

        for (float i = -xDim; i < xDim; i++) {

            for (float j = -yDim; j < yDim; j++) {

                float x = myX;
                float y = myY;

                if (j % 2 == 0) {
                    x += gapBetween / 2;
                }

                GameObject newPlanet = Instantiate(planetObject, new Vector3(x + i * gapBetween, 
                                                                             y + j * gapBetween * .9f, 0), 
                                                                             Quaternion.identity);

                Sprite planetSprite = spriteList[Random.Range(0, spriteList.Length - 1)];
                newPlanet.GetComponent<SpriteRenderer>().sprite = planetSprite;
                newPlanet.GetComponent<Planet>().setName(planetSprite.name);
            }
        }
    }
}
