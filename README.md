# STFacebookDisp

## Overview
STFacebookDisp is a project that is supposed to inform the user about incoming notifications on Facebook.  
It also allows you to view the last few notifications.

## Description
Our project is based on Facebook Application and STM32F407VG Discovery microcontroller. To show facebook notifications, We use LCD HD44780 display. To switch between notifications, We use Keyboard connected to STM board. Also there is a potentiometer to change contrast on LCD HD44780 display. We connect STM32f407VG to Facebook Api by the Virtual Com Port. When the connection is active, the application sends a packet of information that is interpreted by the microcontroller program and stored in memory. At the same time, a new notification message appears on the screen

## Tools
* <b>Facebook Displayer:</b> Visual Studio 2015, Language: C#
* <b>STM32F407VG Project:</b> CooCox, Language: C
## How to run
* <b>Facebook Displayer:</b> The application can be installed and launched directly from the folder: „Facebook Displayer Application” → Facebook Displayer.application, without pre-compiling the program in Visual Studio.
  
<b>I.</b> Upon launching the application, enter the Access Token that can be downloaded from this site:
https://developers.facebook.com/tools/explorer/?method=GET&path=me%2Fstatuses&version=v2.3 .
Unfortunately, this is necessary because  Facebook prevents apps from downloading such information as notifications for some time.	
  In the source code of the program, there is a reference to Facebook servers that automatically receive Access Token, but this Access Token is for the latest version of the application (which have the above limitations). 
  
<b>II.</b>  Once you have entered the Access Token, you can select one of the two login options:
* <b> Manual login </b> – will transfer the user to the Facebook login page. After logging in you will be able to use the remaining tabs. 
* <b> Auto login </b> – created especially for project needs. Automatically connects with Facebook →  gets a notification list →  selects port and baud rate → Sends a list of notifications to the connected device →  Every 5 seconds it checks for new notification.

<b>III. Notification list tab: </b>
* <b>Download list</b> – It allows to download the list of the latest 5 notifications for the connected account, 
* <b>Clear</b> – Clear the „Notification list” textbox.
* The <b>"Content to send"</b> window shows the package that will be sent to the connected device. 

<b> IV. Serial Port tab: </b>
* <b>Scan</b> – Button to scan the devices that are connected, 
* <b>Open port</b> – Opens a port for the device selected in "Port names" with the selected "baud rate", 
* <b>Close port</b> – Closes the previously opened port, 
* <b>Send list</b> – Sends the list downloaded in the "Notification List" tab, to the connected device,
* <b>Send</b> – Sends text written in "Data to send" box,
* <b>Read</b> – Displays a response from the device, 
* <b>Auto send</b> – Enabled means, refreshing the notification list every 5 seconds and automatically sending a new notification to the connected device.

<b> Connections tab: </b>
* <b>HD44780</b>    
VSS -> GND    
VDD -> +5V    
V0 -> ADC1 (Potentiometer)    
RS -> PB2    
RW -> GND    
E -> PB7        
D0 -> NULL    
D1 -> NULL    
D2 -> NULL    
D3 -> NULL    
D4 -> PC12    
D5 -> PC13    
D6 -> PB12    
D7 -> PB13    
A -> +3V3    
K -> GND    

* <b>Buttons    </b>    
G -> VDD    
K0 -> PC1    
K1 -> PD0    

* <b>Potentiometer    </b>    
VCC -> +3V3    
GND -> GND    
ADC1 -> V0 (HD44780)    

Hook a USB Micro cable to the STM32F407VG Discovery board. The device should be show up as a Virtual Com Port. Now you can use Facebook API to login into Facebook, then you should get first notification. Use 'User' button to show it, and use K0 and K1 buttons to switch between lastest notifications. To change LCD contrast use potentiometer.

## How to compile
<b>Facebook Displayer:</b> There is no need to change anything in source code.    
<b>STM32F407VG Project:</b>
* Clone project from repository.    
* Launch CooCox Project file, or copy all libraries and files into existing project and link all this files in CooCox.
* Build project and dowlnoad code to flash.

## Future improvements
<b>Plans for future:</b>
* Display more useful information about user,
* Connect the loudspeaker giving the sound after receiving the notification.

<b>Known bugs:</b>
* If more than one notification occurs within 5 seconds, the device will receive only the most recent one

## Attributions
<b>Used API:</b>  Facebook SDK 7.0.6 – It can be installed to a project directly in Visual Studio    
<b>Used STM Libraries:</b>
* TM_STM32F4_HD44780 Library    
* TM_STM32F4_Delay Library    
* TM_STM32F4_GPIO Library    
* TM_STM32F4_Timer_Properties Library     
From: https://stm32f4-discovery.net/2014/06/library-16-interfacing-hd44780-lcd-controller-with-stm32f4/    
* VCP Libraries    
From: https://github.com/xenovacivus/STM32DiscoveryVCP    
## License
MIT License 
Copyright (c) 2017 Konrad Michalak, Hubert Kaszuba

## Credits
<b>Created by:</b> Konrad Michalak, Hubert Kaszuba

The project was conducted during the Microprocessor Lab course held by the Institute of Control and Information Engineering, Poznan University of Technology.

<b>Supervisor:</b> Tomasz Mańkowski
