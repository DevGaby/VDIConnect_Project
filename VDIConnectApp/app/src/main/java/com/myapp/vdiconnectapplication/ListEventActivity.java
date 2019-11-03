package com.myapp.vdiconnectapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class ListEventActivity extends AppCompatActivity {
    private ListView listView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_event);

        listView = findViewById(R.id.ListEventView);
        List<Event> events = genererEvents();

        EventAdapter adapter = new EventAdapter(ListEventActivity.this, events);
        listView.setAdapter(adapter);
    }


    private List<Event> genererEvents(){
        List<Event> events = new ArrayList<>();
        events.add(new Event(Color.BLACK, "Florent", "Atelier bien-etre","Blabla blabla bla"));
        events.add(new Event(Color.BLUE, "Kevin", "Atelier Mode","Blabla blabla bla"));
        events.add(new Event(Color.GREEN, "Logan", "Atelier bio","Blabla blabla bla"));
        events.add(new Event(Color.RED, "Mathieu", "Atelier gastronomie","Blabla blabla bla"));
        events.add(new Event(Color.GRAY, "Willy", "Atelier coquin","Blabla blabla bla"));
        return events;
    }

}
