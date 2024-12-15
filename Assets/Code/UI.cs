using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	// public Sprite[] itemImages;

	public bool updHeader;
	public bool updMsg;
	public bool updTrend;
	public bool updScene;
	public bool updControl;
	public bool updMotivation;

	public bool updAll;


	public static float widthScreen;

	// public bool updFooter;

	// public bool updCounter;
	// public bool updContent;
	// public bool updMain;

	// public GameObject pr_circle;
	// public GameObject pr_word;
	public GameObject pr_item;
	public GameObject pr_score;
	public GameObject pr_rec;


	// GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI GUI
    
	public MonoBehaviour MakeInstance(GameObject pr, Transform parent) {
		Transform trPr = Instantiate(pr, new Vector2(0, 0), Quaternion.identity).transform;
		trPr.SetParent(parent, false);
		MonoBehaviour script = trPr.GetComponent<MonoBehaviour>();
		return script;
	}
    
    
	public Transform MakeInstance(GameObject pr, Transform parent, int spare) {
		Transform trPr = Instantiate(pr, new Vector2(0, 0), Quaternion.identity).transform;
		trPr.SetParent(parent, false);
		return trPr;
	}

	public void DeleteDiv(Transform div) {
		if (div.childCount > 0) {
			for (int i = 0; i < div.childCount; i++) {
				Destroy(div.GetChild(i).gameObject);
			}
		}
	}
 
}