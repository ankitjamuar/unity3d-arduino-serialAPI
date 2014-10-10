unity3d-arduino-serialAPI
=========================

Serial API (DLL with code) for UNITY 3D to communicate with Arduino

<h2>How to use</h2>
<p>
Import the DLL as new asset inside your unity project <br>
Create an instance of the serialAPI class in the calss where you want to receive the data:
<br>
<code>

SerialAPI.Serial serial = new SerialAPI.Serial("COM1",9600,false);
<p>
serial.GameAction += new SerialAPI.Serial.GameEventHandler(serial_GameAction);
</p>
</code>
<p>
<i>
COM1 => Serial Port
<br>
9600 => Baud Rate
<br>
false => enable data from hardware not dummy data.
</i>
</p>
<h3>In order to consume data you have to implement the call back function.</h3>
<code>
 void serial_GameAction(string action)</code><br>
    {<br>
        &nbsp;&nbsp;&nbsp;//Consume "action"  however you want</code>
      <br>
    }<br><code>


</p>
<h3> Enable Dummy data </h3>
<p>
In case the hardware is not available, there is params during object init that can generate dummy data you have to implement it inside the code and build the project again.<br>
Line no 74, 75 in Serial.cs inside the project, change the data and build it again.<br>
During object in use true as third param.<br>
<code>
serial = new SerialAPI.Serial("COM1",true);  //true
</code>
</p>
<p>
<i>Note: In case you want to change code for dll there are few things you need to keep in mind:
<br>
1) DataReceived event is not supported by UNITY so a thread is implemented to get rid of blocking.<br>
2) Sometimes there are dummy data in input buffer, so if you are trying to manipulate data in serial_GameAction() call back funtion, use try catch to inside the function to avoid erratic behaviour.<br>

</p>
<br>
Project was build using Visual Studio 2010<br>
For any help inbox me ankitsinha611@gmail.com
