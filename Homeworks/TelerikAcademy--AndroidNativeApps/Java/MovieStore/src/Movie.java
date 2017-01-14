import java.util.Date;


public class Movie {
	public Movie(String name, double rentPrice) {
		this.setName(name);
		this.setRentPrice(rentPrice);
		this.setReturned(false);
		this.setRentedOn(new Date());
	}
	
	String getName() {
		return name;
	}
	void setName(String name) {
		this.name = name;
	}

	double getRentPrice() {
		return rentPrice;
	}

	void setRentPrice(double rentPrice) {
		this.rentPrice = rentPrice;
	}

	Date getRentedOn() {
		return rentedOn;
	}

	void setRentedOn(Date rentedOn) {
		this.rentedOn = rentedOn;
	}

	boolean isReturned() {
		return isReturned;
	}

	void setReturned(boolean isReturned) {
		this.isReturned = isReturned;
	}

	private String name;
	private double rentPrice;
	private Date rentedOn;
	private boolean isReturned;
}
