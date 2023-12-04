using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeStyle
{
    //Constants
    public const int CONST_FIELD = 14;

    //Properties
    public static CodeStyle Instance { get; private set; }

    //Events
    public event EventHandler OnSomethingHappened;

    //Fields
    private float memberVariable;

    //Fuction Name
    private void Awake()
    {
        Instance= this;
        DoSomething(10f);
    }

    //Function Params
    private void DoSomething(float time)
    {
        memberVariable = time+Time.deltaTime;
        //Do st
    }
}
