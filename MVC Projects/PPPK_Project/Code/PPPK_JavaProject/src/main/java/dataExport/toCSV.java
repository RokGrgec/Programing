/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dataExport;

import dbHandler.dbHandler;
import constructors.Driver;
import constructors.Vehicle;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.sql.Date;
import java.text.SimpleDateFormat;

/**
 *
 * @author rokgr
 */
public class toCSV {
    private static dbHandler db = dbHandler.getInstance();
    public int importVehicle(String filename){
        String line = "";
        String cvsSplitBy = ",";
        int number = 0;
        try (BufferedReader br = new BufferedReader(new FileReader(filename))) {
            while ((line = br.readLine()) != null) {
                String[] data = line.split(cvsSplitBy);
                String type = data[0];
                String brand = data[1];
                SimpleDateFormat format = new SimpleDateFormat("MM/dd/yyyy");
                Date production_year = (Date) format.parse("01/01/1998");
                int starting_km = Integer.parseInt(data[3]);
                int current_km = Integer.parseInt(data[4]);
                
                
                Vehicle v = new Vehicle(type,brand,production_year,current_km,starting_km);
                db.InsertVehicle(v);
                ++number;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }finally{
            return number;
        }
    }
    
    public int importDriver(String filename){
        String line = "";
        String cvsSplitBy = ",";
        int number = 0;
        try (BufferedReader br = new BufferedReader(new FileReader(filename))) {
            while ((line = br.readLine()) != null) {
                String[] data = line.split(cvsSplitBy);
                String fname =           data[0];
                String lastname =       data[1];
                String phonenum = data[2];
                String driverlicensenum =  data[3];
                
                Driver d = new Driver(fname,lastname,phonenum,driverlicensenum);
                db.InsertDriver(d);
                ++number;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }finally{
            return number;
        }
    }

    public int importDrivers(String toString) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    public int importVehicles(String toString) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}
