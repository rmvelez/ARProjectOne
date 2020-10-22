using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class CameraShoot : MonoBehaviour
{
    private GameObject currentBulletPrefab; // reference to the current bullet

    // list of different types of bullets that can be used in game
    public GameObject redBullet;
    public GameObject blueBullet;
    public GameObject yellowBullet;
    public GameObject greenBullet;
    public GameObject orangeBullet;
    public GameObject purpleBullet;

    private ARGestureInteractor aRGestureInteractor; // reference to the gesture interactor script
    public float shotSpeed; // the speed of the bullet
    private float shootDelay; // how long until the player can shoot again
    public float startShootDelay; // the initial value the player can shoot
    //private bool canShoot; // checks to see if the player can shoot

    // Start is called before the first frame update
    void Start()
    {
        aRGestureInteractor = GetComponent<ARGestureInteractor>();
        currentBulletPrefab = redBullet;

        // calls on functions that run when the player taps on the screen
        aRGestureInteractor.TapGestureRecognizer.onGestureStarted += OnTapRecognized; 
    }

    // this function is called when the player taps on the screen
    private void OnTapRecognized(TapGesture obj)
    {
        if (shootDelay <= 0)
        {
            // instantiates the bullet and sets it to the transform of the player
            GameObject newBullet = Instantiate(currentBulletPrefab);
            newBullet.transform.position = transform.position;

            // the bullet moves away from the player
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;

            shootDelay = startShootDelay;
        }
        else
        {
            shootDelay -= Time.deltaTime;
        }
    }

    // the following functions are called in buttons on the menu for the game

    // sets the current bullet to the blue bullet
    public void BlueBulletSwap()
    {
        currentBulletPrefab = blueBullet;
    }

    // sets the current bullet to the red bullet
    public void RedBulletSwap()
    {
        currentBulletPrefab = redBullet;
    }

    // sets the current bullet to the yellow bullet
    public void YellowBulletSwap()
    {
        currentBulletPrefab = yellowBullet;
    }

    // sets the current bullet to the green bullet
    public void GreenBulletSwap()
    {
        currentBulletPrefab = greenBullet;
    }

    // sets the current bullet to the orange bullet
    public void OrangeBulletSwap()
    {
        currentBulletPrefab = orangeBullet;
    }

    // sets the current bullet to the purple bullet
    public void PurpleBulletSwap()
    {
        currentBulletPrefab = purpleBullet;
    }
}
