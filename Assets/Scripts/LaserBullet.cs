using System;
using UnityEngine;
using System.Collections;

public class LaserBullet : MonoBehaviour {

    public const string TAG_LASER_BULLET = "LaserBullet";

	public float Range;
	public float Speed;

	// Update is called once per frame
	void Update () {

		 Move ();
		 CheckRange ();
	}


	// to move the bullet we calculate dY
	// float deltaY = Speed * Time.deltaTime;
	// this.transform.Translate (0, deltaY, 0);

	void Move ()
	{
        Vector3 deltaPosition = new Vector3(0, Time.deltaTime * Speed, 0);
        transform.Translate(deltaPosition);
	}


	// ah and when the object has left our warzone let's destroy it
	// if (this.transform.position.y > Range)
	// Destroy (this.gameObject);

	void CheckRange(){
        if (transform.position.y >= Range)
        {
            Destroy(gameObject);
        }
	}
}
