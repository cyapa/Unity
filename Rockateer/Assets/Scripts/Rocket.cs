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
        switch (collision.gameObject.tag)
        {
            case "enemy":
                SceneManager.LoadScene(currentScene.buildIndex);
                break;
            case "finish":
                LoadNextLevel();
                break;
            default:
                print("Not implemented");
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
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
