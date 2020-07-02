/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dataExport;


import com.itextpdf.kernel.pdf.PdfDocument;
import com.itextpdf.kernel.pdf.PdfWriter;
import com.itextpdf.layout.Document;
import com.itextpdf.layout.element.Paragraph;
import java.io.FileNotFoundException;
import java.nio.file.Paths;
import java.sql.Date;
import javax.persistence.ParameterMode;
import javax.persistence.StoredProcedureQuery;
import constructors.*;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
/**
 *
 * @author rokgr
 */
public class toPDF {
    private String path;
    private String fname;
    public void generateTravelWarrantPdf(int id, String path, String fname) {
        Configuration cfg = createHibernateConfiguration();
        this.path = path;
        this.fname = fname;
        try(SessionFactory sessionFactory = cfg.buildSessionFactory();
                Session session = sessionFactory.openSession()){
            session.beginTransaction();
            StoredProcedureQuery spq = session.createStoredProcedureCall("select_travelwarrant");
            spq.registerStoredProcedureParameter("id", int.class, ParameterMode.IN);
            spq.setParameter("id", id);
            spq.execute();
            Object[] result = (Object[]) spq.getResultList().get(0);
            String DateCreated = ((Date)result[1]).toString();
            String StartingDate = ((Date)result[2]).toString();
            String EndingDate = ((Date)result[3]).toString();
            String StatusType = (String) result[7];
            String Name = (String) result[8];
            String Surname = (String) result[9];
            String VehicleType = (String) result[10];
            String VehicleBrand = (String) result[11];
            String ProductionYear = ((Date)result[12]).toString();
            
            TravelWarrant_pdf pfp = new TravelWarrant_pdf(DateCreated, StartingDate, EndingDate, Name, Surname, VehicleType, VehicleBrand, ProductionYear, StatusType);
            
            writeToPdf(pfp);
            
            session.getTransaction().commit();
        }catch(Exception ex){
            ex.printStackTrace();
        }
       
    }
    
    private void writeToPdf(TravelWarrant_pdf pfp) throws FileNotFoundException{
        String dest = Paths.get(this.path, this.fname).toString();
        PdfWriter writer = new PdfWriter(dest);
        PdfDocument pdf = new PdfDocument(writer);

        Document document = new Document(pdf);
        String para1 = String.format(
                "Date created: %s \n"
                + "Date of start: %s , Date of end: %s \n"
                + "DRIVER INFO\n"
                + "%s %s \n"
                + "VEHICLE INFO\n"
                + "%s %s \n"
                + "Production year: %s \n"
                + "Travel Warrant Status Type: %s",
                pfp.getDateCreated(),pfp.getStartingDate(),pfp.getEndingDate(),
                pfp.getName(),pfp.getSurname(),
                pfp.getVehicleType(),pfp.getVehicleBrand(),
                pfp.getProductionYear(),
                pfp.getStatus()
        );
        Paragraph paragraph1 = new Paragraph(para1);
        document.add(paragraph1);
        document.close();  
        
    }
    
    
    private Configuration createHibernateConfiguration() {
        String url = "jdbc:sqlserver://localhost\\DESKTOP-VKPMS9H:1433;databaseName=pppkDB;user=RokGrgec;password=test";
        Configuration cfg = new Configuration()
                .setProperty("hibernate.connection.driver_class", "com.microsoft.sqlserver.jdbc.SQLServerDriver")
                .setProperty("hibernate.connection.url", url)
                .setProperty("hibernate.connection.autocommit", "true")
                .setProperty("hibernate.show_sql", "false");

        // Tell Hibernate to use the 'SQL Server' dialect when dynamically
        // generating SQL queries
        cfg.setProperty("hibernate.dialect", "org.hibernate.dialect.SQLServerDialect");

        // Tell Hibernate to show the generated T-SQL
        cfg.setProperty("hibernate.show_sql", "false");

        
        cfg.setProperty("hibernate.hbm2ddl.auto", "update");
        return cfg;
    }
}
