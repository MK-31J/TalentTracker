using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ui_score : MonoBehaviour {
    
    public Score _score;
    public int _n;

    public TextMeshProUGUI  tCode;
    public TextMeshProUGUI  tTitle;
    public TextMeshProUGUI  tComposer;
    public TextMeshProUGUI  tSize;
    public TextMeshProUGUI  tStart;
    public TextMeshProUGUI  tDay;
    

    void Start() {
        
        StartCoroutine(ExecuteTasks());
        
    }

    IEnumerator ExecuteTasks() {
        yield return new WaitForSeconds(0.001f); // Wait for 1 second
        DisplayData();
    }
    
    private void DisplayData() {
 
        tCode.text = _score.Code;
        tTitle.text = _score.Title;
        tComposer.text = _score.Composer;
        if (_score.Size > 0) {
            tSize.text = _score.Size.ToString();
        }
        if (_score.StartTime.Year > 1) {
            tStart.text = _score.StartTime.ToString("dd-MM-yyyy");
        }

        if (_score.StartTime.Year > 1) {
            tDay.text = "d";
        }
        
    }


    void Update() {
        
    }
    



        

}