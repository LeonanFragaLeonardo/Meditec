/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.edu.utfpr.md.meditec.ws.entities;

import java.io.Serializable;
import java.util.List;
import javax.json.bind.annotation.JsonbTransient;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author otica
 */
@Entity
@Table(name = "social_network")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "SocialNetwork.findAll", query = "SELECT s FROM SocialNetwork s")
    , @NamedQuery(name = "SocialNetwork.findById", query = "SELECT s FROM SocialNetwork s WHERE s.id = :id")
    , @NamedQuery(name = "SocialNetwork.findByTitle", query = "SELECT s FROM SocialNetwork s WHERE s.title = :title")
    , @NamedQuery(name = "SocialNetwork.findByIconCode", query = "SELECT s FROM SocialNetwork s WHERE s.iconCode = :iconCode")
    , @NamedQuery(name = "SocialNetwork.findByHtmlIcon", query = "SELECT s FROM SocialNetwork s WHERE s.htmlIcon = :htmlIcon")})
public class SocialNetwork implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    private Integer id;
    private String title;
    @Column(name = "icon_code")
    private String iconCode;
    @Column(name = "html_icon")
    private String htmlIcon;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "socialNetwork")
    @JsonbTransient
    private List<TrainerContact> trainerContactList;

    public SocialNetwork() {
    }

    public SocialNetwork(Integer id) {
        this.id = id;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getIconCode() {
        return iconCode;
    }

    public void setIconCode(String iconCode) {
        this.iconCode = iconCode;
    }

    public String getHtmlIcon() {
        return htmlIcon;
    }

    public void setHtmlIcon(String htmlIcon) {
        this.htmlIcon = htmlIcon;
    }

    @XmlTransient
    public List<TrainerContact> getTrainerContactList() {
        return trainerContactList;
    }

    public void setTrainerContactList(List<TrainerContact> trainerContactList) {
        this.trainerContactList = trainerContactList;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof SocialNetwork)) {
            return false;
        }
        SocialNetwork other = (SocialNetwork) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.edu.utfpr.md.meditec.ws.entities.SocialNetwork[ id=" + id + " ]";
    }
    
}
