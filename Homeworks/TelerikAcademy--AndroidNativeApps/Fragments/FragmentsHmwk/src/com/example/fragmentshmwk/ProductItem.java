package com.example.fragmentshmwk;

import android.R.integer;

public class ProductItem {

	public ProductItem(String name, int id, String category,
			double quantity, double price) {
		this.name = name;
		this.id = id;
		this.category = category;
		this.quantity = quantity;
		this.price = price;
	}

	String name;
	int id;
	String category;
	double quantity;
	double price;
}
