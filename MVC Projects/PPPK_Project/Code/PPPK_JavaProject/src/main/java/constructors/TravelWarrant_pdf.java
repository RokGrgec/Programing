/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package constructors;

/**
 *
 * @author rokgr
 */
public class TravelWarrant_pdf {

    public TravelWarrant_pdf(String dateCreated, String startingDate, String endingDate, String name, String surname, String vehicleType, String vehicleBrand, String productionYear, String status) {
        this.dateCreated = dateCreated;
        this.startingDate = startingDate;
        this.endingDate = endingDate;
        this.name = name;
        this.surname = surname;
        this.vehicleType = vehicleType;
        this.vehicleBrand = vehicleBrand;
        this.status = status;
        this.productionYear = productionYear;
    }

    public String getDateCreated() {
        return dateCreated;
    }

    public String getStartingDate() {
        return startingDate;
    }

    public String getEndingDate() {
        return endingDate;
    }

    public String getStatus() {
        return status;
    }

    public String getName() {
        return name;
    }

    public String getSurname() {
        return surname;
    }

    public String getVehicleBrand() {
        return vehicleBrand;
    }

    public String getVehicleType() {
        return vehicleType;
    }
    
    public String getProductionYear() {
        return productionYear;
    }
    private String dateCreated;
    private String startingDate;
    private String endingDate;
    private String status;
    private String name;
    private String surname;
    private String vehicleBrand;
    private String vehicleType;
    private String productionYear;

    public void setDateCreated(String dateCreated) {
        this.dateCreated = dateCreated;
    }

    public void setStartingDate(String startingDate) {
        this.startingDate = startingDate;
    }

    public void setEndingDate(String endingDate) {
        this.endingDate = endingDate;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public void setVehicleBrand(String vehicleBrand) {
        this.vehicleBrand = vehicleBrand;
    }

    public void setProductionYear(String productionYear) {
        this.productionYear = productionYear;
    }
}