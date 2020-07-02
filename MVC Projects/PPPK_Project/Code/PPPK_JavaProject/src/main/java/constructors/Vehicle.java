/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package constructors;

import java.sql.Date;

/**
 *
 * @author rokgr
 */
public class Vehicle {
    private int id;
    private String vehicletype;
    private String vehicleBrand;
    private Date productionYear;
    private int startingKm;
    private int currentKm;

    public void setId(int id) {
        this.id = id;
    }

    public void setVehicletype(String vehicletype) {
        this.vehicletype = vehicletype;
    }

    public void setVehicleBrand(String vehicleBrand) {
        this.vehicleBrand = vehicleBrand;
    }

    public void setProductionYear(Date productionYear) {
        this.productionYear = productionYear;
    }

    public void setStartingKm(int startingKm) {
        this.startingKm = startingKm;
    }

    public void setCurrentKm(int currentKm) {
        this.currentKm = currentKm;
    }

    public int getId() {
        return id;
    }

    public String getVehicletype() {
        return vehicletype;
    }

    public String getVehicleBrand() {
        return vehicleBrand;
    }

    public Date getProductionYear() {
        return productionYear;
    }

    public int getStartingKm() {
        return startingKm;
    }

    public int getCurrentKm() {
        return currentKm;
    }

    public Vehicle(String vehicletype, String vehicleBrand, Date productionYear, int startingKm, int currentKm) {
        this.vehicletype = vehicletype;
        this.vehicleBrand = vehicleBrand;
        this.productionYear = productionYear;
        this.startingKm = startingKm;
        this.currentKm = currentKm;
    }

    public Vehicle(int id, String vehicletype, String vehicleBrand, Date productionYear, int startingKm, int currentKm) {
        this.id = id;
        this.vehicletype = vehicletype;
        this.vehicleBrand = vehicleBrand;
        this.productionYear = productionYear;
        this.startingKm = startingKm;
        this.currentKm = currentKm;
    }
    
}
