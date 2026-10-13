using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
    void Update()
    {
        this.AInput();
        this.DInput();
        this.SInput();
        this.WInput();
    }
    protected virtual bool AInput()
    {
        return Input.GetKey(KeyCode.A);
    }
    protected virtual bool DInput()
    {
        return Input.GetKey(KeyCode.D);
    }
    protected virtual bool SInput()
    {
        return Input.GetKey(KeyCode.S);
    }
    protected virtual bool WInput()
    {
        return Input.GetKey(KeyCode.W);
    }
}
