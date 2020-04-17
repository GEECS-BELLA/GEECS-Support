			***********************
			**** Read Me First ****
			***********************

Version 1.0.0
June 1, 2013


Introducing the TDK-Lambda IVI-COM/IVI-C Driver for the Z+ DC power supply products
---------------------------------------------------------------------------
  The instrument driver provides access to the functionality of the
  LambdaZPlus through a COM server which also complies
  with the IVI specifications.  This driver works in any development environment which
  supports COM programming including Microsoft® Visual Basic, Microsoft
  Visual C++, Microsoft .NET, Agilent VEE Pro, National Instruments LabVIEW, and others.
  The driver also works in IVI-C environements such as National Instruments LabWindows.  
 

Supported Instruments
---------------------
 All models in the Z+ family:
 Zvvv-aaa-LAN 

 where, vvv = voltage rating, and aaa = current rating

Installation
-------------
  System Requirements: The driver installation will check for the
  following requirements.  If not found, the installer will either
  abort, warn, or install the required component as appropriate.

  Supported Operating Systems:
    Windows XP
    Windows Vista
    Windows 7

  Shared Components
    Before this driver can be installed, your computer must already
    have several components already installed. The easiest way to
    to install these other components is by running the IVI Shared
    Components installation package available from the IVI Foundation
    as noted below. It installs all the items mentioned below.

    IVI Shared Components version 2.0.0 or later.
      The driver installer requires these components. They must be
      installed before the driver installer can install the driver.  

      The IVI Shared Components installer is available from: 
      http://www.ivifoundation.org/shared_components/Default.aspx
      
      
  VISA-COM
    Any compliant implementation is acceptable. Typically, VISA-COM is
    installed with VISA and other I/O library modules. 


Additional Setup
----------------
  .NET Framework
    The .NET Framework itself is not required by this driver. If you
    plan to use the driver with .NET, Service Pack 2 is required.
    Download from:
 http://msdn.microsoft.com/netframework/downloads/updates/sp/default.asp

  The .NET Framework requires an interop assembly for a COM
  server. A Primary Interop Assembly, along with an XML file for
  IntelliSense is installed with the driver. The driver's PIA, along
  with IVI PIAs are installed, by default, in:
  <Program Files>\IVI\Bin\Primary Interop Assemblies

  The PIA is also installed into the Global Assembly Cache (GAC) if
  you have the .NET framework installed.


Start Menu Shortcuts 
--------------------
   A shortcut to the driver help file is added to the Start Menu,
   Programs, LambdaZPlus group.  It contains "Getting
   Started" information on using the driver in a variety of programming
   environments as well as documentation on IVI and instrument specific
   methods and properties.

   You will also see shortcuts to the Readme file and any programming
   examples for this driver.


Help File
---------
  The help file (LambdaZPlus.chm) is located in the directory:
   <Program Files>\IVI\Drivers\LambdaZPlus

 
MSI Installer
-------------
   The installation package for the driver is distributed as an MSI 2.0
 file. You can install the driver by double-clicking on the file.
 This operation actually runs:
      msiexec /i LambdaZPlus.msi

   You can run msiexec from a command prompt and utilize its many
   command line options. There are no public properties which can be
   set from the command line.


Uninstall
---------
  This driver can be uninstalled like any other software from the
  Control Panel using "Add or Remove Programs". 

  To uninstall the IVI Shared Components you must use the IVI Cleanup
  Utility available from the IVI Foundation at:
   http://www.ivifoundation.org/

  Note: All IVI-COM drivers require the IVI Shared Components to
  function. To completely remove IVI components from your computer,
  uninstall all drivers then run the IVI Cleanup Utility. This utility
  does not remove any IVI drivers.


Revision History
----------------
  Version     Date         Notes
  -------   ------------   -----
  1.0.0.0   Nov 27, 2012  Initial release
                          
IVI Compliance
--------------
The following information is required by IVI 3.1.

IVI-COM/IVI-C IviDCPwr Specific Instrument Driver
IVI Instrument Class: IVI-4.4_IviDCPwr_v3.0
Group Capabilities:                    Supported:
IviDCPwrMeasurement                        yes
IviDCPwrSoftwareTrigger                    yes
IviDCPwrTrigger                            yes

Optional Features: This driver does not support Interchangeability
Checking, State Caching, or Coercion Recording.

Driver Identification: 
(These three strings are values of properties in the IIviIdentity
interface.)
Vendor: Lambda. 
Description: IVI-COM power supply driver for the Z+ series.
Revision: 1.0

Component Identifier: LambdaZPlus.LambdaZPlus
(The component identifier can be used to create an instance of the COM
server.) 

