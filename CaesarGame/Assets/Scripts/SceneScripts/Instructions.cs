using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instructions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionField = null;
    [SerializeField] PlayerPlatformerController player = null;
    [SerializeField] float endInstructionsDelay = 0.1f;
    int instructionIndex = 0;

    string[] instructions = new string[5];

    void Start()
    {
        setInstructions(instructions);
        instructionField.text = instructions[instructionIndex];
    }


    public void LoadInstructions()
    {


        instructionIndex++;
        if(instructionIndex < instructions.Length)
        {
            instructionField.text = instructions[instructionIndex];
        }
        else
        {
            StartCoroutine(EndInstructions());
        }
    }



    IEnumerator EndInstructions()
    {

        yield return new WaitForSecondsRealtime(endInstructionsDelay);
        Destroy(gameObject);
        
    }

    private void setInstructions(string[] instructions)
    {
        instructions[0] = "Lets get started! Try to move with right and left arrow keys.";
        instructions[1] = "Good! Now try to jump with the space bar.";
        instructions[2] = "Well done, next one is tricky. Slide by pressing the down arrow and space bar at the same time.";
        instructions[3] = "Awesome! You are a true treasure hunter. You can fight enemies by pressing the left ctrl key.";
        instructions[4] = "Yesss! That's it you got it girl! You can now begin the hunt for the ancient treasure, by going through the gate. Good luck!";

    }



}
