/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.edu.utfpr.md.meditec.ws.services;

import br.edu.utfpr.md.meditec.ws.entities.TrainerContact;
import br.edu.utfpr.md.meditec.ws.entities.TrainerContactPK;
import java.util.List;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.PathSegment;

/**
 *
 * @author otica
 */
@Stateless
@Path("trainercontact")
public class TrainerContactFacadeREST extends AbstractFacade<TrainerContact> {

    @PersistenceContext(unitName = "MeditecWSPU")
    private EntityManager em;

    private TrainerContactPK getPrimaryKey(PathSegment pathSegment) {
        /*
         * pathSemgent represents a URI path segment and any associated matrix parameters.
         * URI path part is supposed to be in form of 'somePath;trainer=trainerValue;socialnetwork=socialnetworkValue'.
         * Here 'somePath' is a result of getPath() method invocation and
         * it is ignored in the following code.
         * Matrix parameters are used as field names to build a primary key instance.
         */
        br.edu.utfpr.md.meditec.ws.entities.TrainerContactPK key = new br.edu.utfpr.md.meditec.ws.entities.TrainerContactPK();
        javax.ws.rs.core.MultivaluedMap<String, String> map = pathSegment.getMatrixParameters();
        java.util.List<String> trainer = map.get("trainer");
        if (trainer != null && !trainer.isEmpty()) {
            key.setTrainer(new java.lang.Integer(trainer.get(0)));
        }
        java.util.List<String> socialnetwork = map.get("socialnetwork");
        if (socialnetwork != null && !socialnetwork.isEmpty()) {
            key.setSocialnetwork(new java.lang.Integer(socialnetwork.get(0)));
        }
        return key;
    }

    public TrainerContactFacadeREST() {
        super(TrainerContact.class);
    }

    /*
    @POST
    @Override
    @Consumes({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
    public void create(TrainerContact entity) {
        super.create(entity);
    }

    @PUT
    @Path("{id}")
    @Consumes({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
    public void edit(@PathParam("id") PathSegment id, TrainerContact entity) {
        super.edit(entity);
    }

    @DELETE
    @Path("{id}")
    public void remove(@PathParam("id") PathSegment id) {
        br.edu.utfpr.md.meditec.ws.entities.TrainerContactPK key = getPrimaryKey(id);
        super.remove(super.find(key));
    }

    @GET
    @Path("{id}")
    @Produces({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
    public TrainerContact find(@PathParam("id") PathSegment id) {
        br.edu.utfpr.md.meditec.ws.entities.TrainerContactPK key = getPrimaryKey(id);
        return super.find(key);
    }

    @GET
    @Override
    @Produces({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
    public List<TrainerContact> findAll() {
        return super.findAll();
    }

    @GET
    @Path("{from}/{to}")
    @Produces({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
    public List<TrainerContact> findRange(@PathParam("from") Integer from, @PathParam("to") Integer to) {
        return super.findRange(new int[]{from, to});
    }

    @GET
    @Path("count")
    @Produces(MediaType.TEXT_PLAIN)
    public String countREST() {
        return String.valueOf(super.count());
    }*/

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }
    
}
