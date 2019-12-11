using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instructions : MonoBehaviour
{
    string[] instructions = new string[5];
    [SerializeField] TextMeshProUGUI instructionField;
    [SerializeField] PlayerPlatformerController player;
    [SerializeField] float endInstructionsDelay = 3f;
    void Start()
    {
        instructionField = FindObjectOfType<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerPlatformerController>();
        setInstructions(instructions);
        instructionField.text = instructions[0];
    }

    // Update is called once per frame
    void Update()
    {
        TaskOne();
        TaskTwo();
        TaskThree();
        TaskFour();
    }

    private void TaskOne()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            instructionField.text = instructions[1];
        }
    }

    private void TaskTwo()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            instructionField.text = instructions[2];
        }
    }

    private void TaskThree()
    {
        if (player.isSliding)
        {
            instructionField.text = instructions[3];
        }
    }

    private void TaskFour()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            instructionField.text = instructions[4];
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
        instructions[4] = "Yesss! That's it you got it girl! You can now begin the hunt for the ancient treasure. Find the gate to the next level. Good luck!";

    }



}
