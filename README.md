# TemperatureDisplay
  1.Task to perform Mqtt transferring of data and store it in test file.
  
  2.display on webpage using the stored data in test file.

# Running Instruction
  1.Install the musquitto Broker using the link https://mosquitto.org/download/.
  
  2.Start the mosquitto Broker service.
  
  3.Downlaod the project code from this repository.
  
  4.Run the project in three instances.
  
  5.In 1st instance Run MqqtProtocol project which is win form project and in the form loaded click on Start Fetching Temperature button it will start fetching the temprature.
  
  6.In 2nd instance Run RecieveTempData project which is the console project and it will start recieving the data through Mqqt broker and store in the test.txt file in D directory.
  
  7.Once the temperature is recorded stop the 1st and 2nd project running instances. In 3rd instance run the DisplayTemp project which is web app project. Web page will be loaded in the browser giving the tempearture data which is stored in test.txt file and in graph view it will display the graph of the test.txt data.
