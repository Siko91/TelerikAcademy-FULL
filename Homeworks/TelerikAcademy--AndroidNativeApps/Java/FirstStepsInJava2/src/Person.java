import java.util.Date;

public class Person {

	private Date birthDay;
	private String name;
	
	public Person(String name, Date birthDay) {
		this.setName(name);
		this.setBirthDay(birthDay);
	}

	String getName() {
		return name;
	}

	void setName(String name) {
		this.name = name;
	}

	Date getBirthDay() {
		return birthDay;
	}

	void setBirthDay(Date birthDay) {
		this.birthDay = birthDay;
	}

	public boolean hasBirthday() {
		Date date = new Date();
		return (date.getMonth() == this.birthDay.getMonth() && 
				date.getDay() == this.birthDay.getDay());
	}

}
