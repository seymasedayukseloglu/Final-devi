using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathProblemManager : MonoBehaviour
{
    public Text mathProblemText; // UI text element for math problems
    public ScoreTimeHesaplama1 scoreScript; // Reference to ScoreTimeHesaplama script

    // Class representing a math problem
    public class MathProblem
    {
        public int ID; // Problem ID
        public string Problem; // Problem text

        public MathProblem(int id, string problem)
        {
            ID = id;
            Problem = problem;
        }
    }

    private int easyIndex = 0;
    private int mediumIndex = 0;
    private int hardIndex = 0;
    private int specialIndex = 0;
    private bool problemsSet = false;

    private List<MathProblem> easyProblemsList = new List<MathProblem>();
    private List<MathProblem> mediumProblemsList = new List<MathProblem>();
    private List<MathProblem> hardProblemsList = new List<MathProblem>();
    private List<MathProblem> specialProblemsList = new List<MathProblem>();

    private List<MathProblem>[] problemLists;

    void Start()
    {
        if (!problemsSet)
            SetProblems();

        problemLists = new List<MathProblem>[] { specialProblemsList, easyProblemsList, mediumProblemsList, hardProblemsList };

        InvokeRepeating("ShowNextSpecialProblem", 0f, 1f);
    }

    void SetProblems()
    {
        AddProblemsToList(specialProblems, specialProblemsList);
        AddProblemsToList(easyProblems, easyProblemsList);
        AddProblemsToList(mediumProblems, mediumProblemsList);
        AddProblemsToList(hardProblems, hardProblemsList);

        problemsSet = true;
    }

    private void AddProblemsToList(List<string> problems, List<MathProblem> problemList)
    {
        foreach (string problem in problems)
        {
            problemList.Add(new MathProblem(problemList.Count + 1, problem));
        }
    }

    public void ShowNextSpecialProblem()
    {
        if (specialIndex < specialProblemsList.Count)
        {
            mathProblemText.text = specialProblemsList[specialIndex].Problem;
            specialIndex++;
        }
        else
        {
            CancelInvoke("ShowNextSpecialProblem");
            InvokeRepeating("ShowNextEasyProblem", 0f, 5f);
        }
    }

    public void ShowNextEasyProblem()
    {
        if (easyIndex < easyProblemsList.Count)
        {
            mathProblemText.text = easyProblemsList[easyIndex].Problem;
            easyIndex++;
        }
        else
        {
            CancelInvoke("ShowNextEasyProblem");
            InvokeRepeating("ShowNextMediumProblem", 0f, 7f);
        }
    }

    public void ShowNextMediumProblem()
    {
        if (mediumIndex < mediumProblemsList.Count)
        {
            mathProblemText.text = mediumProblemsList[mediumIndex].Problem;
            mediumIndex++;
        }
        else
        {
            CancelInvoke("ShowNextMediumProblem");
            InvokeRepeating("ShowNextHardProblem", 0f, 9f);
        }
    }

    public void ShowNextHardProblem()
    {
        if (hardIndex < hardProblemsList.Count)
        {
            mathProblemText.text = hardProblemsList[hardIndex].Problem;
            hardIndex++;
        }
        else
        {
            Debug.Log("All problems are completed.");
            CancelInvoke("ShowNextHardProblem");
        }
    }

    public void IncrementScore()
    {
        scoreScript.IncreaseScore();
    }

    // Problem lists
    private List<string> specialProblems = new List<string>()
    {
        "Problems are coming...",
        "3",
        "2",
        "1"
    };

    private List<string> easyProblems = new List<string>()
    {
        "5 + 3 x 2 =",
        "4 + 2 x 3 =",
        "10 - 2 + 3 =",
        "6 ÷ 2 + 1 =",
        "2 x 5 - 3 =",
        "9 - 4 x 2 ="
    };

    private List<string> mediumProblems = new List<string>()
    {
        "6 x 4 + 2 - 3 =",
        "18 ÷ 3 + 1 x 2 =",
        "4 + 5 x 3 - 2 =",
        "3 x 7 - 2 =",
        "24 ÷ 4 - 5 + 2 =",
        "8 - 2 x 3 + 4 ="
    };

    private List<string> hardProblems = new List<string>()
    {
        "3 x 7 + 4 - 6 =",
        "30 ÷ 6 + 2 -1 =",
        "40 ÷ 8 - 2 + 6 =",
        "25 - 3 x 6 ÷ 3 =",
        "21 + 3 ÷ 6 x 4 =",
        "72 ÷ 9 - 3 + 6 ="
    };
}