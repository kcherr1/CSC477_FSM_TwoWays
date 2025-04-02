using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = PuzzleState;

public class Puzzle_2 : MonoBehaviour {
    public State State { get; private set; }
    private Colors lastColor;

    private Dictionary<State, Action> stateEnterMethods;
    private Dictionary<State, Action> stateStayMethods;

    void Start() {
        stateEnterMethods = new() {
            [State.IDLE] = StateEnter_Idle,
            [State._1_BLUE] = StateEnter_1_Blue,
            [State._2_RED] = StateEnter_2_Red,
            [State._3_BLUE] = StateEnter_3_Blue,
            [State._4_GREEN] = StateEnter_4_Green,
            [State._5_YELLOW_FINISHED] = StateEnter_5_Yellow_Finished,
            [State.ERROR] = StateEnter_Error,
        };
        stateStayMethods = new() {
            [State.IDLE] = StateStay_Idle,
            [State._1_BLUE] = StateStay_1_Blue,
            [State._2_RED] = StateStay_2_Red,
            [State._3_BLUE] = StateStay_3_Blue,
            [State._4_GREEN] = StateStay_4_Green,
            [State._5_YELLOW_FINISHED] = StateStay_5_Yellow_Finished,
            [State.ERROR] = StateStay_Error,
        };
        lastColor = Colors.NONE;
        State = State.IDLE;
    }

    void Update() {
        if (lastColor == Colors.NONE) {
            return;
        }
        stateStayMethods[State]();
        lastColor = Colors.NONE;
    }
    private void ChangeState(State newState) {
        if (State != newState) {
            State = newState;
            stateEnterMethods[newState]();
        }
    }

    #region State Methods
    #region State Enter Methods
    private void StateEnter_Idle() {}
    private void StateEnter_1_Blue() {
        SoundManager.Play(SoundType.CORRECT, pitch:0.5f);
    }
    private void StateEnter_2_Red() {
        SoundManager.Play(SoundType.CORRECT, pitch: 0.65f);
    }
    private void StateEnter_3_Blue() {
        SoundManager.Play(SoundType.CORRECT, pitch: 0.8f);
    }
    private void StateEnter_4_Green() {
        SoundManager.Play(SoundType.CORRECT, pitch: 0.95f);
    }
    private void StateEnter_5_Yellow_Finished() {
        SoundManager.Play(SoundType.FINISHED, pitch: 1.0f);
    }
    private void StateEnter_Error() {
        SoundManager.Play(SoundType.WRONG);
        ChangeState(State.IDLE);
    }
    #endregion

    #region State Stay Methods
    private void StateStay_Idle() {
        if (lastColor == Colors.BLUE)
            ChangeState(State._1_BLUE);
        else
            ChangeState(State.ERROR);
    }
    private void StateStay_1_Blue() {
        if (lastColor == Colors.RED) {
            ChangeState(State._2_RED);
        }
        else {
            ChangeState(State.ERROR);
        }
    }
    private void StateStay_2_Red() {
        if (lastColor == Colors.BLUE) {
            ChangeState(State._3_BLUE);
        }
        else {
            ChangeState(State.ERROR);
        }
    }
    private void StateStay_3_Blue() {
        if (lastColor == Colors.GREEN) {
            ChangeState(State._4_GREEN);
        }
        else {
            ChangeState(State.ERROR);
        }
    }
    private void StateStay_4_Green() {
        if (lastColor == Colors.YELLOW) {
            ChangeState(State._5_YELLOW_FINISHED);
        }
        else {
            ChangeState(State.ERROR);
        }
    }
    private void StateStay_5_Yellow_Finished() {

    }
    private void StateStay_Error() {

    }
    #endregion
    #endregion
    public void Press(Colors color) {
        print("setting color to " + color);
        lastColor = color;
    }
}
