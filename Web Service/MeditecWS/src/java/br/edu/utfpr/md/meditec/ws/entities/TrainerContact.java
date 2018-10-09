/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.edu.utfpr.md.meditec.ws.entities;

import java.io.Serializable;
import javax.json.bind.annotation.JsonbTransient;
import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author otica
 */
@Entity
@Table(name = "trainer_contact")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "TrainerContact.findAll", query = "SELECT t FROM TrainerContact t")
    , @NamedQuery(name = "TrainerContact.findByTrainer", query = "SELECT t FROM TrainerContact t WHERE t.trainerContactPK.trainer = :trainer")
    , @NamedQuery(name = "TrainerContact.findBySocialnetwork", query = "SELECT t FROM TrainerContact t WHERE t.trainerContactPK.socialnetwork = :socialnetwork")
    , @NamedQuery(name = "TrainerContact.findByLink", query = "SELECT t FROM TrainerContact t WHERE t.link = :link")})
public class TrainerContact implements Serializable {

    private static final long serialVersionUID = 1L;
    @EmbeddedId
    protected TrainerContactPK trainerContactPK;
    private String link;
    @JoinColumn(name = "socialnetwork", referencedColumnName = "id", insertable = false, updatable = false)
    @ManyToOne(optional = false)
    private SocialNetwork socialNetwork;
    @JoinColumn(name = "trainer", referencedColumnName = "id", insertable = false, updatable = false)
    @ManyToOne(optional = false)
    @JsonbTransient
    private Trainer trainer1;

    public TrainerContact() {
    }

    public TrainerContact(TrainerContactPK trainerContactPK) {
        this.trainerContactPK = trainerContactPK;
    }

    public TrainerContact(int trainer, int socialnetwork) {
        this.trainerContactPK = new TrainerContactPK(trainer, socialnetwork);
    }

    public TrainerContactPK getTrainerContactPK() {
        return trainerContactPK;
    }

    public void setTrainerContactPK(TrainerContactPK trainerContactPK) {
        this.trainerContactPK = trainerContactPK;
    }

    public String getLink() {
        return link;
    }

    public void setLink(String link) {
        this.link = link;
    }

    public SocialNetwork getSocialNetwork() {
        return socialNetwork;
    }

    public void setSocialNetwork(SocialNetwork socialNetwork) {
        this.socialNetwork = socialNetwork;
    }

    public Trainer getTrainer1() {
        return trainer1;
    }

    public void setTrainer1(Trainer trainer1) {
        this.trainer1 = trainer1;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (trainerContactPK != null ? trainerContactPK.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof TrainerContact)) {
            return false;
        }
        TrainerContact other = (TrainerContact) object;
        if ((this.trainerContactPK == null && other.trainerContactPK != null) || (this.trainerContactPK != null && !this.trainerContactPK.equals(other.trainerContactPK))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.edu.utfpr.md.meditec.ws.entities.TrainerContact[ trainerContactPK=" + trainerContactPK + " ]";
    }
    
}
