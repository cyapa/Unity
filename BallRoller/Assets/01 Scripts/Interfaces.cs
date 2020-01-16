using UnityEngine;

public interface IAnimation<T>{

    // Implement the circling speed of the object
    void Circle(T speed); 

    // Implement the color of the object
    void Color(Color color);     
}