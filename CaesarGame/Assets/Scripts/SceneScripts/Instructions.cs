using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instructions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionField = null;
    [SerializeField] PlayerPlatformerController player = null;
    [SerializeField] float endInstructionsDelay = 3f;

    string[] instructions = new string[5];
    bool task1Completed = false;
    bool task2Completed = false;
    bool task3Completed = false;
    bool task4Completed = false;

    void Start()
    {
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
        if (Input.GetKey(KeyCode.LeftArrow) && !task1Completed)
        {
            instructionField.text = instructions[1];
            task1Completed = true;
        }
    }

    private void TaskTwo()
    {
        if (Input.GetKey(KeyCode.Space) && !task2Completed)
        {
            instructionField.text = instructions[2];
            task2Completed = true;
        }
    }

    private void TaskThree()
    {
        if (player.isSliding && !task3Completed)
        {
            instructionField.text = instructions[3];
            task3Completed = true;
        }
    }

    private void TaskFour()
    {
        if (Input.GetKey(KeyCode.LeftControl) && !task4Completed)
        {
            instructionField.text = instructions[4];
            task4Completed = true;
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
