using UnityEngine;
using TMPro;
using System.Collections;

public class VRQuestionDisplay : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI feedbackText;

    private bool isInputEnabled = false; // Toggle for input checking
    private bool canChangeOption = true;
    private int selectedOptionIndex = 0;

    void Update()
    {
        if (!isInputEnabled) return; // Disable input checks if isInputEnabled is false

        // Joystick input for option selection
        if (canChangeOption)
        {
            float verticalInput = Input.GetAxis("Vertical"); // Replace this with VR joystick if needed

            if (verticalInput > 0.1f)
            {
                selectedOptionIndex = (selectedOptionIndex - 1 + 3) % 3;
                UpdateQuestionDisplay();
                StartCoroutine(OptionChangeCooldown());
            }
            else if (verticalInput < -0.1f)
            {
                selectedOptionIndex = (selectedOptionIndex + 1) % 3;
                UpdateQuestionDisplay();
                StartCoroutine(OptionChangeCooldown());
            }

            if (Input.GetButtonDown("Submit"))
            {
                CheckAnswer();
            }
        }
    }

    IEnumerator OptionChangeCooldown()
    {
        canChangeOption = false;
        yield return new WaitForSeconds(0.2f);
        canChangeOption = true;
    }

    // Method to enable input (e.g., call this when you want to start registering input)
    public void EnableInput()
    {
        isInputEnabled = true;
    }

    // Method to disable input
    public void DisableInput()
    {
        isInputEnabled = false;
    }

    void UpdateQuestionDisplay()
    {
        // Display the question with the currently selected option highlighted
        // (implement display logic here)
    }

    void CheckAnswer()
    {
        // Check the selected answer
        // (implement answer checking here)
    }
}
