/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pppk_java;

import SourcePackages.toXML;
import DataBase.dbHandler;
import SourcePackages.toCSV;
import SourcePackages.toPDF;
import java.nio.file.Paths;
import java.sql.SQLException;

/**
 *
 * @author rokgr
 */
public class PPPK_Java {

    /**
     * @param args the command line arguments
     */
    public static dbHandler dh = dbHandler.getInstance();
    public static final String DATA_DIRECTORY_PATH = Paths.get(System.getProperty("user.dir"),"DATA").toString();
    
    public static void main(String[] args) {
        // TODO code application logic here
        // vozila/vozaci from CSV to database 
        toCSV cdh = new toCSV();
        System.out.println("Uvoz vozaca..");
        int n = cdh.importVozaci(Paths.get(DATA_DIRECTORY_PATH,"vozaci.csv").toString());
        System.out.println("Broj uvezenih vozaca: " + n);
        
        System.out.println("Uvoz vozila..");
        n = cdh.importVozila(Paths.get(DATA_DIRECTORY_PATH,"vozila.csv").toString());
        System.out.println("Broj uvezenih vozila: " + n);
        
        // rute Import/export to XML
        toXML xdh = new toXML();
        System.out.println("Uvoz ruta..");
        n = xdh.importRute(Paths.get(DATA_DIRECTORY_PATH,"rute.xml").toString());
        System.out.println("Broj uvezenih ruta: " + n);
        
        System.out.println("Izvoz ruta..");
        n = xdh.exportRute(1,DATA_DIRECTORY_PATH,"EXPORT_rute.xml");
        System.out.println("Broj izvezenih ruta: " + n);
    
        System.out.println("Generiranje PDF-a");
        toPDF pdh = new toPDF();
        pdh.generateTravelWarrantPdf(1,DATA_DIRECTORY_PATH,"putni_nalog_1_report.pdf");
        System.out.println("PDF generiran..");
    }
    
}
