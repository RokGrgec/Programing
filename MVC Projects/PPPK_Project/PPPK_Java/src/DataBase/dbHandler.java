/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DataBase;

import constructors.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author rokgr
 */
public class dbHandler {
    private static final String DEFAULT_JAVA_CLASS = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
    private final String PROJECT_DIRECTORY = System.getProperty("user.dir");
    private static final String URL_FORMAT = "jdbc:sqlserver://localhost\\DESKTOP-VKPMS9H:1433;databaseName=pppkDB;user=RokGrgec;password=test"; //CHANGE ME
    private static dbHandler instance = null;
    private static Connection connection = null;
    
    private dbHandler(String url) throws ClassNotFoundException{
        Class.forName(url);
    }
    
    public static dbHandler getInstance(){
        if(instance == null){
            try {
                instance = new dbHandler(DEFAULT_JAVA_CLASS);
            } catch (ClassNotFoundException ex) {
                Logger.getLogger(dbHandler.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        return instance;
    }
    
    public void ExecuteScript(String path){
        System.out.println("Executing script " + path);
        OpenConnection();
        String content = "";
        try {
            content = new String(Files.readAllBytes(Paths.get(path)));
        }catch (IOException ex) {
            Logger.getLogger(dbHandler.class.getName()).log(Level.SEVERE, null, ex);
        }
        for(String query : content.split(";")){
            ExecuteUpdate(query);
        }
        CloseConnection();
        System.out.println("Done");
    }
    
    public void ExecuteUpdate(String query){
        Statement statement = null;
        try {
            OpenConnection();
            statement = connection.createStatement();
            statement.executeUpdate(query);
        } catch (SQLException ex) {
            ex.printStackTrace();
        }finally{
            CloseConnection();
        }
    }

    public ResultSet ExecuteQuery(String query){
        Statement statement = null;
        ResultSet rs = null;
        try {
            OpenConnection();
            statement = connection.createStatement();
            rs = statement.executeQuery(query);
        } catch (SQLException ex) {
            System.out.println("The Error!");
        }finally{
            CloseConnection();
            return rs;
        }
    }
    
    private void OpenConnection(){
        try {
            connection = DriverManager.getConnection(URL_FORMAT);
        } catch (SQLException e) {
            CloseConnection();
            Logger.getLogger(dbHandler.class.getName()).log(Level.SEVERE, null, e);
        }
        
    }
    
    private void CloseConnection(){
        try{
            connection.close();
        }catch(SQLException e){ 
            Logger.getLogger(dbHandler.class.getName()).log(Level.SEVERE, null, e);
        }

    } 
    
    
    public void InsertDriver(Driver d){
        CallableStatement cstmt = null;
        ResultSet rs = null;
        try{
            OpenConnection();
            cstmt = connection.prepareCall("{call insert_driver(?,?,?,?)}");
            cstmt.setString("Name", d.getName());
            cstmt.setString("Surname", d.getSurname());
            cstmt.setString("PhoneNumber", d.getPhoneNum());
            cstmt.setString("DriverLicenceNumber", d.getLicenceNum());
            cstmt.execute();
        }catch(Exception ex){
            ex.printStackTrace();
        }finally{
            CloseConnection();
        }
    }
    
    public void InsertVehicle(Vehicle v){
        CallableStatement cstmt = null;
        try{
            OpenConnection();
            cstmt = connection.prepareCall("{call insert_vozilo(?,?,?,?,?)}");
            cstmt.setString("VehicleType", v.getVehicletype());
            cstmt.setString("VehicleBrand", v.getVehicleBrand());
            cstmt.setInt("ProductionYear", v.getProductionYear());
            cstmt.setInt("StartingKilometers", v.getStartingKm());
            cstmt.setInt("CurrentKilometers", v.getCurrentKm());
            cstmt.execute();
        }catch(SQLException ex){
            ex.printStackTrace();
        }finally{
            CloseConnection();
        }
    }

    public void InsertTravelRoute(TravelRoute r) {
        CallableStatement cstmt = null;
        try{
            OpenConnection();
            cstmt = connection.prepareCall("{call insert_travelroute(?,?,?,?,?,?,?)}");
            cstmt.setInt("IDTravelWarrant", r.getId_travelWarrant());
            cstmt.setDouble("x_cordinate_ofDeparture", r.getX_cordinate_ofDeparture());
            cstmt.setDouble("y_cordinate_ofDeparture", r.getY_cordinate_ofDeparture());
            cstmt.setDouble("x_cordinate_ofArrival", r.getX_cordinate_ofArrival());
            cstmt.setDouble("y_cordinate_ofArrival", r.getY_cordinate_ofArrival());
            cstmt.setDouble("TotalTravelDistance", r.getTotalTravelDistance());
            cstmt.setDouble("AverageSpeed", r.getAverageSpeed());
            cstmt.execute();
        }catch (SQLException ex){
            ex.printStackTrace();
        }finally{
            CloseConnection();
        }
        
    }

    public ArrayList<TravelRoute> SelectRute(int travel_warrant_id) {
        ArrayList<TravelRoute> l = new ArrayList<TravelRoute>();
        ResultSet rs = null;
        Statement statement = null;
        try {
            OpenConnection();
            statement = connection.createStatement();
            rs = statement.executeQuery("SELECT * FROM TravelRoute WHERE IDTravelWarrant=" + travel_warrant_id);
            while(rs.next()){
                TravelRoute r = new TravelRoute(
                        rs.getInt("TravelRouteID"),
                        rs.getDouble("AverageSpeed"),
                        rs.getDouble("x_cordinate_ofDeparture"),
                        rs.getDouble("y_cordinate_ofDeparture"),
                        rs.getDouble("x_cordinate_ofArrival"),
                        rs.getDouble("y_cordinate_ofArrival"),
                        rs.getDouble("TotalTravelDistance"),
                        rs.getInt("IDTravelWarrant")
                );
                l.add(r);
            }
        } catch (SQLException ex) {
            Logger.getLogger(dbHandler.class.getName()).log(Level.SEVERE, null, ex);
        }finally{
            CloseConnection();
        }
        return l;
    }
}
