using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/**
 * This class manages the States and calls in each frame the UpdateState function of the currentState
 *
 * You dont have to code anything here except the initialization of your own StateScript.
 * Use your own script like the "TESTInitState.cs" or the "TESTsecondState.cs" inside the "State Scripts" folder.
 * To use your script, you have to initialize it at (1) and make it reachable from the initstate
 *
 * To test or debug your script you can temporarily change the currentState in the Start() function to your function name
 * which then makes your script the first one which runs
 */
public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    BaseState currentState;
    

    #region State Initialization
    // (1) Declare your scripts / states here like this  make them public to use them at other locations
    public BaseState Map;
    public BaseState Test;
    public BaseState EnterFight;
    public BaseState Fight;
    public BaseState LeaveFight;
    /// end of (1)
    #endregion

    #region Global variables

    // Set here global variables 


    /// 

    #endregion

    private void Awake()
    {
        // create singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        
        // assign / initialize the declared states
        Map = gameObject.AddComponent<MapState>();
        Test = gameObject.AddComponent<TestState>();
        EnterFight = gameObject.AddComponent<EnterFight>();
        Fight = gameObject.AddComponent<Fight>();
        LeaveFight = gameObject.AddComponent<LeaveFight>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = Map;
        currentState.EnterState();
    }


    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }

    public void SwitchState(BaseState state)
    {
        // Make transition between current and next state
        currentState.LeaveState();
        currentState = state;
        currentState.EnterState();
    }
    

}

