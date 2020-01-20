using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBoxGenerator : MonoBehaviour
{
    public GameObject TextObj;
    
    public string[] materials;
    public Camera mainCam;
    // Start is called before the first frame update

    int matListSize;
    GameObject textObj;
    Vector3 cameraCorner;
    string planetName = "";
    string currentString = "";

    bool exists = false;

    void Start()
    {
        matListSize = materials.Length;
        textObj = Instantiate(TextObj, new Vector3(0, 0, 0), Quaternion.identity);
        textObj.transform.SetParent(GameObject.Find("Canvas").transform);
        //Debug.Log(textObj.GetComponent<RectTransform>().anchoredPosition);
        //textObj.GetComponent<RectTransform>().transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        cameraCorner = mainCam.ViewportToWorldPoint(new Vector3(0, 1, mainCam.nearClipPlane));
        float x = cameraCorner.x + 210;
        float y = cameraCorner.y - 210;
        if (!exists) {
            y += 12000;
        }
        Vector3 textPos = new Vector3(x, y, 0);
        textObj.GetComponent<RectTransform>().anchoredPosition = textPos;
    }

    void generateString()
    {
        string ans = "Planet Name: " + planetName + "\nMaterials:\n";
        for (int i = 0; i < matListSize; i++)
        {
            string matString = "     " + materials[i] + "\n";
            ans += matString;
        }
        currentString = ans;
        textObj.GetComponent<Text>().text = currentString;
    }

    public void setCurrentName(string planetName) {
        this.planetName = planetName;
        generateString();
    }

    public void setExist(bool textBoxExist) {
        this.exists = textBoxExist;
    }
}
