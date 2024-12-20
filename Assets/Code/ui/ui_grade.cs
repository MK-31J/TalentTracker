using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ui_grade : MonoBehaviour {
    
    public Grade grade;
    
    public TextMeshProUGUI  tPer;
    public TextMeshProUGUI  tGrade;
    public TextMeshProUGUI  tHours;
    public TextMeshProUGUI  tWeeks;
    public TextMeshProUGUI  tAdd;
    public TextMeshProUGUI  tYear;
    public RawImage bg;

    void Start() {
        StartCoroutine(ExecuteTasks());
    }

    IEnumerator ExecuteTasks() {
        yield return new WaitForSeconds(0.001f); // Wait for 1 second
        DisplayData();
    }

    private void DisplayData() {
        if (grade.Exp <= Logic.GetCurrentGrade()) {
            tPer.text = Logic.CountPrcByGrade(grade.Exp).ToString();
        }
        
        tGrade.text = grade.Exp.ToString("000");
        tHours.text = Logic.CountAllHoursByGrade(grade.Exp).ToString();
        tWeeks.text = grade.Week.ToString();
        tAdd.text = grade.Hour.ToString();
        tYear.text = (Logic.CountAllHoursByGrade(grade.Exp)/10/51).ToString();
        
        switch (grade.Exp) {
            case < 50:
                bg.color = Meta.clGrade1;
                break;
            case >= 50 and <= 70:
                bg.color = Meta.clGrade2;
                break;
            case > 70 and < 100:
                bg.color = Meta.clGrade3;
                break;
            case >= 100:
                bg.color = Meta.clGrade4;
                break;
        }
    }
}
