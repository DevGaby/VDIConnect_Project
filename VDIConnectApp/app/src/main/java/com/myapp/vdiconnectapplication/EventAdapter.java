package com.myapp.vdiconnectapplication;

import android.content.Context;
import android.content.Intent;
import android.database.DataSetObserver;
import android.graphics.drawable.ColorDrawable;
import android.net.Uri;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ListAdapter;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;


/*class EventAdapter implements ListAdapter {
    ArrayList<Event> arrayList;
    Context context;

    public EventAdapter(Context context, ArrayList<Event> arrayList){
        this.arrayList=arrayList;
        this.context=context;
    }

    @Override
    public boolean areAllItemsEnabled() {
        return false;
    }

    @Override
    public boolean isEnabled(int position) {
        return true;
    }

    @Override
    public void registerDataSetObserver(DataSetObserver observer) {

    }

    @Override
    public void unregisterDataSetObserver(DataSetObserver observer) {

    }

    @Override
    public int getCount() {
        return arrayList.size();
    }

    @Override
    public Object getItem(int position) {
        return position;
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public boolean hasStableIds() {
        return false;
    }

    public View getView(int position, View convertView, ViewGroup parent) {
        final Event subjectData=arrayList.get(position);
        if(convertView==null){
            LayoutInflater layoutInflater = LayoutInflater.from(context);
            convertView=layoutInflater.inflate(R.layout.row_event, null);
            convertView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent i = new Intent(Intent.ACTION_VIEW);
                   // i.setData(Uri.parse(subjectData.Link));
                    context.startActivity(i);
                    Toast.makeText(context,"selection ok",Toast.LENGTH_LONG).show();
                }
            });


            *//*TextView tittle = convertView.findViewById(R.id.title);
            //ImageView imag = convertView.findViewById(R.id.list_image);
            tittle.setText(Event.class);
            Picasso.with(context)
                    .load(subjectData.Image)
                    .into(imag);*//*


        }
        return convertView;
    }

    @Override
    public int getItemViewType(int position) {
        return position;
    }

    @Override
    public int getViewTypeCount() {
        return arrayList.size();
    }


    @Override
    public boolean isEmpty() {
        return false;
    }
}*/

public class EventAdapter extends ArrayAdapter<Event> {
    private class EventViewholder{
        public TextView pseudo;
        public TextView label;
        public ImageView avatar;
        public TextView description;
        public String str = "Participation OK";
    }

    public EventAdapter(Context context, List<Event> events){
        super(context, 0, events);//Events est la liste des models à afficher
    }

    //convertView est notre vue recyclée
    @Override
    public View getView(int position, View convertView, ViewGroup parent){
        //Android nous fournit un convertView null lorsqu'il nous demande de la créer
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

        return convertView;
    }
}

