package com.myapp.vdiconnectapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

public class HomeTwoActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home_two);

        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                Intent dailyActivity = new Intent(HomeTwoActivity.this, HomeThreeActivity.class);
                startActivity(dailyActivity);
                finish();
            }
        },3000);
    }
}
