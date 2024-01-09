using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateQuestions : MonoBehaviour
{
    private int[] possibleOperands =  new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, -1, -2, -3, -4, -5,-6, -7, -8, -9, -10, -11, -12 };
    private char[] possibleOperaitons = new char[] { '+', '-', 'x', '/' };

    private int chosenOperand1;
    private int chosenOperand2;
    private char chosenOperation;
    public int answer;

    public static bool solved = true;

    public Text txtEquation;
    // Start is called before the first frame update
    void Start()
    {
        solved = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (solved)
        {
            solved = false;
            generateRandomEquation();
        }
    }

    void generateRandomEquation()
    {
        chosenOperand1 = possibleOperands[Random.Range(0, possibleOperands.Length)];
        chosenOperand2 = possibleOperands[Random.Range(0, possibleOperands.Length)];
        chosenOperation = possibleOperaitons[Random.Range(0, possibleOperaitons.Length)];

        if (chosenOperand2 == 0 && chosenOperation == '/')
        {
            solved = true;
        }
        else
        {
            switch (chosenOperation)
            {
                case '+':
                    answer = chosenOperand1 + chosenOperand2;
                    break;
                case '-':
                    answer = chosenOperand1 - chosenOperand2;
                    break;
                case 'x':
                    answer = chosenOperand1 * chosenOperand2;
                    break;
                case '/':
                    answer = chosenOperand1 / chosenOperand2;
                    break;
            }
            txtEquation.text = chosenOperand1 + " " + chosenOperation + " " + chosenOperand2 + " = ?";
        }

        
    }
}
