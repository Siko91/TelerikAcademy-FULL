import java.util.ArrayList;

public class Custumer {
	private ArrayList<Movie> rentedMovies;

	public Custumer() {
		this.setRentedMovies(new ArrayList<Movie>());
	}

	ArrayList<Movie> getRentedMovies() {
		return rentedMovies;
	}

	void setRentedMovies(ArrayList<Movie> rentedMovies) {
		this.rentedMovies = rentedMovies;
	}
}
