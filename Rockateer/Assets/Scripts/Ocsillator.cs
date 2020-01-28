using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Ocsillator : MonoBehaviour
{

    const float tau = Mathf.PI * 2f;


    [SerializeField] Vector3 movementVector = new Vector3(0f, 3f, 0f);
    [SerializeField] [Range(0,1)]float movementFactor;
    [SerializeField] float period = 3f;

    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
        
    }
}
