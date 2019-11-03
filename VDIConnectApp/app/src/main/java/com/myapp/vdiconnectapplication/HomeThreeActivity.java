package com.myapp.vdiconnectapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

public class HomeThreeActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home_three);

        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                Intent otherActivity = new Intent(HomeThreeActivity.this, ListEventActivity.class);
                startActivity(otherActivity);
                finish();
            }
        }, 3000);
    }
}
