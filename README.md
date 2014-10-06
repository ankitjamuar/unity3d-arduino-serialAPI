unity3d-arduino-serialAPI
=========================

Serial API (DLL with code) for UNITY 3D to communicate with Arduino

<h2>How to use</h2>
<p>

Create an instance of the serialAPI class:
<br>
<code>

SerialAPI.Serial serial = new SerialAPI.Serial();
<p>
serial.GameAction += new SerialAPI.Serial.GameEventHandler(serial_GameAction);
</p>
</code>

<h3>In order to consume data you have to implement the call back function.</h3>
<br>
<code>

 void serial_GameAction(string action)<br>
    {<br>
        //Consume "action"  however you want
      <br>
    }<br>
</code>
<br>

</p>
