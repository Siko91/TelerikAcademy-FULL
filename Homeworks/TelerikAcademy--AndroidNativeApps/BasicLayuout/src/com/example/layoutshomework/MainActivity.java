package com.example.layoutshomework;

import java.util.concurrent.CountDownLatch;

import android.support.v7.app.ActionBarActivity;
import android.content.Context;
import android.os.Bundle;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.TextView;

public class MainActivity extends ActionBarActivity implements OnClickListener {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		setListeners();
	}

	private void setListeners() {

		Button robo1 = (Button) this.findViewById(R.id.robo1);
		robo1.setOnClickListener(this);
		Button robo2 = (Button) this.findViewById(R.id.robo2);
		robo2.setOnClickListener(this);
		Button robo3 = (Button) this.findViewById(R.id.robo3);
		robo3.setOnClickListener(this);
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

	public void onClick(View v) {
		int id = v.getId();
		switch (id) {
		case R.id.robo1:
			showPopup("Robo 1", "The first robo is the oldest one.");
			break;
		case R.id.robo2:
			showPopup("Robo 2", "The second robo is the best dancer.");
			break;
		case R.id.robo3:
			showPopup("Robo 3", "The third robo is the most popular one.");
			break;

		default:
			showPopup("Error", "I don't know what you clicked, but it wasn't a robo.");
			break;
		}
	}

	private PopupWindow pwindo;

	private void showPopup(String topic, String detail) {
		try {
			// We need to get the instance of the LayoutInflater

			LayoutInflater inflater = (LayoutInflater) this
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			LinearLayout layout = (LinearLayout) inflater.inflate(
					R.layout.screen_popup,
					(ViewGroup) findViewById(R.id.popup_element));

			((TextView) layout.getChildAt(0)).setText(topic);
			((TextView) layout.getChildAt(1)).setText(detail);

			pwindo = new PopupWindow(layout, 200, 200, false);
			pwindo.showAtLocation(layout, Gravity.CENTER, 0, 0);
			
			new android.os.Handler().postDelayed(new Runnable() {
				public void run() {
					pwindo.dismiss();
					setListeners();
				}
			}, 3000);

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
