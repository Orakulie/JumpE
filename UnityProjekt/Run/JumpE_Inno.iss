; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{452CCA1B-5D4E-4DCE-B4BE-04D6887F5854}
AppName=JumpE
AppVersion=1.0
;AppVerName=JumpE 1.0
AppPublisher=Jan Schmidt
AppPublisherURL=jumpee.de.tl
AppSupportURL=jumpee.de.tl
AppUpdatesURL=jumpee.de.tl
DefaultDirName={pf}\JumpE
DisableProgramGroupPage=yes
OutputBaseFilename=JumpE_Setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\DEV\UNITY\PROJEKTE\Jumpe\Run\JumpE\JumpE.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\DEV\UNITY\PROJEKTE\Jumpe\Run\JumpE\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\JumpE"; Filename: "{app}\JumpE.exe"
Name: "{commondesktop}\JumpE"; Filename: "{app}\JumpE.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\JumpE.exe"; Description: "{cm:LaunchProgram,JumpE}"; Flags: nowait postinstall skipifsilent
