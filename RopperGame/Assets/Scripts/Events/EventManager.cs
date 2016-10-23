using UnityEngine;
using System.Collections;

public class EventManager
{

    private static EventManager pInstance;

    //This is the list of commands that will be executed in the desired time
    private PriorityQueue<ICommand> myCommands;

    //The current time as of right now
    private float timer;

    //The flag to start or stop the timer
    private bool canTick;

    private EventManager()
    {
        //Create the queue
        myCommands = new PriorityQueue<ICommand>();

        //Reset timer to 0
        timer = 0.0f;

        //Start the timer at false
        canTick = false;
    }

    private static EventManager GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new EventManager();
        }
        return pInstance;
    }

    //Add events to the manager
    public static void AddEvent(ICommand _command, float _time)
    {
        //Check if there's no error
        if(_command != null && !GetInstance().myCommands.Contains(_command))
        {
            //Add the command to the queue
            GetInstance().myCommands.Add(_command, _time + GetInstance().timer);
        }
    }

    //Start the timer
    public static void StartEventTimer()
    {
        GetInstance().canTick = true;
    }

    //Stop the timer
    public static void StopEventTimer()
    {
        GetInstance().canTick = false;
    }

    //The tick function
    public static void Tick(float _deltaTime)
    {
        if(GetInstance().canTick)
        {
            //Get our current time
            GetInstance().timer += _deltaTime;

            ICommand tComm = null;

            //Execute all available commands
            while (true)
            {
                //Get the first available command
                tComm = GetInstance().myCommands.ExecuteFirstAvailable(GetInstance().timer);

                //Are we done yet?
                if (tComm == null)
                {
                    //We have no more commands to execute
                    break;
                }

                //Execute the command
                tComm.Execute();
            }
        }
    }
	
}
