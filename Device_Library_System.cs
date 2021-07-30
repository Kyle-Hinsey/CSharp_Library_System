using System;
using System.Collections.Generic;

namespace DeviceLibrarySystem {

    class Program {
        
        public static void Main(string[] args) {
            // variables
            LibrarySystem newLibrarySystem = new LibrarySystem();
            // call method
            newLibrarySystem.loadLibrarySystem();
        } // end method Main

    } // end class Program

    class Device {

        // fields
        private bool availability;
        private string name;
        private string sku;

        // constructor 
        public Device(bool availability, string name, string sku) {
            // initialize 
            this.availability = availability;
            this.name = name;
            this.sku = sku;
        } // end constructor 

        // constructor 
        public Device(string name, string sku) {
            // initialize 
            this.availability = true;
            this.name = name;
            this.sku = sku;
        } // end constructor

        // availability getter & setter
        public bool Availability {
            get {return availability;}
            set {availability = value;}
        } // end getter & setter

        // name getter & setter
        public string Name {
            get {return name;}
            set {name = value;}
        } // end getter & setter

        // sku getter & setter
        public string Sku {
            get {return sku;}
            set {sku = value;}
        }

    } // end class Device

    class LibrarySystem {

        // fields 
        public List<Device> deviceList = new List<Device>();

        // primary method that shows options for system
        public void loadLibrarySystem() {
            
            // variables
            int input = 0;
            do {
                // header
                Console.WriteLine("\n\t\t\tLibrary Device Checkout System\n");
                // Options
                Console.WriteLine("1. List Device by Title\n2. Add New Devices\n3. Edit Device Information\n4. Search by Device Name\n5. Check Out Device\n6. Check In Devices\n7. Exit");

                // ask user for input
                input = readInteger("\nSelect menu options 1-7: ");

                // switch on user input
                switch(input) {
                    case 1:
                        listDevice();
                        break;
                    case 2:
                        addDevice();
                        break;
                    case 3:
                        editDevices();
                        break;
                    case 4:
                        searchDevices();
                        break;
                    case 5:
                        checkOut();
                        break;
                    case 6:
                        checkIn();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                } // end switch
            } while(input != 7);

        } // end method loadLibrarySystem

        // add device
        private void addDevice() {

            // variables 
            string sku;
            string name;
            Device tmpDevice;

            // header
            Console.WriteLine("\n\t\t\tLibrary Device Checkout System - Add New Device\n");

            // enter sku and name
            Console.Write("SKU: ");
            sku = Console.ReadLine().ToUpper();
            Console.Write("Name: ");
            name = Console.ReadLine();

            // construct device
            tmpDevice = new Device(name, sku);

            // add device to the device list
            deviceList.Add(tmpDevice);

            // console message - added device
            Console.WriteLine($"Added {name} to the catalog.\n\n");

        } // end method addDevice

