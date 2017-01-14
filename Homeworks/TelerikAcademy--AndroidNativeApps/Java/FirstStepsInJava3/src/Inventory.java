import java.util.ArrayList;

public class Inventory {

	public static void main(String[] args) {
		Inventory inventory = new Inventory();
		inventory.getProducts().add(new Product("bob", 5.20, 40));
		inventory.getProducts().add(new Product("Shkembe", 15.55, 40));
		inventory.getProducts().add(new Product("o6te Shkembe", 15.55, 40));
		inventory.getProducts().add(new Product("davki orbit", 0.99, 400));
		
		double sum = inventory.getTotal();
		System.out.println(sum);
	}

	private ArrayList<Product> products;

	public Inventory() {
		this.products = new ArrayList<Product>();
	}
	public Inventory(ArrayList<Product> products) {
		this.setProducts(products);
	}

	public double getTotal(){
		double result = 0;
		for (Product prod : this.getProducts()) {
			result += prod.getPrice();
		}
		return result;
	}
	public ArrayList<Product> getProducts() {
		return products;
	}
	public void setProducts(ArrayList<Product> products) {
		this.products = products;
	}
}
