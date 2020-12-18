using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceilingLiquidChange : MonoBehaviour
{
    [Tooltip("Witch images need to be shown")]
    public List<Texture> image; //list with all the pictures
    [Tooltip("after how mutch time need the ceiling change")]
    public int time = 10;

    private int currentImage = 0; //current image shown

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("changeCeiling", time, time); //repeate function with timer
    }

    // Update is called once per frame
    void Update()
    {

    }

    void changeCeiling()
    {
        if (image.Count > 0)
        {
            if (currentImage <= (image.Count-1))
            {
                GetComponent<Renderer>().material.SetTexture("_MainTex", image[currentImage]);
                currentImage++;

            }
        }

    }
}
