using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = PuzzleState;

public class Puzzle_1 : MonoBehaviour {
    public State State { get; private set; }
    private Colors lastColor;

    void Start() {
        lastColor = Colors.NONE;
        State = State.IDLE;
    }

    void Update() {
        if (lastColor == Colors.NONE) {
            return;
        }
        switch (State) {
            case State.IDLE:
                if (lastColor == Colors.BLUE) 
                    ChangeState(State._1_BLUE);
                else 
                    ChangeState(State.ERROR);
                break;

            case State._1_BLUE:
                if (lastColor == Colors.RED) {
                    ChangeState(State._2_RED);
                }
                else {
                    ChangeState(State.ERROR);
                }
                break;
            case State._2_RED:
                if (lastColor == Colors.BLUE) {
                    ChangeState(State._3_BLUE);
                }
                else {
                    ChangeState(State.ERROR);
                }
                break;
            case State._3_BLUE:
                if (lastColor == Colors.GREEN) {
                    ChangeState(State._4_GREEN);
                }
                else {
                    ChangeState(State.ERROR);
                }
                break;
            case State._4_GREEN:
                if (lastColor == Colors.YELLOW) {
                    ChangeState(State._5_YELLOW_FINISHED);
                }
                else {
                    ChangeState(State.ERROR);
                }
                break;
            case State.ERROR:
                ChangeState(State.IDLE);
                break;
        }
        lastColor = Colors.NONE;
    }
    private void ChangeState(State newState) {
        print($"Changing state to {newState}");
        if (State != newState) {
            State = newState;
            switch (newState) {
                case State.IDLE:
                    // do nothing
                    break;
                case State._1_BLUE:
                case State._2_RED:
                case State._3_BLUE:
                case State._4_GREEN:
                    SoundManager.Play(SoundType.CORRECT);
                    break;
                case State._5_YELLOW_FINISHED:
                    SoundManager.Play(SoundType.FINISHED);
                    break;
                case State.ERROR:
                    SoundManager.Play(SoundType.WRONG);
                    ChangeState(State.IDLE);
                    break;
            }
        }
    }
    public void Press(Colors color) {
        print("setting color to " + color);
        lastColor = color;
    }
}
