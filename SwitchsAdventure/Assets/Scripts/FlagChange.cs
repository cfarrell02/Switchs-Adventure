using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagChange : MonoBehaviour
{
    GameObject redMap, blueMap, redHazard, blueHazard, redWall, blueWall;
    bool lockCode = false;
    [SerializeField] AudioClip switchSFX;
    // Start is called before the first frame update
    void Start()
    {
        redMap = GameObject.Find("Red Foreground");
        blueMap = GameObject.Find("Blue Foreground");
        redHazard = GameObject.Find("Red Hazards");
        blueHazard = GameObject.Find("Blue Hazards");
        redWall = GameObject.Find("Red Wall");
        blueWall = GameObject.Find("Blue Wall");
       // TogglePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D()
    {  
        if(!lockCode)
        TogglePlatforms();
    }
    private void OnTriggerExit2D()
    {
        lockCode = false;
    }
    private void TogglePlatforms()
    {
        AudioSource.PlayClipAtPoint(switchSFX, transform.position);
        if (redMap.active)
        {
            blueMap.active = true;
            blueHazard.active = true;
            blueWall.active = true;
            redWall.active = false;
            redMap.active = false;
            redHazard.active = false;
        }
        else
        {
            redMap.active = true;
            redHazard.active = true;
            blueMap.active = false;
            blueHazard.active = false;
            blueWall.active = false;
            redWall.active = true;
        }
        lockCode = true;
    }
}
