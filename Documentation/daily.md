

[TOC]

# ToDo

## Desktop

- [X] Connect to port
- [X] Import device settings
- [X] Read data
- [X] Pause reading data
- [X] Export data as excel
- [ ] Chart

## Firmware uC

### ADC-Device

- [X] Able to send measurement values
- [ ] Able to read values from ADC

### DAC-Device

- [ ] Send values to DAC hardware


## Hardware (DAC PCB)

- [ ] Calculate resistor values
- [ ] Create schematic
- [ ] Create layout
- [ ] Order PCB

# Bugs

## Deskop

- [X] Measurement-Button not updating!
	- 	Color update
	- 	content update
- [ ] "operation cancelled" error on measurement stop


# Log

## 2022-02-22

### Tim

- [Desktop] Erstellung 2 Repositories (Firmware Megacard, Desktop Applikation)
- [CLI-Desktop] Simple Kommumikation zwischen Megacard und Desktop
  - Senden Tasterdruck Megacard
  - Anzeige der Daten im Terminal (Desktop)
- [uC Firmware] create demo application
  - set usart settings
  - read ports and send via usart
  - output on led's (testing purpose)

## 2022-03-01

### Tim

- [Desktop] Start implementierung Model-View-ViewModel (MVVM)
- [Desktop] Erstellung "ChooseComport" Unterfenster (View)
  - Mit zugehörigem ViewModel
- [Desktop] Erstellung Klassen "Portmanager"
  - Unterklasse "DeviceInfo" (zur exportierung der Settings -> Vorarbeit "DeviceSettings" View)



## 2022-03-15

### Tim

- [Desktop] Fertigstellung "ChooseComport" View 
  - Verknüpfung mit ViewModel
  - Speichern Daten in "PortManager" Klasse
- [Desktop] Erstellung einer ViewModelBase 
  - Einbindung INotifyPropertyChanged
- [Desktop] Erstellung "DeviceInfoManager"
  - Serialisierung
  - Deserialisierung
- [Desktop] Erstellung "CommandBase" als Grundlage für Commands
- [Desktop] Navigationstore -> Enthält derzeitiges View/ViewModels
- [Desktop] Erstellung "PortManager" -> Klasse zur Organisation der Port-Connection
- [Desktop] Erstellung "DeviceSettingsView" Oberfläche, um DeviceSettings-JSON zu importieren
  - Zugehöriges ViewModel

## 2022-03-16

### Johannes

-  Erstellen einer Skizze für den Schaltplan eines...
  - ADC's
  - DAC's

### Tim

- [Desktop] Fertigstellung Navigation
  - Jeweilige Konstruktoren erstellt

- [Desktop] Commands

  - Funktion zur Aktivierung des Confirm-Buttons ("EnableConfirmCommand")

  - Funktion, um derzeitiges View/ViewModel zu wechseln ("NavigateCommand")
  - Command, um DeviceSettings per FileDialog auszuwählen

- [Desktop] Erstellung Toast-Notifications

  - Einbindung des Notifications.Wpf.Core NuGet-Packages
  - Erstellung einer statischen Klasse, um Notifications zu organisieren
  - Erstellen der gewünschten Notifications an den jeweiligen Stellen.

- [Desktop] Fertigstellung der DeviceManager serialisierung
- [Desktop] Erstellen einer "PortManager"-Klasse, zur Organisation des derzeitig ausgewählten Komports (Steuerung, Abspeichern, IsRequiredInfoSet?)
- [Desktop] Clean up code
  - Remove unused imports
  - Sort imports
  - Sort merhods/events/properties/fields/ctor/commands
- [Desktop] Erstellen eines Interfaces für die Verwendung des ConfirmButton-Commands

## 2022-03-18

### Tim

- [Desktop] Erstellen .Gitignore  (Speicher-Ersparnisse, Prävention Userfiles-Leak)
- [Desktop] Erstellung einer "DashboardView"
  - Binding Content und Farbe des Start/Stopp Buttons
  - Verknüpfung mit ViewModel
  - Eintrag in NavigationStore
- [CLI-Desktop] Testen Empfang duch Events (-> Kein Erfolg)
- [Desktop] Erstellen einer Measurement Klasse
  - Wert
  - UTC - Zeitstämpel (Wird automatisch generiert)
- [Desktop] Beginn Binding Start/Stopp Button änderung (Bisher Kein erfolg -> OnPropertyChanged Lösung finden!)

## 2022-03-19

### Tim

- [Desktop] Beginn implementierung Excel-Export (Erfolg bis auf Formatierung Zeitstempel -> Muss gefixed werden!)
  - Erstellen eines Test-Projektes
  - Erstellen einer Klasse

## 2022-03-22

### Tim

- [Desktop] new branch -> measurement-thread
  - messabfrage von tasks zu threads gewechselt
  - thread empfang start/stopp
  - empfang test -> successful!
- [Desktop] Fix actionButton update bug (see under "bugs")
- [Desktop] change action button UI colors (red/green)
- [Desktop] merge branch


## 2022-04-19

### Tim

- [Desktop] Implement excel-export into GUI application
	- create button commands
	- fixed date aligment
	- merge open pull requests



