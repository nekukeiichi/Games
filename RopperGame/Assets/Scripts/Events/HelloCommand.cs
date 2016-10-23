using UnityEngine;
using System.Collections;
using System;

public class HelloCommand : ICommand
{
    private string callsign;

    public HelloCommand(string _text)
    {
        callsign = _text;
    }

    public override void Execute()
    {
        Debug.Log(callsign);
    }
}