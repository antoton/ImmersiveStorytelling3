using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceilingLiquidChange : MonoBehaviour
{
    public List<Texture> image; //list with all the pictures
    public int time = 10;

    private int currentImage = 0; //current image shown

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("changeCeiling", time, time);
    }

    // Update is called once per frame
    void Update()
    {
        //ceiling.GetComponent
    }

    void changeCeiling()
    {
        print("current image: " + currentImage);
        print("image count: " + image.Count);
        if (image.Count > 0)
        {
            if (currentImage <= (image.Count-1))
            {
                GetComponent<Renderer>().material.SetTexture("_MainTex", image[currentImage]);
                currentImage++;
                print("in function");

            }
        }

    }
}
