/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dataExport;


import dbHandler.dbHandler;
import java.io.File;
import java.io.IOException;
import java.nio.file.Paths;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.w3c.dom.Document;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import constructors.TravelRoute;
import java.io.FileWriter;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
/**
 *
 * @author rokgr
 */
public class toXML {

    private static dbHandler db = dbHandler.getInstance();

    public int exportRoute(int travel_warrant_id,String path, String fname) {
        List<TravelRoute> l = db.SelectRute(travel_warrant_id);
        int n = 0;
        try {
            FileWriter fWriter = new FileWriter(Paths.get(path,fname).toFile());
            fWriter.append(String.format(
                    "<?xml version=\"1.0\"?>\n"
                    + "<travel_warrant id=\"%d\">\n"
                    ,travel_warrant_id));
            
            for(TravelRoute r : l){
                fWriter.append(
                    String.format(
                        "    <travel_route id=\"%d\">\n"
                        + "        <x_cordinate_ofDeparture>%f</x_cordinate_ofDeparture>\n"
                        + "        <y_cordinate_ofDeparture>%f</y_cordinate_ofDeparture>\n"
                        + "        <x_cordinate_ofArrival>%f</x_cordinate_ofArrival>\n"
                        + "        <y_cordinate_ofArrival>%f</y_cordinate_ofArrival>\n"
                        + "        <totalTravelDistance>%f</totalTravelDistance>\n"
                        + "        <averageSpeed>%f</averageSpeed>\n"
                        + "    </travel_route>\n",
                        r.getId(),r.getX_cordinate_ofDeparture(),
                        r.getY_cordinate_ofDeparture(),r.getX_cordinate_ofArrival(),
                        r.getY_cordinate_ofArrival(),r.getTotalTravelDistance(),r.getAverageSpeed()
                    )
                );
                ++n;
            }
            fWriter.append("</travel_warrant>\n");
            fWriter.close();
        } catch (IOException ex) {
            Logger.getLogger(toXML.class.getName()).log(Level.SEVERE, null, ex);
        }
        return n;
    }

    public int importRoute(String path) {
        try{
            File fXmlFile = new File(path);
            DocumentBuilder dBuilder = DocumentBuilderFactory.newInstance()
                             .newDocumentBuilder();

	    Document doc = dBuilder.parse(fXmlFile);
            doc.getDocumentElement().normalize();
            NodeList nList = doc.getElementsByTagName("travel_route");
            int temp = 0;
            for(; temp<nList.getLength(); ++temp){
                Node nNode = nList.item(temp);
                if (nNode.getNodeType() == Node.ELEMENT_NODE) {
                    Element eElement = (Element) nNode;
                    double x_cordinate_ofDeparture =   Double.parseDouble(eElement.getElementsByTagName("x_departure").item(0).getTextContent());
                    double y_departure =   Double.parseDouble(eElement.getElementsByTagName("y_departure").item(0).getTextContent());
                    double x_arrival =   Double.parseDouble(eElement.getElementsByTagName("x_arrival").item(0).getTextContent());
                    double y_arrival =   Double.parseDouble(eElement.getElementsByTagName("y_arrival").item(0).getTextContent());
                    double distance =    Double.parseDouble(eElement.getElementsByTagName("distance").item(0).getTextContent());
                    double speed = Double.parseDouble(eElement.getElementsByTagName("speed").item(0).getTextContent());
                    int IDtravelwarrant =      Integer.parseInt(eElement.getElementsByTagName("IDtravelwarrant").item(0).getTextContent());
                    TravelRoute r = new TravelRoute(
                            x_cordinate_ofDeparture,
                            y_departure,
                            x_arrival,
                            y_arrival,
                            distance, 
                            (int) speed,
                            IDtravelwarrant);
                    db.InsertTravelRoute(r);
		}
            }
            return temp;
        }catch (Exception e){
            e.printStackTrace();
        }
        return 0;
    }
    
}
