package com.myapp.vdiconnectapp;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Color;
import android.os.Bundle;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

public class ListEventActivity extends AppCompatActivity {
    private ListView listView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_event);

        listView = (ListView) findViewById(R.id.ListEventView);

        List<Event> events = generateEvents();
        EventAdapter adapter = new EventAdapter(ListEventActivity.this, events);
        listView.setAdapter(adapter);
    }

    private List<Event> generateEvents(){
        List <Event> events = new ArrayList<>();
        events.add(new Event(Color.BLACK, "Florent", "Atelier bien-etre","Blabla blabla bla"));
        events.add(new Event(Color.BLUE, "Kevin", "Atelier Mode","Blabla blabla bla"));
        events.add(new Event(Color.GREEN, "Logan", "Atelier bio","Blabla blabla bla"));
        events.add(new Event(Color.RED, "Mathieu", "Atelier gastronomie","Blabla blabla bla"));
        events.add(new Event(Color.GRAY, "Willy", "Atelier coquin","Blabla blabla bla"));
        return events;
    }
}
