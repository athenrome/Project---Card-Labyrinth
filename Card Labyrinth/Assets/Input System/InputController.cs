using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputController {

    static Dictionary<string, KeyCode> _inputEvents = new Dictionary<string, KeyCode>();

    public static void RegisterInputEvent(string eventID, KeyCode eventKey)
    {
        if(_inputEvents.ContainsKey(eventID))
        {
            //Debug.Log($"{eventID} has been rebound from: {_inputEvents[eventID]} to: {eventKey}");
            _inputEvents[eventID] = eventKey;
        }
        else
        {
            _inputEvents.Add(eventID, eventKey);
            //Debug.Log($"{eventID} has been bound to: {eventKey}");
        }
    }

    public static KeyCode GetInputEventKey(string inputEvent)
    {
        if(_inputEvents.ContainsKey(inputEvent))
        {
            return _inputEvents[inputEvent];
        }
        else
        {
            throw new System.Exception($"Unregistered Input Event called: {inputEvent}");
        }
    }

    public static bool CheckInputEvent(string inputEvent)
    {
        if (_inputEvents.ContainsKey(inputEvent))
        {
            return Input.GetKey(_inputEvents[inputEvent]);
        }
        else
        {
            Debug.Log($"Unregistered Input Event called: {inputEvent}");
            return false;
        }
    }
}