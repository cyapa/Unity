using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerController : Character
{
    private Rigidbody rb;
    private Material material;
    SaveStatus save;
    Level lvl;
    
    
    private float maxScaleX = 2.5f;
    private float minScaleX = 0.1f;

    // Start is called before the first frame update
    public override void Start()
    {
        rb = GetComponent<Rigidbody>();
        material = GetComponent< Renderer>().material;

        //Get game stats
        string startJson = File.ReadAllText(Application.dataPath + "/05 Data/save.json");
        save = JsonUtility.FromJson<SaveStatus>(startJson);

        transform.localScale = save.size;

        //Init Level
        lvl = new Level();
        Debug.Log("Your current level when starting : "+ lvl.LevelName);

        base.SetHealth(save.health);
        base.SetSpeed(save.speed);
    }

    // Update is called once per frame
    public override void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(move * base.GetSpeed());
    }


    //When the ball enters to an object
    void OnTriggerEnter(Collider other) 
    {
        lvl.Experience = lvl.Experience + 1;

        var tag = other.gameObject.tag;
   
        switch(tag.ToString()){

            case "makebig":
                MakePlayerBig();
                base.DeductHealth();
                break;
            case "makesmall":
                MakePlayerSmall();
                base.DeductHealth();
                break;
            case "speedup":
                base.SetSpeed(1);
                //base.AddHealth();
                break;
            default:
                Debug.Log(tag + "NOT IMPLEMENTED!");
                break;
        }
    
        other.gameObject.SetActive (false);  

        //Change player color to pick up object's color
        var pickupMaterial = other.gameObject.GetComponent< Renderer>().material;               
        material.SetColor("_Color", pickupMaterial.color);

        base.PrintHealth();
    }

    //On exiting
     public override void OnDisable()
    {
        Debug.Log("Exiting the game");

        //Save current player stats to save file
        SaveStatus curSaveStatus = new SaveStatus();
        curSaveStatus.size = transform.localScale;
        curSaveStatus.speed = base.GetSpeed();
        curSaveStatus.health = base.GetHealth();
        
        string exitJson = JsonUtility.ToJson(curSaveStatus);
        File.WriteAllText(Application.dataPath + "/05 Data/save.json",exitJson);

        
        Debug.Log("Your current level when exiting : "+ lvl.LevelName);
    }

    //Make player object big
    private void MakePlayerBig(){
        if (maxScaleX > transform.localScale.x)
            transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);       
    }
    //Make player object small
    private void MakePlayerSmall(){  

        if (minScaleX < transform.localScale.x)     
            transform.localScale -= new Vector3(0.1F, 0.1F, 0.1F);
    }
    // Speed up the player
    private void SpeedUp(){
        base.SetSpeed(1);
    }
}


