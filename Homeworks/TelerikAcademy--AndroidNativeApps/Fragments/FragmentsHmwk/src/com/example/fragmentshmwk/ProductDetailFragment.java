package com.example.fragmentshmwk;

import java.util.ArrayList;
import java.util.List;
import android.annotation.SuppressLint;
import android.app.Fragment;
import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

@SuppressLint("NewApi")
public class ProductDetailFragment extends Fragment {
	private ProductItem product;
	private Context context;

	public ProductDetailFragment() {
		this.product = new ProductItem("n", 0, "h", 0, 0);
	}

	public void setProduct(ProductItem product) {
		this.product = product;
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {

		View v = inflater.inflate( R.layout.fragment_detail, container, false);
		LinearLayout arr = (LinearLayout) ((ViewGroup) v).getChildAt(0);

		((TextView) arr.getChildAt(0)).setText("id: " + this.product.id);
		((TextView) arr.getChildAt(1)).setText("name: " + this.product.name);
		((TextView) arr.getChildAt(2)).setText("category: "
				+ this.product.category);
		((TextView) arr.getChildAt(3)).setText("quantity: "
				+ this.product.quantity);
		((TextView) arr.getChildAt(4)).setText("price: " + this.product.price);

		return v;
	}

}
