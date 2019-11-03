package com.myapp.vdiconnectapp;

import android.media.Image;
import android.widget.Button;

public class Event {
    private int color;
    private String pseudo;
    private String label;
    private Image illustration;
    private String description;
    private Button participed;

    public Event(int color, String pseudo, String label, String description){
        this.color = color;
        this.pseudo = pseudo;
        this.label = label;
        // this.illustration = illustration;
        this.description = description;
        this.participed = participed;
    }

    public int getColor() {
        return color;
    }

    public void setColor(int color) {
        this.color = color;
    }

    public String getPseudo() {
        return pseudo;
    }

    public void setPseudo(String pseudo) {
        this.pseudo = pseudo;
    }

    public String getLabel() {
        return label;
    }

    public void setLabel(String label) {
        this.label = label;
    }

    /*public Image getImage() {
        return illustration;
    }

    public void setImage(Image illustration) {
        this.illustration = illustration;
    }*/

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public  Button getParticiped(){ return participed;}

    public void setParticiped (Button description) { this.participed = participed;}
}
