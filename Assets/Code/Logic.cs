
using System.Linq;

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
}
