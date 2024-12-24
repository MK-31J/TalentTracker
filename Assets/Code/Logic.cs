
using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Logic {
	public static string GetCodeByGrade(int grade) {
		return grade switch {
			1 => "A",
			2 => "B",
			3 => "C",
			4 => "D",
			5 => "E",
			6 => "F",
			7 => "G",
			8 => "H",
			9 => "I",
			10 => "J",
			11 => "K",
			12 => "L",
			13 => "Z",
			14 => "Y",
			_ => "A"
		};
	}

	public static int GetNextIdByGrade(int grade) {
		
		var filteredGrade = Engine.ctrl.scores.Where(item => item.Grade == grade)
														.Select(item => item.N).ToList();
		var max = 0;
		if (filteredGrade.Any()) {
			 max = filteredGrade.Max();
		}
		return max+1;


	}

	public static bool IsScoreExcByCode(string vCode) {
		foreach (var v in Engine.ctrl.scores) {
			if (v.Code == vCode && v.Grade > 12) {
				return true;
			}
		}
		return false;
	}

	public static bool FindRec(DateTime dt) {
		foreach (var v in Engine.ctrl.recs) {
			if (v.Day.Date == dt.Date) {
				return true;
			}
		}

		return false;
	}

	public static int CountPrcByGrade(int gradeExp) {
		double p = 0;

		var allMin = 15 * Engine.ctrl.recs
									.SelectMany(rec => rec.Exercises)
									.Sum(exercise => exercise.Quarter);
		var allHours = allMin / 60;
		
		var allHoursGrade = CountAllHoursByGrade(gradeExp);

		foreach (var v in Engine.ctrl.grades) {
			if (v.Exp == gradeExp) {
				if (allHours < allHoursGrade) {
					p = (double)allHours / allHoursGrade * 100;
				} else {
					p = 100;
				}
			}
		}

		return (int)p;
	}

	public static int CountAllHoursByGrade(int gradeExp) {
		var h = 0;
		foreach (var v in Engine.ctrl.grades) {
			if (gradeExp >= v.Exp) {
				h += v.Hour;
			}
		}

		return h;
	}
	
	public static int GetCurrentGrade() {
		var l = 0;
	
		var allMin = 15 * Engine.ctrl.recs
								.SelectMany(rec => rec.Exercises)
								.Sum(exercise => exercise.Quarter);
		var allHours = allMin / 60;

		foreach (var v in Engine.ctrl.grades) {
			if (allHours < CountAllHoursByGrade(v.Exp)) {
				l = v.Exp;
				break;
			}
		}
	
		return l;
	}

	public static void ChangeScore(string tCode, string iComposer, string iTitle, string iStart, string iFinish) {
		foreach (var v in Engine.ctrl.scores) {
			if (v.Code == tCode) {
				v.Composer = iComposer;
				v.Title = iTitle;
				v.StartTime = DateTime.Parse(iStart);
				v.EndTime = DateTime.Parse(iFinish);
			}
		}
	}

	public static void ChangeRec(DateTime actualRecDay, string s) {
		
		var rec = Engine.ctrl.recs.FirstOrDefault(r => r.Day == actualRecDay);

		// Remove the exercise with the matching code
		rec?.Exercises.RemoveAll(ex => ex.Code == s);
	}

	public static void CheckRecsForEmpty() {
		foreach (var v in Engine.ctrl.recs.Where(v => v.Exercises.Count == 0)) {
			Engine.ctrl.recs.Remove(v);
			break;
		}
	}

	public static void ChangePractice(DateTime actualRecDay, string s) {
		var rec = Engine.ctrl.recs.FirstOrDefault(r => r.Day == actualRecDay);

		if (rec != null) {
			var idx = rec.Exercises.FindIndex(ex => ex.Code == s);
			if (idx == -1) return;
			
			// Get the exercise, modify it, and replace it back
			var exercise = rec.Exercises[idx];
			if (exercise.Quarter < 4) {
				exercise.Quarter++; 
			} else {
				exercise.Quarter = 1;
			}
			rec.Exercises[idx] = exercise;
		}
	}

	public static string GetPageName() {
		return Engine.pageIdx switch {
			0 => "Progress",
			1 => "Scores",
			2 => "Grades",
			3 => "Scales",
			_ => "Progress"
		};
	}

	public static void UpdateScoreSts() {
		for (var i = 0; i < Engine.ctrl.scores.Count; i++) {
			if (Engine.ctrl.scores[i].StartTime.Year > 1 && Engine.ctrl.scores[i].EndTime.Year > 1) {
				Engine.ctrl.scores[i].Sts = 2;
			} else if (Engine.ctrl.scores[i].StartTime.Year > 1) {
				Engine.ctrl.scores[i].Sts = 1;
			}
		}
	}
}
