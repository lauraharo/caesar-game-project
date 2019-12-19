using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instructions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionField = null;
    [SerializeField] float endInstructionsDelay = 1f;

    public int instructionIndex = 0;
    public string[] instructions = new string[5];

    void Start()
    {
        SetInstructions(instructions);
        instructionField.text = instructions[instructionIndex];
        instructionField.CrossFadeAlpha(1f, endInstructionsDelay, false);

    }

    public void LoadInstructions()
    {
        Debug.Log(instructionIndex);
        instructionIndex++;

        if (instructionIndex < instructions.Length) {
            instructionField.CrossFadeAlpha(0, endInstructionsDelay, false);
            StartCoroutine(ChangeInstruction());
        }
        else StartCoroutine(EndInstructions());
    }

    IEnumerator ChangeInstruction()
    {
        yield return new WaitForSeconds(endInstructionsDelay);
        instructionField.text = instructions[instructionIndex];
        instructionField.CrossFadeAlpha(1f, endInstructionsDelay, false);

    }

    IEnumerator EndInstructions()
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(gameObject);
    }

    private void SetInstructions(string[] instructions)
    {
        instructions[0] = "Lets get started! Try to move to the next area with 'Right Arrow' and 'Left Arrow' keys or 'A' and 'D'.";
        instructions[1] = "Good! Now to get further, you need to jump. Try jumping by pressing the 'Space' button or 'K'. Holding the jumping button makes you jump higher";
        instructions[2] = "Well done, the next one is tricky. Slide to the next area by pressing 'Down Arrow' or 'S' and the jumping button at the same time.";
        instructions[3] = "Awesome! We are almost done with the training. Let's see if you can do the final step. Try attacking the spider by pressing the 'Left CTRL' key or 'J'. \n\nBe careful, they can be tough and hurt you, if you get too close!!";
        instructions[4] = "Yesss! That's it you got it girl! You can now begin the hunt for the ancient treasure, by going through the gate. Good luck!";

    }



}
