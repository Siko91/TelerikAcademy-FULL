import java.util.ArrayList;
import java.util.Date;

public class Store {
	private static final int MonthsOfRentPeriod = 2;
	private ArrayList<Movie> movies;
	private ArrayList<Custumer> custumers;

	public Store() {
		this.setMovies(new ArrayList<Movie>());
		this.custumers = new ArrayList<Custumer>();
	}

	ArrayList<Movie> getMovies() {
		return movies;
	}

	void setMovies(ArrayList<Movie> movies) {
		this.movies = movies;
	}

	void addMovie(Movie movie) {
		this.getMovies().add(movie);
	}

	void rentMovieTo(Movie movie, Custumer customer) {
		if (!this.custumers.contains(customer)) {
			this.custumers.add(customer);
		}
		if (movie.isReturned()) {
			return;
		}
		customer.getRentedMovies().add(movie);
		movie.setReturned(true);
		movie.setRentedOn(new Date());
	}

	ArrayList<Custumer> getOverDueCustomers() {
		ArrayList<Custumer> overdueCustumers = new ArrayList<Custumer>();

		Date today = new Date();
		Date dateBorder = new Date(today.getYear(), today.getMonth()
				- this.MonthsOfRentPeriod, today.getDay());

		for (Custumer custumer : this.custumers) {
			for (Movie movie : custumer.getRentedMovies()) {
				if (movie.getRentedOn().before(dateBorder)) {
					overdueCustumers.add(custumer);
				}
			}
		}

		return overdueCustumers;
	}
}
