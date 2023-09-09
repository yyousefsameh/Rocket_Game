using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // start -> Rigidbody component

    // Each frame is the input being pressed

    // If pressed -> AddForce

    private Rigidbody rb;
    


    //pushing the rocket perpendicular
    [SerializeField] private float thrustPower;
    [SerializeField] private float rotationPower;
    [SerializeField] private ParticleSystem downThrustParticles;

    private AudioSource AudioSource;

    private bool isPlayingAudio=false;
    private bool isPlayingDownPrticles =false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        AudioSource= GetComponent<AudioSource>();
    }



    private void Update()
    {
        MovementController();

    }

    private void MovementController()
    {
        ThrustingController();
        RotationController();


    }

    private void RotationController()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            
            //Rotate Right
            RotatingRightProcess();

        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Rotate Left
            RotatingLeftProcess();

        }
    }

    private void ThrustingController()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ThrustingProcess();
        }
        else
        {
            StopThrustingProcess();
        }
    }

    private void RotatingLeftProcess()
    {
        //Freeze Rotation
        rb.freezeRotation= true;
        transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime);
        // UnFreeze Rotation
        rb.freezeRotation = false;
    }

    private void RotatingRightProcess()
    {
        //Freeze Rotation
        rb.freezeRotation = true;
        transform.Rotate(Vector3.back * rotationPower * Time.deltaTime);
        // UnFreeze Rotation
        rb.freezeRotation = false;
    }

    private  void StopThrustingProcess()
    {

        AudioSource.Stop();
        isPlayingAudio= false;
        downThrustParticles.Stop();
        isPlayingDownPrticles = false;

    }




    private void ThrustingProcess()
    {
        if (!isPlayingAudio)
        {
            AudioSource.Play();
            isPlayingAudio = true;
        }
        if(!isPlayingDownPrticles)
        {
            downThrustParticles.Play();
            isPlayingDownPrticles= true;
        }
        rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
    }
}