        // check in devices
        private void checkIn() {

            // variable
            int counter = 1; // starts at 1 because there needs to be at least one device
            int deviceNumber;

            // header
            Console.WriteLine("\n\t\t\tLibrary Device Checkout System - Check In Device\n");
            // header 
            Console.WriteLine($"{"#",-2} {"SKU",-8} {"Name", -40}");

            // foreach list through device
            foreach (Device d in deviceList) {
                // check availability 
                if (d.Availability == false) {
                    Console.WriteLine($"{counter,-2} {d.Sku,-8} {d.Name,-40}");
                } // end if 
                // increment counter
                counter++;
            } // end foreach

            // enter device number
            Console.Write("Enter device number: ");
            deviceNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            deviceList[deviceNumber].Availability = true;

            // message - checked in
            Console.WriteLine("Device checked in.");

        } // end method checkIn

        private void checkOut() {

            // variables
            int counter = 1; // starts at 1 because there needs to be at least one device
            int deviceNumber;

            // header
            Console.WriteLine("\n\t\t\tLibrary Device Checkout System - Check Out Device\n");
            // header 
            Console.WriteLine($"{"#",-2} {"SKU",-8} {"Name", -40}");

            // foreach list through device
            foreach (Device d in deviceList) {
                // check availability 
                if (d.Availability == true) {
                    Console.WriteLine($"{counter,-2} {d.Sku,-8} {d.Name,-40}");
                } // end if 
                // increment counter
                counter++;
            } // end foreach

            // enter device number
            Console.Write("Enter device number: ");
            deviceNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            deviceList[deviceNumber].Availability = false;

            // message - checked out
            Console.WriteLine("Device checked out.");

        } // end method checkOut

        // change device attributes 
        private void editDevices() {

            // variables 
            int counter = 1; // starts at 1 because there needs to be at least one device
            string availability;
            int deviceNumber;

            // header
            Console.WriteLine("\n\t\t\tLibrary Device Checkout System - Edit Device\n");
            // header 
            Console.WriteLine($"{"#",-2} {"SKU",-8} {"Name", -40}");

            // foreach list through device
            foreach (Device d in deviceList) {
                // check availability
                if (d.Availability == false) {
                    availability = "Checked Out";
                } // end if
                else {
                    availability = "Available";
                } // end else
                Console.WriteLine($"{counter,-2} {d.Sku,-8} {d.Name,-40} {availability,-12}");
                // increment counter
                counter++;
            } // end foreach

            // user selects device
            Console.Write($"\nEnter device number to edit: ");
            deviceNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            // change sku and name
            Console.Write("SKU: ");
            deviceList[deviceNumber].Sku = Console.ReadLine();
            Console.Write("Name: ");
            deviceList[deviceNumber].Name = Console.ReadLine();

            // message - information updated
            Console.WriteLine("\nDevice information has been updated.");
        } // end method editDevices

        // list all devices
        private void listDevice() {

            // variables
            int counter = 1; 
            string availability;

            // header
            Console.WriteLine("\n\t\t\tLibrary Device Checkout System - List Devices\n");
            // header 
            Console.WriteLine($"{"#",-2} {"SKU",-8} {"Name", -40}");

            // foreach list through devices
            foreach (Device d in deviceList) {
                // check availability 
                if (d.Availability == false) {
                    availability = "Checked Out";
                } // end if
                else {
                    availability = "Availabile";
                } // end else
                Console.WriteLine($"{counter,-2} {d.Sku,-8} {d.Name,-40} {availability,-12}");
                // increment counter
                counter++;                
            }
        } // end method listDevice

        private void searchDevices() {
            
            // variables
            int counter = 1;
            string deviceContains = "";

            // header
            Console.WriteLine("\n\t\t\tLibrary Device Checkout System - Search\n");
            Console.Write("Enter a device to search for: ");
            deviceContains = Console.ReadLine();

            // show listings
            Console.WriteLine($"\nListings for '{deviceContains}'");
            //header
            Console.WriteLine($"{"#",-2} {"SKU",-8} {"Name", -40}");

            // for each list through device
            foreach (Device d in deviceList) {
                if (d.Name.ToLower().Contains(deviceContains.ToLower())) {
                    Console.WriteLine($"{counter,-2} {d.Sku,-8} {d.Name,-40}");
                } // end if
                // increment counter
                counter++;
            } // end foreach

        } // end method searchDevices

        public int readInteger(string displayString) {
            // variables
            int numberOfErrors = 0;
            int number = 0;
            bool repeatInput = false;

            // try to see if correct input
            do {
                try {
                    Console.Write(displayString);
                    number = Convert.ToInt32(Console.ReadLine());
                    repeatInput = false;
                } // end try
                catch (FormatException) {
                    // if the user has made two errors already
                    if (numberOfErrors == 2) {
                        Console.WriteLine("There are problems entering data, press enter to exit.");
                        Console.ReadLine();
                        Environment.Exit(0);
                    } // end if
                    // if the user has made less than 2 errors
                    Console.WriteLine("The input must be numeric");
                    repeatInput = true;
                    numberOfErrors++;
                } // end catch
            } while(repeatInput == true);

            // return value
            return number;

        } // end method readInteger

    } // end class LibrarySystem

} // end namespace Program