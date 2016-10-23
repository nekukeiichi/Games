using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

    private Camera mainCam;

    //the power up timer
    private float maxPower;
    //The current time the finger is held
    private float currPower;
    //The flag for the charge jump
    private bool isPowering;
	private float GlobalTime;
	// Use this for initialization
	void Start ()
    {
        mainCam = Camera.main;

        //limit the power jump timer
        maxPower = 0.35f;
        isPowering = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameStateMachine.CanPlay())
        {

// #if UNITY_ANDROID || UNITY_IOS
            //Touch controls
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                isPowering = true;
            }

            if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Shout Row!!! o.o
                FloorManager.RowFloor();

                if (currPower > maxPower)
                {
                    //Move the ropper in the desired direction
                    if (Input.mousePosition.x > (Screen.width / 2.0f))
                    {
                        // PlayerFSM.PowerJumpRight();changes made for the alpha
                        PlayerFSM.MoveToRight();
					
                    }
                    else
                    {
                        //PlayerFSM.PowerJumpLeft(); changes made for the alpha
                        PlayerFSM.MoveToLeft();
					
                    }
                }
                else
                {
                    //Move the ropper in the desired direction
                    if (Input.mousePosition.x > (Screen.width / 2.0f))
                    {
                        PlayerFSM.MoveToRight();
                    }
                    else
                    {
                        PlayerFSM.MoveToLeft();
                    }
                }

                isPowering = false;
                currPower = 0.0f;
                ScoreManager.AddPoint();
            }
//#else
            //Debug controls
            if (Input.GetKeyDown(KeyCode.Mouse0))
             {
                 isPowering = true;
             }

             //Mouse down
             if (Input.GetKeyUp(KeyCode.Mouse0))
             {
                 //Shout Row!!! o.o
                 FloorManager.RowFloor();

                 if (currPower > maxPower)
                 {
                     //Move the ropper in the desired direction
                     if (Input.mousePosition.x > (Screen.width / 2.0f))
                     {
                         // PlayerFSM.PowerJumpRight();changes made for the alpha
                         PlayerFSM.MoveToRight();

                     }
                     else
                     {
                         //PlayerFSM.PowerJumpLeft(); changes made for the alpha
                         PlayerFSM.MoveToLeft();

                     }
                 }
                 else
                 {
                     //Move the ropper in the desired direction
                     if (Input.mousePosition.x > (Screen.width / 2.0f))
                     {
                         PlayerFSM.MoveToRight();
                     }
                     else
                     {
                         PlayerFSM.MoveToLeft();
                     }
                 }

                 isPowering = false;
                 currPower = 0.0f;
                 ScoreManager.AddPoint();
             }



             //Charge the jump if we hold the finger too much
             if (isPowering)
             {
                 currPower += Time.deltaTime;
             }
//#endif
            GlobalTime += Time.deltaTime;
            //Drain the player's energy
			PlayerFSM.DrainEnergy(Time.fixedDeltaTime+(float)(GlobalTime*0.000077));
        }
	}
}
