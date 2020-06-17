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
public class Driver {
    private int id;
    private String name;
    private String surname;
    private String phoneNum;
    private String licenceNum;    

    public void setId(int id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public void setPhoneNum(String phoneNum) {
        this.phoneNum = phoneNum;
    }

    public void setLicenceNum(String licenceNum) {
        this.licenceNum = licenceNum;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getSurname() {
        return surname;
    }

    public String getPhoneNum() {
        return phoneNum;
    }

    public String getLicenceNum() {
        return licenceNum;
    }

    public Driver(String name, String surname, String phoneNum, String licenceNum) {
        this.name = name;
        this.surname = surname;
        this.phoneNum = phoneNum;
        this.licenceNum = licenceNum;
    }

    public Driver(int id, String name, String surname, String phoneNum, String licenceNum) {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.phoneNum = phoneNum;
        this.licenceNum = licenceNum;
    }

    
}
