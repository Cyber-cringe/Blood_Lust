using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphonScript : MonoBehaviour
{
    public static int totalWeaphons = 1;
    [SerializeField]
    public static int currentWeaphonIndex;
    public GameObject[] guns;
    public GameObject weaphonHolder;
    public static GameObject currentGun;

    
    void Start()
    {
        
       totalWeaphons = weaphonHolder.transform.childCount;
        guns = new GameObject[totalWeaphons];

        for (int i = 0; i < totalWeaphons; i++)
        {
            guns[i] = weaphonHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaphonIndex = 0;
        totalWeaphons = 1;

    }
    void Update()
    {
        totalWeaphons = 4;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
            if (currentWeaphonIndex < totalWeaphons - 1)
            {
                guns[currentWeaphonIndex].SetActive(false);
                currentWeaphonIndex += 1;
                guns[currentWeaphonIndex].SetActive(true);
                currentGun = guns[currentWeaphonIndex];
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWeaphonIndex > 0)
            {
                guns[currentWeaphonIndex].SetActive(false);
                currentWeaphonIndex -= 1;
                guns[currentWeaphonIndex].SetActive(true);
                currentGun = guns[currentWeaphonIndex];
            }
        }

    }
}
