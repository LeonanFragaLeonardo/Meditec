/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.edu.utfpr.md.meditec.ws.entities;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Embeddable;

/**
 *
 * @author otica
 */
@Embeddable
public class TrainerContactPK implements Serializable {

    @Basic(optional = false)
    private int trainer;
    @Basic(optional = false)
    private int socialnetwork;

    public TrainerContactPK() {
    }

    public TrainerContactPK(int trainer, int socialnetwork) {
        this.trainer = trainer;
        this.socialnetwork = socialnetwork;
    }

    public int getTrainer() {
        return trainer;
    }

    public void setTrainer(int trainer) {
        this.trainer = trainer;
    }

    public int getSocialnetwork() {
        return socialnetwork;
    }

    public void setSocialnetwork(int socialnetwork) {
        this.socialnetwork = socialnetwork;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (int) trainer;
        hash += (int) socialnetwork;
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof TrainerContactPK)) {
            return false;
        }
        TrainerContactPK other = (TrainerContactPK) object;
        if (this.trainer != other.trainer) {
            return false;
        }
        if (this.socialnetwork != other.socialnetwork) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.edu.utfpr.md.meditec.ws.entities.TrainerContactPK[ trainer=" + trainer + ", socialnetwork=" + socialnetwork + " ]";
    }
    
}
