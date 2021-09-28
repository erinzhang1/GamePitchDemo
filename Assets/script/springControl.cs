using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springControl : MonoBehaviour
{
    public GameObject character;
    public GameObject springPlatform;
    public GameObject springPlatformSmall;
    public GameObject normalPlatform;
    private GameObject platformNow;
    private GameObject settedPlatform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1") && platformNow && settedPlatform != platformNow)
        {
            Vector3 tempLoc = new Vector3(platformNow.transform.position.x, platformNow.transform.position.y, platformNow.transform.position.z + 5);
            GameObject.Instantiate(springPlatform, tempLoc, Quaternion.identity);
            settedPlatform = platformNow; // to avoid duplicate
        }
        if (Input.GetKeyDown("2") && platformNow && settedPlatform != platformNow)
        {
            Vector3 tempLoc = new Vector3(platformNow.transform.position.x, platformNow.transform.position.y, platformNow.transform.position.z + 5);
            GameObject.Instantiate(springPlatformSmall, tempLoc, Quaternion.identity);
            settedPlatform = platformNow; // to avoid duplicate
        }
        if (Input.GetKeyDown("3") && platformNow && settedPlatform != platformNow)
        {
            Vector3 tempLoc = new Vector3(platformNow.transform.position.x, platformNow.transform.position.y, platformNow.transform.position.z + 5);
            GameObject.Instantiate(normalPlatform, tempLoc, Quaternion.identity);
            settedPlatform = platformNow; // to avoid duplicate
        }
    }
    public void setPlatform(GameObject platform)
    {
        platformNow = platform;
    }

    public void removePlatform()
    {
        if (!platformNow)
        {
            platformNow = null;
        }
    }
}
