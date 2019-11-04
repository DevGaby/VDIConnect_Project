package com.myapp.vdiconnectapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class SignInActivity extends AppCompatActivity {
    private Button signUp;
    private Button submit;
    private Button button_login_login;
    private EditText editText_login_username;
    private EditText editText_login_password;
    private String username;
    private String password;
    private String baseUrl;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_in);

        baseUrl = "http://localhost:44368/";
        this.submit = (Button) findViewById(R.id.submit);
        this.signUp = (Button) findViewById(R.id.signUp) ;
        this.editText_login_username = (EditText) findViewById(R.id.mail);
        this.editText_login_password = (EditText) findViewById(R.id.password);

        submit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                int duration = Toast.LENGTH_SHORT;
                Toast.makeText(getApplicationContext(),"En cours de developpement", duration).show();
                /*try {

                    username = editText_login_username.getText().toString();
                    password = editText_login_password.getText().toString();

                    ApiAuthenticationClient apiAuthenticationClient =
                            new ApiAuthenticationClient(
                                    baseUrl
                                    , username
                                    , password
                            );

                    AsyncTask<Void, Void, String> execute = new ExecuteNetworkOperation(apiAuthenticationClient);
                    execute.execute();
                } catch (Exception ex) {
                }
            */}
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

    /*public class ExecuteNetworkOperation extends AsyncTask<Void, Void, String> {

        private ApiAuthenticationClient apiAuthenticationClient;
        private String isValidCredentials;

        *//**
         * Overload the constructor to pass objects to this class.
         *//*
        public ExecuteNetworkOperation(ApiAuthenticationClient apiAuthenticationClient) {
            this.apiAuthenticationClient = apiAuthenticationClient;
        }

        @Override
        protected void onPreExecute() {
            super.onPreExecute();

            // Display the progress bar.
            findViewById(R.id.loadingPanel).setVisibility(View.VISIBLE);
        }

        @Override
        protected String doInBackground(Void... params) {
            try {
                isValidCredentials = apiAuthenticationClient.execute();
            } catch (Exception e) {
                e.printStackTrace();
            }

            return null;
        }

        @Override
        protected void onPostExecute(String result) {
            super.onPostExecute(result);

            // Hide the progress bar.
            findViewById(R.id.loadingPanel).setVisibility(View.GONE);

            // Login Success
            if (isValidCredentials.equals("true")) {
                goToSecondActivity();
            }
            // Login Failure
            else {
                Toast.makeText(getApplicationContext(), "Login Failed", Toast.LENGTH_LONG).show();
            }
        }
    }

    *//**
     * Open a new activity window.
     *//*
    private void goToSecondActivity() {
        Bundle bundle = new Bundle();
        bundle.putString("username", username);
        bundle.putString("password", password);
        bundle.putString("baseUrl", baseUrl);

        Intent intent = new Intent(this, ListEventActivity.class);
        intent.putExtras(bundle);
        startActivity(intent);
    }
*/
}
