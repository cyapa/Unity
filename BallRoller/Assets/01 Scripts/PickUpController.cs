using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour,IAnimation<float>
{
    
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent< Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
         Circle( Time.deltaTime);
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
