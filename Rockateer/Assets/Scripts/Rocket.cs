using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rocket : MonoBehaviour
{

    [SerializeField]
    public float rotationTrust = 100f;

    [SerializeField]
    public float thrust = 100f;


    const float MAX_THRUST = 150f;
    const float MIN_THRUST = 40f;

    Rigidbody rocketRigid;
    AudioSource rocketAudio;

    enum State  {Live,Dead,Completed}
    State state = State.Live;

    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        rocketRigid = GetComponent<Rigidbody>();
        rocketAudio = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Live)
            return;

        switch (collision.gameObject.tag)
        {
            case "enemy":
                state = State.Dead;
                Invoke("RestartLevel",2f);
                break;
            case "finish":
                state = State.Completed;
                Invoke("LoadNextLevel", 2f);
                break;
            default:
                print("Not implemented");
                break;


        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Live)
        {
            Thrust();
            Rotate();
        } 
    }


    void LoadNextLevel()
    {
        int nextLvlIdx = currentScene.buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextLvlIdx)
            SceneManager.LoadScene(nextLvlIdx);
        else
            print("No level scene found!");


    }
    private void Rotate()
    {
        float rotationSpeed = Time.deltaTime * rotationTrust;
        rocketRigid.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.forward * rotationSpeed);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.back * rotationSpeed);

        rocketRigid.freezeRotation = false;

    }

    private void Thrust()
    {
        float thrustSpeed = Time.deltaTime * thrust;
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRigid.AddRelativeForce(Vector3.up* thrustSpeed);
            if (!rocketAudio.isPlaying)
                rocketAudio.Play();
            if (MAX_THRUST > thrust)
                thrust++;
        }
        else
        {
            rocketAudio.Stop();
            thrust = MIN_THRUST;
        }
           
    }
}
