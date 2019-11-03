package com.myapp.vdiconnectapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class SignInActivity extends AppCompatActivity {
    private TextView signUp;
    private Button submit;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_in);

        this.signUp = (TextView)findViewById(R.id.connect);
        this.submit = (Button) findViewById(R.id.submit) ;

        submit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                int duration = Toast.LENGTH_SHORT;
                Toast.makeText(getApplicationContext(),"En cours de developpement", duration).show();
                //controle email et password
                //appel a l'API
            }
        });
        signUp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent nextActivity = new Intent(getApplicationContext(), SignUpActivity.class);
                startActivity(nextActivity);
                finish();
            }
        });


    }
}
