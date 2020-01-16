using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour,IAnimation<float>
{   
    private Material material;
    private bool colorSwap;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent< Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Circle(Time.deltaTime *5);

        if(colorSwap)
            Color(new Color(1, 0.92f, 0.016f, 1));
        else
            Color(new Color(1, 0, 0, 1));
       
        colorSwap = !colorSwap;
    }


    public void Circle(float speed)
    {
        transform.Rotate (new Vector3 (15, 30, 45) * speed);
    }

    public void Color(Color color)
    {
        material.SetColor("_Color",color);
    }

}
