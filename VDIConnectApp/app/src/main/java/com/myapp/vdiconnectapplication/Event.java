package com.myapp.vdiconnectapplication;

import android.media.Image;

public class Event {
    private int color;
    private String pseudo;
    private String label;
    private Image illustration;
    private String description;

    public Event(int color, String pseudo, String label, String description){
        this.color = color;
        this.pseudo = pseudo;
        this.label = label;
       // this.illustration = illustration;
        this.description = description;
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
}
