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
public class TravelRoute {

    public TravelRoute(int id, double x_cordinate_ofDeparture, double y_cordinate_ofDeparture, double x_cordinate_ofArrival, double y_cordinate_ofArrival, double totalTravelDistance, double averageSpeed, int id_travelWarrant) {
        this.id = id;
        this.x_cordinate_ofDeparture = x_cordinate_ofDeparture;
        this.y_cordinate_ofDeparture = y_cordinate_ofDeparture;
        this.x_cordinate_ofArrival = x_cordinate_ofArrival;
        this.y_cordinate_ofArrival = y_cordinate_ofArrival;
        this.totalTravelDistance = totalTravelDistance;
        this.averageSpeed = averageSpeed;
        this.id_travelWarrant = id_travelWarrant;
    }

    public int getId() {
        return id;
    }

    public double getX_cordinate_ofDeparture() {
        return x_cordinate_ofDeparture;
    }

    public double getY_cordinate_ofDeparture() {
        return y_cordinate_ofDeparture;
    }

    public double getX_cordinate_ofArrival() {
        return x_cordinate_ofArrival;
    }

    public double getY_cordinate_ofArrival() {
        return y_cordinate_ofArrival;
    }

    public double getTotalTravelDistance() {
        return totalTravelDistance;
    }

    public double getAverageSpeed() {
        return averageSpeed;
    }

    public int getId_travelWarrant() {
        return id_travelWarrant;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setX_cordinate_ofDeparture(double x_cordinate_ofDeparture) {
        this.x_cordinate_ofDeparture = x_cordinate_ofDeparture;
    }

    public void setY_cordinate_ofDeparture(double y_cordinate_ofDeparture) {
        this.y_cordinate_ofDeparture = y_cordinate_ofDeparture;
    }

    public void setX_cordinate_ofArrival(double x_cordinate_ofArrival) {
        this.x_cordinate_ofArrival = x_cordinate_ofArrival;
    }

    public void setY_cordinate_ofArrival(double y_cordinate_ofArrival) {
        this.y_cordinate_ofArrival = y_cordinate_ofArrival;
    }

    public void setTotalTravelDistance(double totalTravelDistance) {
        this.totalTravelDistance = totalTravelDistance;
    }

    public void setAverageSpeed(double averageSpeed) {
        this.averageSpeed = averageSpeed;
    }

    public void setId_travelWarrant(int id_travelWarrant) {
        this.id_travelWarrant = id_travelWarrant;
    }

    public TravelRoute(double x_cordinate_ofDeparture, double y_cordinate_ofDeparture, double x_cordinate_ofArrival, double y_cordinate_ofArrival, double totalTravelDistance, double averageSpeed, int id_travelWarrant) {
        this.x_cordinate_ofDeparture = x_cordinate_ofDeparture;
        this.y_cordinate_ofDeparture = y_cordinate_ofDeparture;
        this.x_cordinate_ofArrival = x_cordinate_ofArrival;
        this.y_cordinate_ofArrival = y_cordinate_ofArrival;
        this.totalTravelDistance = totalTravelDistance;
        this.averageSpeed = averageSpeed;
        this.id_travelWarrant = id_travelWarrant;
    }

    private int id;
    private double x_cordinate_ofDeparture;
    private double y_cordinate_ofDeparture;
    private double x_cordinate_ofArrival;
    private double y_cordinate_ofArrival;
    private double totalTravelDistance;
    private double averageSpeed;
    private int id_travelWarrant;
}
