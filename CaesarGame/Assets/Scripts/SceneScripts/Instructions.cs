using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum Alpha { Transparent, Visible }

public class Instructions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionField = null;
    [SerializeField] float endInstructionsDelay = 1f;

    int instructionIndex = 0;

    string[] instructions = new string[5];

    void Start()
    {
        SetInstructions(instructions);
        instructionField.text = instructions[instructionIndex];
        instructionField.CrossFadeAlpha(1f, endInstructionsDelay, false);

    }

    public void LoadInstructions()
    {
        instructionIndex++;
        if(instructionIndex < instructions.Length)
        {
            instructionField.CrossFadeAlpha(0, endInstructionsDelay, false);
            StartCoroutine(ChangeInstruction());
        }
        else
        {
            StartCoroutine(EndInstructions());
        }
    }

    IEnumerator ChangeInstruction()
    {
        yield return new WaitForSeconds(endInstructionsDelay);
        instructionField.text = instructions[instructionIndex];
        instructionField.CrossFadeAlpha(1f, endInstructionsDelay, false);

    }

    IEnumerator EndInstructions()
    {

        yield return new WaitForSecondsRealtime(endInstructionsDelay);
        Destroy(gameObject);
        
    }

    private void SetInstructions(string[] instructions)
    {
        instructions[0] = "Lets get started! Try to move with right and left arrow keys.";
        instructions[1] = "Good! Now try to jump with the space bar.";
        instructions[2] = "Well done, next one is tricky. Slide by pressing the down arrow and space bar at the same time.";
        instructions[3] = "Awesome! You are a true treasure hunter. You can fight enemies by pressing the left ctrl key.";
        instructions[4] = "Yesss! That's it you got it girl! You can now begin the hunt for the ancient treasure, by going through the gate. Good luck!";

    }



}
