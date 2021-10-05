using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour
{
    public GameObject character;
    public GameObject springPlatform;
    public GameObject fanPlatform;
    public GameObject fanPlatformLeft;

    private GameObject newlyCreated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("1") && platformNow && settedPlatform != platformNow)
        //{
        //    Vector3 tempLoc = new Vector3(platformNow.transform.position.x, platformNow.transform.position.y, platformNow.transform.position.z + 5);
        //    GameObject.Instantiate(springPlatform, tempLoc, Quaternion.identity);
        //    settedPlatform = platformNow; // to avoid duplicate
        //}
        //if (Input.GetKeyDown("2") && platformNow && settedPlatform != platformNow)
        //{
        //    Vector3 tempLoc = new Vector3(platformNow.transform.position.x, platformNow.transform.position.y, platformNow.transform.position.z + 5);
        //    GameObject.Instantiate(springPlatformSmall, tempLoc, Quaternion.identity);
        //    settedPlatform = platformNow; // to avoid duplicate
        //}
        //if (Input.GetKeyDown("3") && platformNow && settedPlatform != platformNow)
        //{
        //    Vector3 tempLoc = new Vector3(platformNow.transform.position.x, platformNow.transform.position.y, platformNow.transform.position.z + 5);
        //    GameObject.Instantiate(normalPlatform, tempLoc, Quaternion.identity);
        //    settedPlatform = platformNow; // to avoid duplicate
        //}

        if (Input.GetKeyDown("1"))
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePosOnScreen = Input.mousePosition;
            mousePosOnScreen.z = screenPos.z;
            Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
            mousePosInWorld.x = 0;
            mousePosInWorld.z += 2;
            newlyCreated = GameObject.Instantiate(springPlatform, mousePosInWorld, Quaternion.identity);
        }
        if (Input.GetKeyDown("2"))
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePosOnScreen = Input.mousePosition;
            mousePosOnScreen.z = screenPos.z;
            Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
            mousePosInWorld.x = 0;
            mousePosInWorld.z += 0;
            newlyCreated = GameObject.Instantiate(fanPlatform, mousePosInWorld, Quaternion.identity);
        }
        if (Input.GetKeyDown("3"))
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePosOnScreen = Input.mousePosition;
            mousePosOnScreen.z = screenPos.z;
            Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
            mousePosInWorld.x = 0;
            mousePosInWorld.z += 0;
            newlyCreated = GameObject.Instantiate(fanPlatformLeft, mousePosInWorld, Quaternion.Euler(-90f, 0f, 0f));
        }
        if (Input.GetKeyDown("q"))
        {
            GameObject.Destroy(newlyCreated);
        }
    }
}
