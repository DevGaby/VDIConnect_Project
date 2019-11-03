package com.myapp.vdiconnectapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                Intent otherActivity = new Intent(MainActivity.this, HomeOneActivity.class);
                startActivity(otherActivity);
                finish();
            }
        }, 3000);

        //Connexion img
       /*
       private ImageView logo;
       this.logo = (ImageView) findViewById(R.id.logo);
        logo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent otherActivity = new Intent(getApplicationContext(), HomeActivity.class);
                startActivity(otherActivity);
                finish();*//*
            }
        });*/


    }
}
