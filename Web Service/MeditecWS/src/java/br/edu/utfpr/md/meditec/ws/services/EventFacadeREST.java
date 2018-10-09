/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.edu.utfpr.md.meditec.ws.services;

import br.edu.utfpr.md.meditec.ws.entities.Event;
import java.util.List;
import java.util.stream.Collectors;
import javax.ejb.Stateless;
import javax.json.bind.annotation.JsonbCreator;
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

/**
 *
 * @author otica
 */
@Stateless
@Path("/event")
public class EventFacadeREST extends AbstractFacade<Event> {

    @PersistenceContext(unitName = "MeditecWSPU")
    private EntityManager em;

    public EventFacadeREST() {
        super(Event.class);
    }

    /*
    @POST
    @Override
    @Consumes({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
    public void create(Event entity) {
        super.create(entity);
    }

    @PUT
    @Path("{id}")
    @Consumes(MediaType.APPLICATION_JSON)
    public void edit(@PathParam("id") Integer id, Event entity) {
        super.edit(entity);
    }

    @DELETE
    @Path("{id}")
    public void remove(@PathParam("id") Integer id) {
        super.remove(super.find(id));
    }

    @GET
    @Path("{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Event find(@PathParam("id") Integer id) {
        
        return super.find(id);
    }
    */
    @GET
    @Path("/type={type}")
    @Produces(MediaType.APPLICATION_JSON)
    public List<Event> findAllByType(@PathParam("type") Integer type){
        List<Event> events = super.findAll();
        return events.stream()
            .filter(e -> e.getType() == type).collect(Collectors.toList());   
    }
    
    @GET
    @Override
    @Produces(MediaType.APPLICATION_JSON)
    public List<Event> findAll() {
        //Gson g = new GsonBuilder().setDateFormat("yyyy-MM-dd'T'HH:mm:ss").create();
        return super.findAll();
    }

    /*
    @GET
    @Path("{from}/{to}")
    @Produces({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
    public List<Event> findRange(@PathParam("from") Integer from, @PathParam("to") Integer to) {
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
