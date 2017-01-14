import java.awt.List;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Date;

public class GiftSudgestor {
	ArrayList<String> giftList = new ArrayList<String>();

	public static void main(String[] args) {
		GiftSudgestor sudgester = new GiftSudgestor();
		Person pesho = new Person("Pesho", new Date());
		if (isHollyday(pesho)) {
			String present;
			System.out.println("Sudgestoin: " + (present = sudgester.getRandomPresent()));
			System.out.println("Can be found at: " + sudgester.sudgestPlaces(present));
		}
	}

	public GiftSudgestor() {
		giftList.add("candy");
		giftList.add("flower");
		giftList.add("clothes");
		giftList.add("love");
	}

	public String getRandomPresent() {
		int num = (int) (Math.random() * giftList.size());
		return this.giftList.get(num);
	}

	public static boolean isHollyday(Person person) {
		Date date = new Date();
		if (date.getMonth() == 12 && date.getDay() == 25) {
			return true;
		} else if (person != null && person.hasBirthday()) {
			return true;
		} else {
			return false;
		}
	}

	public String sudgestPlaces(String gift) {
		switch (gift) {
		case "candy":
			return "The candy shop.";
		case "flower":
			return "The flower shop.";
		case "clothes":
			return "The clothes shop.";
		case "love":
			return "Your heart!";

		default:
			return "As if a program could tell you that!!";
		}
	}
}
