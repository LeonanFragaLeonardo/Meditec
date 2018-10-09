/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package org.netbeans.rest.application.config;

import java.util.Set;
import javax.ws.rs.core.Application;

/**
 *
 * @author otica
 */
@javax.ws.rs.ApplicationPath("webresources")
public class ApplicationConfig extends Application {

    @Override
    public Set<Class<?>> getClasses() {
        Set<Class<?>> resources = new java.util.HashSet<>();
        addRestResourceClasses(resources);
        return resources;
    }

    /**
     * Do not modify addRestResourceClasses() method.
     * It is automatically populated with
     * all resources defined in the project.
     * If required, comment out calling this method in getClasses().
     */
    private void addRestResourceClasses(Set<Class<?>> resources) {
        resources.add(br.edu.utfpr.md.meditec.ws.services.AgendaFacadeREST.class);
        resources.add(br.edu.utfpr.md.meditec.ws.services.EventFacadeREST.class);
        resources.add(br.edu.utfpr.md.meditec.ws.services.SocialNetworkFacadeREST.class);
        resources.add(br.edu.utfpr.md.meditec.ws.services.TrainerContactFacadeREST.class);
        resources.add(br.edu.utfpr.md.meditec.ws.services.TrainerFacadeREST.class);
    }
    
}
