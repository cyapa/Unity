using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{

private int experience;
private int levelIdx;
private string levelName;

private enum Levels
{
    Rookie,
    Advanced,
    Master,
    Legendary,
    Ultimate
}


//constructor
public Level(){
    experience = 0;
    levelIdx = 0;
    levelName = GetLevelName();
}


public int Experience { 
    get{ return experience;} 
    set{experience = value;}    
    }

public string LevelName { 
    get{ 
        return GetLevelName();
        }    
    }

public string GetLevelName(){

    levelIdx = experience / 10;
    var levelName = (Levels)levelIdx;
    return levelName.ToString();

    // OLD LEVEL CALCULATING CODE

    //    switch(levelId){

    //         case 0:
    //             levelStr = "Rookie";
    //             break;
    //         case 1:
    //             levelStr = "Advanced";
    //             break;
    //         case 2:
    //             levelStr = "Master";
    //             break;
    //         default:
    //             Debug.Log("LEVEL NOT IMPLEMENTED!");
    //             break;
    //     }
    //return levelStr;
}


}
