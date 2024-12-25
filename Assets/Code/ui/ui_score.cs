using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ui_score : MonoBehaviour {
    
    public Score score;

    public TextMeshProUGUI  tCode;
    public TextMeshProUGUI  tTitle;
    public TextMeshProUGUI  tComposer;
    public TextMeshProUGUI  tStart;
    public TextMeshProUGUI  tDay;
    public Button bChange;

    private void Start() {
        
        StartCoroutine(ExecuteTasks());
    }

    private IEnumerator ExecuteTasks() {
        yield return new WaitForSeconds(0.1f); // Wait for 1 second
        DisplayData();
    }
    
    private void DisplayData() {

        bChange.onClick.AddListener(ChangeData);
        tCode.color = Meta.clScoreStyle[score.Style];
        
        tCode.text = score.Code;
        tTitle.text = score.Title;
        tComposer.text = score.Composer;

        if (score.StartTime.Year > 1) {
            tStart.text = score.StartTime.ToString("dd.MM.yyyy");
        }

        if (score.StartTime.Year > 1) {
            if (score.EndTime.Year > 1) {
                tDay.text = (score.EndTime - score.StartTime).Days+1 + "d";

            } else {
                tDay.text = (DateTime.Today - score.StartTime).Days+1 + "d";
            }
            
        }

        bChange.transform.GetChild(0).GetComponent<Image>().color = Meta.clScoreSts[score.Sts];

    }

    private void ChangeData() {
        Controller.actualScore = score;
        Controller.stsScoreChange = 1;
    }
       

}
