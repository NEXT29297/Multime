using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float length, startpos, hight, startposy;
    public GameObject cam;
    public float parallaxEffect,parallaxEffecty;

    void Start()
    {
        startpos = transform.position.x;
        startposy = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        hight = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        float tempy = (cam.transform.position.y * (1 - parallaxEffecty));
        float disty = (cam.transform.position.y * parallaxEffecty);

        transform.position = new Vector3(startpos + dist, startposy - disty, transform.position.z);
        if (temp > startpos+length)
        {
            startpos += length;
        }
        else if(temp < startpos-length)
        {
            startpos -= length;
        }
        else if (tempy > startposy + hight)
        {
            startposy += hight;
        }
        else if (tempy < startposy -hight)
        {
            startposy -= hight;
        }
    }
}
