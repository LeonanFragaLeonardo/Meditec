/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.edu.utfpr.md.meditec.ws.services;

import br.edu.utfpr.md.meditec.ws.entities.Agenda;
import br.edu.utfpr.md.meditec.ws.entities.AgendaPK;
import br.edu.utfpr.md.meditec.ws.entities.Event;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.NamedQuery;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
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

@Path("/agenda")
public class AgendaFacadeREST extends AbstractFacade<Agenda> {

    @PersistenceContext(unitName = "MeditecWSPU")
    private EntityManager em;

    private AgendaPK getPrimaryKey(PathSegment pathSegment) {
        /*
         * pathSemgent represents a URI path segment and any associated matrix parameters.
         * URI path part is supposed to be in form of 'somePath;id=idValue;userid=useridValue'.
         * Here 'somePath' is a result of getPath() method invocation and
         * it is ignored in the following code.
         * Matrix parameters are used as field names to build a primary key instance.
         */
        br.edu.utfpr.md.meditec.ws.entities.AgendaPK key = new br.edu.utfpr.md.meditec.ws.entities.AgendaPK();
        javax.ws.rs.core.MultivaluedMap<String, String> map = pathSegment.getMatrixParameters();
        String id = pathSegment.getPath();
        java.util.List<String> userid = map.get("userid");
        if (userid != null && !userid.isEmpty()) {
            key.setUserid(userid.get(0));
        }
        key.setId(Integer.valueOf(id));
        return key;
    }

    
    public AgendaFacadeREST() {
        super(Agenda.class);
    }

    /*
    @POST
    @Override
    @Consumes({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
    public void create(Agenda entity) {
        super.create(entity);
    }

    @PUT
    @Path("{id}")
    @Consumes({MediaType.APPLICATION_XML, MediaType.APPLICATION_JSON})
    public void edit(@PathParam("id") PathSegment id, Agenda entity) {
        super.edit(entity);
    }*/

    /*
    @DELETE
    @Path("{id}")
    public void remove(@PathParam("id") PathSegment id) {
        br.edu.utfpr.md.meditec.ws.entities.AgendaPK key = getPrimaryKey(id);
        super.remove(super.find(key));
    }

    @GET
    @Path("{id}/{type}")
    @Produces(MediaType.APPLICATION_JSON)
    public Agenda find(@PathParam("id") PathSegment id, @PathParam("type") int type) {
        br.edu.utfpr.md.meditec.ws.entities.AgendaPK key = getPrimaryKey(id);
        Agenda agenda = super.find(key);
        List<Event> events = agenda.getEventList();
        List<Event> filteredEvents = events.stream()
            .filter(e -> e.getType() == type).collect(Collectors.toList());
        agenda.setEventList(filteredEvents);
        return super.find(key);
    }

    @GET
    @Override
    @Produces(MediaType.APPLICATION_JSON)
    public List<Agenda> findAll() {
        //TypedQuery<List<Agenda>> agendas = em.createQuery("SELECT a FROM Agenda a",  Agenda.class);
        //List<Agenda> agendas = super.findAll();
        //List<Agenda> filteredAgendas = new ArrayList<Agenda>();
        
        
        //for (Agenda a : agendas) {
            
        //    System.out.println(c.getName() + " => " + c.getCapital().getName());
        //}
        return super.findAll();
    }

    /*
    @GET
    @Path("{from}/{to}")
    @Produces(MediaType.APPLICATION_JSON)
    public List<Agenda> findRange(@PathParam("from") Integer from, @PathParam("to") Integer to) {
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
