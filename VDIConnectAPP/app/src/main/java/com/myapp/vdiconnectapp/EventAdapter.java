package com.myapp.vdiconnectapp;

import android.content.Context;
import android.content.Intent;
import android.graphics.drawable.ColorDrawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.List;

public class EventAdapter extends ArrayAdapter<Event> {
    private Button participed;

    private class EventViewholder{
        public TextView pseudo;
        public TextView label;
        public ImageView avatar;
        public TextView description;
        public Button participed;
    }

    public EventAdapter(Context context, List<Event> events){
        super(context, 0, events);//Events est la liste des models à afficher
    }

    //convertView est notre vue recyclée
    @Override
    public View getView(int position, View convertView, ViewGroup parent){
        //Android fournit un convertView null lorsqu'il nous demande de la créer
        //dans le cas contraire, cela veux dire qu'il nous fournit une vue recyclée
        if(convertView == null){
            //Nous récupérons notre row_event via un LayoutInflater,
            //qui va charger un layout xml dans un objet View
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.row_event, parent, false);
        }

        EventViewholder viewHolder = (EventViewholder) convertView.getTag();
        //comme nos vues sont réutilisées, notre cellule possède déjà un ViewHolder
        if(viewHolder == null){
            //si elle n'avait pas encore de ViewHolder
            viewHolder = new EventViewholder();
            viewHolder.pseudo = (TextView) convertView.findViewById(R.id.pseudo);
            viewHolder.label = (TextView) convertView.findViewById(R.id.label);
            viewHolder.avatar = (ImageView) convertView.findViewById(R.id.avatar);
            viewHolder.description = (TextView) convertView.findViewById(R.id.description);
            viewHolder.participed = (Button) convertView.findViewById(R.id.goIn);

            //puis on sauvegarde le mini-controlleur dans la vue
            convertView.setTag(viewHolder);
        }

        //getItem(position) va récupérer l'item [position] de la List<Event> events
        Event event = getItem(position);

        //Remplissage de la vue
        viewHolder.pseudo.setText(event.getPseudo());
        viewHolder.label.setText(event.getLabel());
        viewHolder.avatar.setImageDrawable(new ColorDrawable(event.getColor()));
        viewHolder.description.setText(event.getDescription());
        viewHolder.participed.setOnClickListener(openSignIn);

//        viewHolder.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                int duration = Toast.LENGTH_SHORT;
//                Toast.makeText(getApplicationContext(),"En cours de developpement", duration).show();
//
//
//    });

         /*public void onClick(View view) {
         Intent otherActivity = new Intent(getApplicationContext(),SignInActivity.class);
         startActivity(otherActivity);
        finish();
         }
        })*/
        return convertView;
    }
    private View.OnClickListener openSignIn = new View.OnClickListener() {
        public void onClick(View v) {
            Intent otherActivity = new Intent(getContext(), SignInActivity.class);
            otherActivity.putExtras(otherActivity);
        }
    };

}
