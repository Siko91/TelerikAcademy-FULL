package com.example.fragmentshmwk;

import java.util.ArrayList;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.ActionBarActivity;
import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.app.Fragment;
import android.app.FragmentTransaction;
import android.os.Build;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

@TargetApi(Build.VERSION_CODES.HONEYCOMB)
@SuppressLint("NewApi")
public class MainActivity extends ActionBarActivity {

	private ArrayList<ProductItem> products;

	@TargetApi(Build.VERSION_CODES.HONEYCOMB)
	@SuppressLint("NewApi")
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		this.products = new ArrayList<ProductItem>();
		for (int i = 0; i < 5; i++) {
			this.products.add(new ProductItem("item " + i, i, "Cat" + i, i * 4,
					i * 2));
		}

		((Button)this.findViewById(R.id.button1)).setOnClickListener(new OnClickListener() {
			public void onClick(View v) {
				goToList();
			}
		});
		
		goToList();
		
	}

	private void goToList() {
		ProductListFragment fr = new ProductListFragment();
		fr.setProducts(products, this);
		android.app.FragmentManager fm = getFragmentManager();
		FragmentTransaction fragmentTransaction = fm.beginTransaction();
		fragmentTransaction.replace(R.id.fragment_place, fr);
		fragmentTransaction.commit();
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	public void itemClicked(int id) {
		ProductItem item = null;
		for (int i = 0; i < this.products.size(); i++) {
			if (this.products.get(i).id == id) {
				item = this.products.get(i);
				break;
			}
		}
		
		ProductDetailFragment fr = new ProductDetailFragment();
		fr.setProduct(item);
		android.app.FragmentManager fm = getFragmentManager();
		android.app.FragmentTransaction fragmentTransaction = fm.beginTransaction();
		fragmentTransaction.replace(R.id.fragment_place, fr);
		fragmentTransaction.commit();
	}
}
