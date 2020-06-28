/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package SourcePackages;

import DataBase.dbHandler;
import constructors.Driver;
import constructors.Vehicle;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

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
                int production_year = Integer.parseInt(data[2]);
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
                String Name =           data[0];
                String Surname =       data[1];
                String Phone_num = data[2];
                String Licence_num =  data[3];
                
                Driver d = new Driver(Name,Surname,Phone_num,Licence_num);
                db.InsertDriver(d);
                ++number;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }finally{
            return number;
        }
    }

    public int importVozaci(String toString) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    public int importVozila(String toString) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}
