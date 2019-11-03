package com.myapp.vdiconnectapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

public class HomeOneActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home_one);

        /*Demarrage de l'actiite suivante avec le timer*/
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                Intent discountActivity = new Intent(HomeOneActivity.this, HomeTwoActivity.class);
                startActivity(discountActivity);
                finish();
            }
        }, 3000);
    }
}
