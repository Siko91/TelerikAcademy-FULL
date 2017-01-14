import java.util.UUID;

public class Product {
	private double price;
	private String name;
	private String id;
	private int quantity;

	public Product(String name, double price, int quality) {
		this.setName(name);
		this.setPrice(price);
		this.setQuantity(quality);
		this.setId(UUID.randomUUID().toString());
	}

	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {
		this.price = price;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}
}
