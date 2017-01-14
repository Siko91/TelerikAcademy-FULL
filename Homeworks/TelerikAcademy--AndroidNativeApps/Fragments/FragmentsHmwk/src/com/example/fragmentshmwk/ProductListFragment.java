package com.example.fragmentshmwk;

import java.util.ArrayList;
import java.util.List;
import android.R.integer;
import android.annotation.SuppressLint;
import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.content.Context;
import android.widget.LinearLayout;
import android.widget.TextView;

@SuppressLint("NewApi")
public class ProductListFragment extends Fragment {

	private List<ProductItem> products;
	private Context context;

	public ProductListFragment() {
		this.products = new ArrayList<ProductItem>();
	}

	public void setProducts(List<ProductItem> products, Context context) {
		this.products = products;
		this.context = context;
	}

	private void setListener(View v, final int id) {
		v.setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				((MainActivity) context).itemClicked(id);
			}
		});
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		View v = inflater.inflate(R.layout.fragment_list, container, false);
		LinearLayout list = (LinearLayout) ((ViewGroup) v).getChildAt(0);
		if (list != null) {
			for (ProductItem pr : this.products) {
				View item = CreateProductView(pr);
				list.addView(item);
			}
		}
		return v;
	}

	private View CreateProductView(ProductItem pr) {
		TextView v = new TextView(this.context);
		v.setText(pr.name);
		setListener(v, pr.id);
		return v;
	}
}
