/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.rgrgec.pppk_javaproject;

import dataExport.*;
import dbHandler.dbHandler;
import java.nio.file.Paths;
import java.sql.SQLException;

/**
 *
 * @author rokgr
 */
public class main {
    public static dbHandler dh = dbHandler.getInstance();
    public static final String DATA_DIRECTORY_PATH = Paths.get(System.getProperty("user.dir"),"DATA").toString();
    public static void main(String[] args) throws SQLException {
        // vozila/vozaci from CSV to database 
        toCSV cdh = new toCSV();
        System.out.println("Importing drivers..");
        int n = cdh.importDriver(Paths.get(DATA_DIRECTORY_PATH,"drivers.csv").toString());
        
        System.out.println("Uvoz vozila..");
        n = cdh.importVehicle(Paths.get(DATA_DIRECTORY_PATH,"vehicles.csv").toString());
        System.out.println("Broj uvezenih vozila: " + n);
        
        // rute Import/export to XML
        toXML xdh = new toXML();
        System.out.println("Route importing..");
        n = xdh.importRoute(Paths.get(DATA_DIRECTORY_PATH,"route.xml").toString());
        System.out.println("Broj uvezenih ruta: " + n);
        
        System.out.println("Route exporting..");
        n = xdh.exportRoute(1,DATA_DIRECTORY_PATH,"EXPORT_route.xml");
        System.out.println("Broj izvezenih ruta: " + n);
    
        System.out.println("Generiranje PDF-a");
        toPDF pdh = new toPDF();
        pdh.generateTravelWarrantPdf(1,DATA_DIRECTORY_PATH,"TravelWarrantPDF.pdf");
        System.out.println("PDF generiran..");
    }
}
