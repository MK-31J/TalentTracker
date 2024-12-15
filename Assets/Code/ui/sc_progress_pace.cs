using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_progress_pace : MonoBehaviour {
    
    
    public Button btnAddRec;
    

    void Start() {
        btnAddRec.onClick.AddListener(CreateRec);
    }

    private void CreateRec() {
        Engine.ins.SetScene("RecCreate");
    }


}
