using System;
using UnityEngine;
using System.Collections;

public class SpaceshipMotor : MonoBehaviour, IRequireUserInput
{
	
    // Property for Injection
    public IUserInputProxy InputProxy { get; set; }

    public float Speed;
    public Vector2 Min;
    public Vector2 Max;

	
    // Update method is called once per frame
    // Lets call vertical and horizontal movement separately
    // MoveHorizontally ();
    // MoveVertically ();

    void Update()
    {

        if (InputProxy == null)
            return;

        MoveHorizontally();
        MoveVertically();
    }
	

    // To read user input you shoud use static class Input
    // to get the value of horizontal axis and save it to a variable
    // var horizontal = InputProxy.GetAxis ("Horizontal");
    // let calculate delta x
    // var dx = Speed * Time.deltaTime * horizontal;
    // and move the ship
    // his.transform.Translate (dx, 0, 0);
    // For Level2 we should do the boundary check
    // if (CanMoveHorizontally (dx, horizontal))

    void MoveHorizontally()
    {
        float horizontal = InputProxy.GetAxis("Horizontal");
        float deltaX = horizontal * Time.deltaTime * Speed;

        if (!CanMoveHorizontally(deltaX, horizontal))
            return;

        transform.Translate(deltaX, 0, 0);
    }


    // This depends on the new x position
    // float newX = transform.position.x + dX;
    // and the direction of the movement
    // return   (horizontal<0 && newX> Min.x) || (horizontal>0 && newX<Max.x);
    bool CanMoveHorizontally(float deltaX, float horizontal)
    {
        float xPosition = transform.position.x + deltaX;
        return (horizontal < 0f && xPosition > Min.x) || (horizontal > 0f && xPosition < Max.x);
    }

    // To read user input you shoud use static class Input
    // To get the value of a vertical axis and save it
    // var vertical = InputProxy.GetAxis ("Vertical");
    // now we need delta y to move the ship
    // var dy = Speed * Time.deltaTime * vertical;
    // And lets move the object
    // this.transform.Translate (0, dy, 0);
    // For Level 2 :)
    // Lets check the boundary
    // if (CanMoveVertically (dy, vertical))

    void MoveVertically()
    {
        float vertical = InputProxy.GetAxis("Vertical");
        float deltaY = vertical * Time.deltaTime * Speed;

        if (!CanMoveVertically(deltaY, vertical))
            return;

        transform.Translate(0, deltaY, 0);		
    }

    // this depends on new y position
    // float newY = transform.position.y + dY;
    // return   (vertical<0 && newY> Min.y) || (vertical>0 && newY<Max.y);
    bool CanMoveVertically(float deltaY, float vertical)
    {
        float yPosition = transform.position.y + deltaY;
        return (vertical < 0 && yPosition > Min.y) || (vertical > 0 && yPosition < Max.y);
    }

}