using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton_2 : MonoBehaviour {
    public Colors color;
    public Puzzle_2 puzzle;
    private Image img;
    private float initAlpha;

    void Start() {
        img = GetComponent<Image>();
        initAlpha = img.color.a;
    }

    void Update() {
        if (img.color.a > initAlpha) {
            Color c = img.color;
            c.a -= 1.0f * Time.deltaTime;
            img.color = c;
        }
    }

    public void Press() {
        if (puzzle.State != PuzzleState._5_YELLOW_FINISHED) {
            print("pressed " + color);
            Color c = img.color;
            c.a = 1.0f;
            img.color = c;
            puzzle.Press(color);
        }
    }
}
