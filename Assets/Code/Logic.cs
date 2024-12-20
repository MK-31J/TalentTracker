
using System;
using System.Linq;
using UnityEngine;

public class Logic {
	public static string GetCodeByGrade(int grade) {

		switch (grade) {
			case 1:
				return "A";
			case 2:
				return "B";
			case 3:
				return "C";
			case 4:
				return "D";
			case 5:
				return "E";
			case 6:
				return "F";
			case 7:
				return "G";
			case 8:
				return "H";
			case 9:
				return "I";
			case 10:
				return "J";
			case 11:
				return "K";
			case 12:
				return "L";
			case 13:
				return "Z";
			case 14:
				return "Y";
			default:
				return "A";
		}

	}

	public static int GetNextIdByGrade(int grade) {
		
		var filteredGrade = Engine.ctrl.scores.Where(item => item.Grade == grade)
								  .Select(item => item.N);
		int max = 0;
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

	public static bool FindRecToday() {
		foreach (var v in Engine.ctrl.recs) {
			if (v.Day.Date == DateTime.Today.Date) {
				return true;
			}
		}

		return false;
	}

	public static int CountPrcByGrade(int gradeExp) {
		int pr;
		double p = 0;

		var allMin = 15 * Engine.ctrl.recs
									.SelectMany(rec => rec.Exercises)
									.Sum(exercise => exercise._quarter);
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

		pr = (int)p;
		return pr;
	}

	public static int CountAllHoursByGrade(int gradeExp) {
		int h = 0;
		foreach (var v in Engine.ctrl.grades) {
			if (gradeExp >= v.Exp) {
				h += v.Hour;
			}
		}

		return h;
	}
	
	public static int GetCurrentGrade() {
		int l = 0;
	
		var allMin = 15 * Engine.ctrl.recs
								.SelectMany(rec => rec.Exercises)
								.Sum(exercise => exercise._quarter);
		var allHours = allMin / 60;

		foreach (var v in Engine.ctrl.grades) {
			if (allHours < CountAllHoursByGrade(v.Exp)) {
				l = v.Exp;
				break;
			}
		}
	
		return l;
	}
	
}
