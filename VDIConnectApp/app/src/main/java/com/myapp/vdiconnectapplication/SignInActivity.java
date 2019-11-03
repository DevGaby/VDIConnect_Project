package com.myapp.vdiconnectapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

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
                //controle email et password
                //appel a l'API
            }
        });
        signUp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent otherActivity = new Intent(getApplicationContext(), SignUpActivity.class);
                startActivity(otherActivity);
                finish();
            }
        });

    }
}
